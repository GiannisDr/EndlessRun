using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
    private Transform myTransform;
    private Rigidbody myRigidbody;
    public  int playerSpeed = 5;
    private bool isGrounded;
    
   /// <summary>
   /// PANW KATW SE AUTO TO SCRIPT ELEGXOUME TON PAIKTH KAI TON KANOUME TRANSLATE ME BASH TA PLHKTRA POU PATAEI O PAIKTHS
   /// ELEGXOUME AN O PAIKTHS EINAI STO EDAFOS TOTE MPOREI NA KANEI JUMP MONO MIA FORA
   /// </summary>

	// Use this for initialization
	void Start () {
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.freezeRotation = true;
        
        
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMovement();
       //Debug.Log(playerSpeed);
    }


    private void PlayerMovement()
    {
        myTransform.Translate(Vector3.forward * (playerSpeed * Time.deltaTime));
        if (Input.GetKey(KeyCode.W))
        {
            myTransform.Translate(Vector3.forward * (playerSpeed*Time.deltaTime));
        }
        
        /*
         * den 8a mporei o paikths na phgainei pisw Xd
        if (Input.GetKey(KeyCode.S))
        {
            myTransform.Translate(Vector3.back * (playerSpeed * Time.deltaTime));
        }
        */
        if (Input.GetKey(KeyCode.D))
        {
            myTransform.Translate(Vector3.right * (playerSpeed * Time.deltaTime));

        }
        if (Input.GetKey(KeyCode.A))
        {
            myTransform.Translate(Vector3.left * (playerSpeed * Time.deltaTime));
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigidbody.AddForce(Vector3.up, ForceMode.Impulse);
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

   
}
