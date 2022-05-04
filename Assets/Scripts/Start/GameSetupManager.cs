using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetupManager : MonoBehaviour
{
    bool hasExitedGameSetupScene = false;

    private void Start()
    {
        PlayerPrefs.SetInt("generator", 0);
        PlayerPrefs.SetInt("gameStarted", 0);
    }

    private void Update()
    {
        if (!hasExitedGameSetupScene && UI_Singleton.i != null)
        {
            SceneManager.LoadScene("GPSTest");
            hasExitedGameSetupScene = true;
        }
    }
}
