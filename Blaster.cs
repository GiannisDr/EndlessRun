using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour {

    public GameObject prefabSphere; //to prefab ths mpalas
    public Color[] colors; // o pinakas me ta xrwmata
    public List<GameObject> instaBalls = new List<GameObject>(); // o pinakas me tis mpales pou mpainoun otan ginontai insta
    public Transform[] ArrayTransforms; // o pinakas me ta transform
    private bool doPrefabs= true; // thn kanoume true gia na bgaloume prefabs
    private int oldPosition = 0; // to palio position etsi wste na to sygkrinoume kai na mhn bgaloume to idio me ayto 
    private int oldMaterial = 0; // to palio materials etsi wste na to sygkrinoume ekai na mhn bgaloume to idio me ayto
    private bool moveBall = false; //otan einai true kounaei tis hdh uparwxn mpales
    private int ballSpeed = 25; // h taxytphta ths mpalas alla metabalaete sthn poreia
    private float timer = 0.20f; // ana 20 milisecond kanei spwan tis mpales
    public bool isHitted = false; // auth h boolean einai sto trigger pou otan o paikths mpainei mesa ginetai true gia na 3ekinhsoume na petame tis mpales
	
	// Update is called once per frame
	void Update () {


        RunAllMethods();
	}

    //NAI PRWTA TA EXW BALEI SE MIA FUNCTION KAI META STHN UPDATE GIATI ALLIWS 8A EPREPE NA KOITAV STHN KA8E FUNCTION AN H ISHITTED EINAI TRUE 
    private void RunAllMethods()
    {
        if (isHitted)
        {
            MyTimer();
            InstantiateBalls();
            TranslateBall();
        }
    }
    

    //kanoume instantiate tis mpales kai meta setaroume na einai parent to obejcts tous
    //bgazoume ena random xrwma gia thn ka8e mpala to opoio to pairnei kai o toixos mexri na bgei allo xrwma
    private void InstantiateBalls()
    {
      
            if (doPrefabs)
            {
                int randomPosition = RandomPosition();
                GameObject ballPrefab = Instantiate(prefabSphere, ArrayTransforms[randomPosition].position, new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w));
                ballPrefab.GetComponent<Renderer>().material.color = colors[RandomColor()];
                gameObject.GetComponent<Renderer>().material.color = ballPrefab.GetComponent<Renderer>().material.color;
                ballPrefab.transform.SetParent(this.gameObject.transform);
                instaBalls.Add(ballPrefab);
                moveBall = true;
                doPrefabs = false;
            }
        
    }

    //kanoume translate panw ston paikth tis hdh uparwxn mpales
    private void TranslateBall()
    {
        if (moveBall)
        {
            for (int i = 0; i < instaBalls.Count; i++)
            {
                if (instaBalls[i] != null)
                {
                    instaBalls[i].transform.Translate(Vector3.left * (ballSpeed * Time.deltaTime));
                }
            }

        }

      
    }

    //o timer poy ana 20 miliseconds kanei true thn doPrefabs kai kanei instantiate tis mpales
    private void MyTimer()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            doPrefabs = true;
            timer = 0.20f;
        }
    }
   
    //epistrefoume ena position apo enan pinaka me positions kai elegxoume na mhn einai to idio me to prohgoumeno
    private int RandomPosition()
    {
        int currentNumberPosition;
        do
        {
            currentNumberPosition = Random.Range(0, ArrayTransforms.Length);
        } while (currentNumberPosition == oldPosition);

        if (currentNumberPosition != oldPosition)
        {
            oldPosition = currentNumberPosition;
        }
        return currentNumberPosition;
    }


    //etsi elegxoume to color na mhn bgazei pote idio me to prohgoymeno
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

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            isHitted = false;
            doPrefabs = false;
            moveBall = false;

            for (int i = 0; i < instaBalls.Count; i++)
            {
                Destroy(instaBalls[i]);
            }
        }
    }
}
