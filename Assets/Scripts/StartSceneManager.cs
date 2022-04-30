using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    bool hasExitedStartScene = false;

    private void Update()
    {
        if (!hasExitedStartScene && PlayerManager.i != null)
        {
            SceneManager.LoadSceneAsync("GPSTest");
            hasExitedStartScene = true;
        }
    }
}
