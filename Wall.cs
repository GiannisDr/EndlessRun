using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private Transform myTransform;
    private Vector3 pos1;
    private Vector3 pos2;
    
	// Use this for initialization
	void Start () {
        myTransform = GetComponent<Transform>();
        pos1 = myTransform.position;
        pos2 = new Vector3(myTransform.position.x, myTransform.position.y, -myTransform.position.z); //-5.48f);
	}
	
	// Update is called once per frame
	void Update () {
        TranslateWall();
        //Debug.Log(Mathf.Abs(myTransform.position.z));
    }
    

    private void TranslateWall()
    {
        myTransform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * 1.0f, 1.0f));
        //myTransform.Translate(0f, 0f, -0.5f, Space.World);
        
    }
}
