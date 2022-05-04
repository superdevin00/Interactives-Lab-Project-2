using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScripts : MonoBehaviour
{
    [SerializeField] TMP_Text highScoreText;
    private void Start()
    {
        highScoreText.text = "Highscore:  " + PlayerPrefs.GetInt("highScore").ToString("0");
    }

    public void LoadGameSetupScene()
    {
        SceneManager.LoadScene("GameSetupScene");
    }
}
