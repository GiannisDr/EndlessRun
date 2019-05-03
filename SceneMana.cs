using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMana : MonoBehaviour {

    /// <summary>
    /// AN O PAIKTHS PATHSEI TO KOUMPI RESTART 3ANA FORTONOUME THN SKHNH
    /// ALLIWS AN O PAIKTHS PATHSEI EXIT TOTE KLEINOUME THN EFARMOGH
    /// </summary>
	public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void CloseApp()
    {
        Application.Quit();
    }

    public void LobbyButton()
    {
        SceneManager.LoadScene(1);
    }
}
