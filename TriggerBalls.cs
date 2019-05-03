using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBalls : MonoBehaviour {

    public Blaster blasterScript;
    /// <summary>
    /// EDW ELEGXOUME OTAN O PAIKTHS AKOUMPHSEI STON COLLIDER TOTE ARXIZOUN NA PETAGONTE OI MPALES EPANW TOY
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            blasterScript.isHitted = true;
        }
    }
}
