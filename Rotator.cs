using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(0f, 5f, 0f, Space.World);
	}
}
