using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScripts : MonoBehaviour
{
    public AudioClip tapSound;
    [SerializeField] TMP_Text highScoreText;
    private void Start()
    {
        highScoreText.text = "Highscore:  " + PlayerPrefs.GetInt("highScore").ToString("0");
    }

    public void LoadGameSetupScene()
    {
        AudioSource.PlayClipAtPoint(tapSound,new Vector3(0,1,-10),3.0f);
        SceneManager.LoadScene("GameSetupScene");
    }
}
