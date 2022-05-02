using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PermissionRequester : MonoBehaviour
{
    public bool finishedRequesting;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Permission.RequestUserPermission(Permission.Camera);
            Permission.RequestUserPermission(Permission.CoarseLocation);
            Permission.RequestUserPermission(Permission.FineLocation);
            finishedRequesting = true;
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            finishedRequesting = true;
        }
    }
}
