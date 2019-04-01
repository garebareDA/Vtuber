using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;


public class soserver : MonoBehaviour {

    WebSocket ws;
    Rotete rotate;  
   
    // Use this for initialization
    void Start () {
        Transform transform = this.transform;
   
        ws = new WebSocket("ws://localhost:8080");
        ws.Connect();
        ws.OnMessage += (object sender, MessageEventArgs e) => {
            rotate = JsonUtility.FromJson<Rotete>(e.Data);
        };
        ws.Send("connect");

    }

    // Update is called once per frame
    void Update () {
        transform.localEulerAngles = new Vector3(rotate.z, rotate.x, rotate.y);
    }
}

public class Rotete
{
    public float z;
    public float x;
    public float y;
}
