using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class gameOverScript : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highscoreText;

    private void Start()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("currentScore").ToString("0");
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("highScore").ToString("0");
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
