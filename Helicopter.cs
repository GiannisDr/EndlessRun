using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    private Transform myTransform;
    private Vector3 pos1;
    public Vector3 pos2;
    public float speed = 0.3f;


    // Use this for initialization
    void Start () {
        myTransform = GetComponent<Transform>();
        pos1 = myTransform.position;
        pos2 = new Vector3(myTransform.position.x, myTransform.position.y, -myTransform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        myTransform.Rotate(0, 5, 0, Space.World);
        myTransform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
