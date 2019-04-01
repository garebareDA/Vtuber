const express = require('express');
const app = express();
const http = require('http').Server(app);
const PORT = process.env.PORT || 8000;

const WebSocketServer = require('ws').Server;
const wss = new WebSocketServer({port: 8080});

var connections = [];

app.get('/server' , function(req, res){
    res.sendFile(__dirname+'/index.html');
});

wss.on('connection', (ws) => {
    connections.push(ws);

    ws.on('close', function () {
        connections = connections.filter(function (conn, i) {
            return (conn === ws) ? false : true;
        });
    });

    ws.on('message', (msg) => {
        broadcast(msg);
    });
});

function broadcast(message) {
    connections.forEach((con, i) => {
        con.send(message);
    });
}

http.listen(PORT, function() {
    console.log('server listening. Port:' + PORT);
});