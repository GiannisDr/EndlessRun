using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaSonicBall : MonoBehaviour {

    private Transform myTransform;

	// Use this for initialization
	void Start () {
        myTransform = GetComponent<Transform>(); //to transform tou object
	}
	
	// Update is called once per frame
	void Update () {

        myTransform.Rotate(RandomSpeed(), 0f, 0f, Space.World); //to kanoume rotate bgazontas enan random ari8mo
	}


    //me auth thn function ftiaxnoume enan pinaka 5 8esewn kai ton gemizoume me tyxaious float ari8mous
    //meta dialegoume tuxaia mia 8esh kai thn epistrefoume
    private float RandomSpeed()
    {
        float[] floatArray = new float[5];
        int randomNumber = 0;
        for (int i = 0; i < 5; i++)
        {
            floatArray[i] = Random.Range(2f, 6f);
            //Debug.Log(floatArray[i]);
        }

        randomNumber = Random.Range(1, 5);

            return floatArray[randomNumber];
    }
}
