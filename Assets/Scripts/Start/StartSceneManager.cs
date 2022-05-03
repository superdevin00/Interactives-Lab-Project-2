using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] PermissionRequester permissionRequester;

    bool hasExitedStartScene = false;

    private void Update()
    {
        if (!hasExitedStartScene && UI_Singleton.i != null && permissionRequester.finishedRequesting)
        {
            SceneManager.LoadSceneAsync("GPSTest");
            hasExitedStartScene = true;
        }
    }
}
