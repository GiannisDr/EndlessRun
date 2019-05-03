using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpawn : MonoBehaviour {

    private GameObject player;
    private Transform playerTransform;
    private GameObject healthPointPref;
    private Transform earliestTransform;

    private void Start()
    {
        player = GameObject.Find("Player");
        healthPointPref = Resources.Load("HealthPoint") as GameObject;
        earliestTransform = player.GetComponent<Transform>();
    }


    private void Update()
    {
        Spawner();
    }


    private void Spawner()
    {
        
       
    }
}
