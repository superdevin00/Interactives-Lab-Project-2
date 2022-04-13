using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ARUIManager : MonoBehaviour
{
    [SerializeField] ARPlacement aRPlacement;

    [Header("UI References")]
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject findPlaneInstructionObj;

    private void Start()
    {
        aRPlacement.OnFindPlacementPose += (pose) => HideInstructions();
    }

    private void HideInstructions()
    {
        findPlaneInstructionObj.SetActive(false);
    }
}
