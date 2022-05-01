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
        if (!hasExitedStartScene && PlayerManager.i != null && permissionRequester.finishedRequesting)
        {
            SceneManager.LoadSceneAsync("GPSTest");
            hasExitedStartScene = true;
        }
    }
}
