using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayButton : MonoBehaviour {

    private Text highScoreText;

    private void Start()
    {
        highScoreText = GameObject.Find("HighScore").GetComponent<Text>();
        highScoreText.text = "HighScore:" + PlayerPrefs.GetFloat("HighScore").ToString();
    }

    public void ButtonStart()
    {
        SceneManager.LoadScene(0);
    }
}
