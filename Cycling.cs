using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycling : MonoBehaviour {
    private Transform myTransform;
    private Vector3 pos1; 
    private Vector3 pos2; 
    public float speed = 0.3f;
  

    /// <summary>
    /// ME AUTO TO SCRIPT KANOUME ROTATION KAI TRANSLATE TA MIKRA ASPRA PRAGMATAKIA POY GURNANE 
    /// </summary>
	// Use this for initialization
	void Start () { 
        myTransform = GetComponent<Transform>();
        pos1 = myTransform.position;
        pos2 = new Vector3(myTransform.position.x, myTransform.position.y, Mathf.Abs(myTransform.position.z));
        speed = RandomSpeed();
     }
	
	// Update is called once per frame
	void Update () {
        
        myTransform.Rotate(5, 0, 0, Space.World);
        myTransform.position = Vector3.Lerp(pos1, pos2,Mathf.PingPong(Time.time*speed , 1.0f));
    }



    //me auth thn function ftiaxnoume enan pinaka 5 8esewn kai ton gemizoume me tyxaious float ari8mous
    //meta dialegoume tuxaia mia 8esh kai thn epistrefoume
    private float RandomSpeed()
    {
        float[] floatArray = new float[5];
        int randomNumber = 0;
        for (int i = 0; i < 5; i++)
        {
            floatArray[i] = Random.Range(0f, 2f);
            //Debug.Log(floatArray[i]);
        }

        randomNumber = Random.Range(1, 5);



        return floatArray[randomNumber];
    }


}
