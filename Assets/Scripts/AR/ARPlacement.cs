using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{
    public GameObject arObjectToSpawn;
    private GameObject spawnedObject;

    private Pose placementPose;
    [SerializeField] ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    public event Action<Pose> OnFindPlacementPose;

    private void Update()
    {
        if (spawnedObject == null)
        {
            if (!placementPoseIsValid)
                UpdatePlacementPose();
            else
                ARPlaceObject();
        }
    }

    void ARPlaceObject()
    {
        spawnedObject = Instantiate(arObjectToSpawn, placementPose.position, placementPose.rotation);
    }

    void UpdatePlacementPose()
    {
        // Find real-world flat surfaces
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(.5f, .5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        // Set first flat surface as a valid spawn position
        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;
            OnFindPlacementPose?.Invoke(placementPose);
        }
    }

}

