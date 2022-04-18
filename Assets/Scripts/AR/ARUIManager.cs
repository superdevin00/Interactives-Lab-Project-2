using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ARUIManager : MonoBehaviour
{
    [SerializeField] ARPlacement aRPlacement;

    [Header("UI References")]
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject enableCameraText;
    [SerializeField] GameObject lookAtSurfaceText;

    bool cameraExists = false;

    private void Start()
    {
        aRPlacement.OnFindPlacementPose += (pose) => OnPlacementPoseFound();

        cameraExists = false;
        OnCameraDisabled();
    }

    private void Update()
    {
        //Debug.Log(Camera.main == null);
        if (!cameraExists && Camera.main != null)
        {
            cameraExists = true;
            OnCameraEnabled();
        }
        else if (cameraExists && Camera.main == null)
        {
            cameraExists = false;
            OnCameraDisabled();
        }
    }

    private void OnCameraEnabled()
    {
        enableCameraText.SetActive(false);
        lookAtSurfaceText.SetActive(true);
    }


    private void OnCameraDisabled()
    {
        enableCameraText.SetActive(true);
        lookAtSurfaceText.SetActive(false);
    }

    private void OnPlacementPoseFound()
    {
        lookAtSurfaceText.SetActive(false);
    }
}
