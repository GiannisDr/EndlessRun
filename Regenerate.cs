using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regenerate : MonoBehaviour
{

    public GameObject player; //o paikths pou paizei
    public GameObject[] groundPrefabs; // o pinakas me ta etoima prefabs
    private float distance = 0f; // h apostash 
    private float differentDistance = 10f; // h apostash ppoy otan thn perasei o paikths ftiaxnoume neo prefab
    public List<GameObject> groundObjects = new List<GameObject>(); //h lista me ta hdh uparxwn prefabs
    private int olderGround; // to palio edafos
    // Use this for initialization
    void Start()
    {
        GenerateGround();
    }

    // Update is called once per frame
    void Update()
    {
        LoadGround();
    }

    private void LoadGround()
    {
        //otan o paikths exei perasei thn save apostash tote kanei instantiate to epomeno kai meta diagrafei to prwto prefab
        if (player.transform.position.x > differentDistance)
        {
            GenerateGround();
        }
        RemoveOldGround();
    }

    private void GenerateGround()
    {
        //me ayth thn methodo kanoume instantiate to ground meta to prwto grounf kai to pros8etoume sth lista me ta grounds
        int randomNumberPrefab = RandomPrefab();
        //Debug.Log(randomNumberPrefab);
        GameObject prefab = Instantiate(groundPrefabs[randomNumberPrefab], new Vector3(distance, 0, 0), new Quaternion(0, 0, 0, 0));
        prefab.transform.SetParent(gameObject.transform);
        groundObjects.Add(prefab);
        distance = distance + 50f;
        differentDistance = distance - 80;
    }

    private void RemoveOldGround()
    {
        //otan exoun ftiaxtei panw apo 3 grounds tote katastrefei to prwto sthn lista etsi wste na mhn fwrtwnei thn mnhmh
        if (groundObjects.Count > 3)
        {
            Destroy(groundObjects[0]);
            groundObjects.RemoveAt(0);

        }
    }

    private int RandomPrefab()
    {
        //Methodos pou tsekarei ton ari8mo gia to instatiate tou prefab
        //kai koitaei na mhn einai pote o idios me ton prohgoumeno
        int currentNumber;
        do
        {
            currentNumber = Random.Range(0, groundPrefabs.Length);
        } while (currentNumber == olderGround);
        
        if (currentNumber != olderGround)
        {
            olderGround = currentNumber;
        }
        return currentNumber;
    }
}





