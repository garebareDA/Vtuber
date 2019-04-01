using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 瞬き : MonoBehaviour {

    // Use this for initialization
    private SkinnedMeshRenderer blendshape_SMR;

    // Use this for initialization
    void Start()
    {
        blendshape_SMR = this.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine("start");

    }

    IEnumerator start()
    {
        while (true)
        {
            float _seed = Random.Range(0.0f, 200.0f);

            if (_seed > 0.7f)
            {
                blendshape_SMR.SetBlendShapeWeight(0, -50.0f + -50.0f * Mathf.Sin(Time.time));
            }else{
                blendshape_SMR.SetBlendShapeWeight(0, 0f + 1000.0f * Mathf.Sin(Time.time));
                
            }

            yield return new WaitForSeconds(10000);
        }
        
    }
}






