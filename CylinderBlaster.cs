using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderBlaster : MonoBehaviour {
    public GameObject prefabSphere; //h mpala pou kanoume instantiate
    public Color[] colors; // o pinakas me ta xrwmata pou 8a  parei h mpala
    public List<GameObject> instaBalls = new List<GameObject>(); //oi mpales pou ginonntai instantiate mpainoun edw mesa
    private bool doPrefabs = true; //metablhth gia na ftiaxnei ta prefabs
    private int oldMaterial = 0; // h timh tou paliou material
    private bool moveBall = false; // gia na katalabainei pote 3ekinhsei h methodos pou kounaei tis maples
    private float timer = 0.60f; //timer,ana tosa miliseconds 8a kanei spwan nea mpala
    public List<GameObject> ballObjects = new List<GameObject>(); //me auth thn lista diagrafw apo enan ari8mo kai meta tis mpales

    // Update is called once per frame
    void Update()
    {
        MyTimer(); // o atimer gia 3eroume ana poso bgazoume ta prefabs
        InstantiateBalls(); // otan h doprefab einai tru tote ftiaxnei instance ths mpalas
        TranslateBall(); // edw kounaei thn mpala
        RemoveOldBalls(); //kai me auth thn methodo diagrafoume ta prwta prwta prefabs mpalas
    }

    private void InstantiateBalls()
    {

        if (doPrefabs)
        {
            GameObject ballPrefab = Instantiate(prefabSphere, gameObject.transform.position , gameObject.transform.rotation);
            ballPrefab.GetComponent<Renderer>().material.color = colors[RandomColor()];
            ballPrefab.transform.SetParent(this.gameObject.transform);
            instaBalls.Add(ballPrefab);
            ballObjects.Add(ballPrefab);
            moveBall = true;
            doPrefabs = false;
        }

    }

    private void TranslateBall()
    {
        if (moveBall)
        {
            for (int i = 0; i < instaBalls.Count; i++)
            {
                if (instaBalls[i] != null)
                {
                    float randomNumb = RandomSpeed();
                    instaBalls[i].transform.Translate(Vector3.forward * (randomNumb * Time.deltaTime));
                }
            }

        }


    }

    private void RemoveOldBalls()
    {
        //otan exoun ftiaxtei panw apo 3 grounds tote katastrefei to prwto sthn lista etsi wste na mhn fwrtwnei thn mnhmh
        if (ballObjects.Count > 2)
        {
            Destroy(ballObjects[0]);
            ballObjects.RemoveAt(0);

        }
    }

    private void MyTimer()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            doPrefabs = true;
            timer = 0.60f;
        }
    }



    //tsekaroume to palio material etsi ka8e gora na mhn bgazei to idio me to prohgoumeno
    private int RandomColor()
    {
        int currentNumberColor;
        do
        {
            currentNumberColor = Random.Range(0, colors.Length);
        } while (currentNumberColor == oldMaterial);

        if (currentNumberColor != oldMaterial)
        {
            oldMaterial = currentNumberColor;
        }
        return currentNumberColor;
    }

    //me auth thn function ftiaxnoume enan pinaka 5 8esewn kai ton gemizoume me tyxaious float ari8mous
    //meta dialegoume tuxaia mia 8esh kai thn epistrefoume
    private float RandomSpeed()
    {
        float[] floatArray = new float[5];
        int randomNumber = 0;
        for (int i = 0; i < 5; i++)
        {
            floatArray[i] = Random.Range(7f, 12f);
        }

        randomNumber = Random.Range(1, 5);



        return floatArray[randomNumber];
    }
}
