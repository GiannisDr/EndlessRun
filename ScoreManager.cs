using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {
    private Transform myTransform; //to transform tou object
    public Text healthText; // to text pou exei to health
    public Text PointText; //to text pou deixnei ta points
    public Text centerPointsText; //to text pou deixnei tous pontous otan xaneis
    public GameObject defeatPanel; // to panel pou emfanizetai otan xaneis
    public int playerHealth = 17; // h zwh tou paikth
    private float scorePoints; //to scor se float 
    public GameObject generateGround; //to object me to edafos poy to katastrefoume otan xanei o paikths
    private Movement playerMovement; //to script Movement einai attach ston paikth kai otan 3eperasoume tous 100 pontous anebazei taxythta
    private int compareScore = 50; // to compareScore anebainei ana 100 ka8e fora pou ftanei thn prohgoymenh timh gia na au3anete sunexeia
    // Use this for initialization
    void Start() {
        myTransform = GetComponent<Transform>(); // pairnoume to transform
        playerMovement = GetComponent<Movement>(); // pairnoume to script movement
    }

    // Update is called once per frame
    void Update() {
        DisplayHealthPlayer(); 
        DisplayPoints();
        SpeedUp();
        
    }

    //deixnoume tous pontous sto ui xrhsimopoiontas ton a3ona x(pros8etv 23,75 giati 3ekinaei katw apo to 0 h 8esh toy paikth
    private void DisplayPoints()
    {
        //scorePoints = Time.smoothDeltaTime + (myTransform.position.x + 23.75f);
        scorePoints = Mathf.Round(myTransform.position.x + 23.75f);
        PointText.text = "Points: " + scorePoints;
        
    }

    //deixnoume thn zwh tou paikth kai koitame an h zwh paei sto 0 tote na kanei enable to panel pou kanei kai na katastr4ei ta gameObjects
    private void DisplayHealthPlayer()
    {
        healthText.text = "Health: " + playerHealth;

        if (playerHealth == 0 || playerHealth < 0)
        {
            defeatPanel.SetActive(true);
            healthText.enabled = false;
            PointText.enabled = false;
            centerPointsText.enabled = true;
            centerPointsText.text = "Your points: " + (int)scorePoints;
            SaveData(scorePoints); //kanoume save to score gia na to deixnoume ka8e fora pou mpainei o paikths
            Destroy(generateGround);
            Destroy(this.gameObject);
           

        }
    }

    //otan o paikths akoumphsei empodio tote kanei zwh
    //eixa skopo na balw kai zwh alla telika den to exv doule4ei poly gia na dw poy 8a spwanarei
    //kai otan xtypaei mpala xanei zwh
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            playerHealth--;
        }

        if (other.tag == "Health")
        {
            playerHealth++;
            //Destroy(other.gameObject);
        }

        if (other.tag == "Ball")
        {
            playerHealth--;
        }

    }

    //sygkrinoume tous pontous gia na doume an tous exei ftasei gia na anebasoume thn taxyythta
    private void SpeedUp()
    {
        int scorePointsInt = (int)scorePoints;
        if (scorePointsInt == compareScore)
        {
            playerMovement.playerSpeed = playerMovement.playerSpeed + 1;
            compareScore = compareScore + 100;
        }
    }

    private void SaveData(float score)
    {
        if (score > PlayerPrefs.GetFloat("HighScore" , 0))
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }
    }

   
}



  

