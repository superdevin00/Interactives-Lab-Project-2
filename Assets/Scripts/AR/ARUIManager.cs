using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Android;

public class ARUIManager : MonoBehaviour
{
    [SerializeField] ARPlacement aRPlacement;

    [Header("UI References")]
    [SerializeField] Canvas canvas;

    bool cameraExists = false;

    private void Start()
    {
        cameraExists = false;
    }

    private void Update()
    {
        if (!cameraExists && Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            cameraExists = true;
        }
        else if (cameraExists && !Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            cameraExists = false;
        }
    }

}
