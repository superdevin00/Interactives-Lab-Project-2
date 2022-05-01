using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Android;

public class ARPlacement : MonoBehaviour
{
    static float SPAWN_GEM_TIME_DELAY = .4f;
    static Vector3 STARTING_GEM_OFFSET_FROM_CAMERA = new Vector3(0f, 0f, 5f);

    [SerializeField] ARRaycastManager aRRaycastManager;

    public GameObject arObjectToSpawn;
    private GameObject spawnedObject;

    // AR will snap gem to first object it finds, but nothing after that.
    private bool hasSnappedToARObject = false;

    private void Start()
    {
        StartCoroutine(WaitToPlaceObject());
    }

    private void Update()
    {
        if (spawnedObject != null && !hasSnappedToARObject)
            TrySnapToARObject();
    }

    IEnumerator WaitToPlaceObject()
    {
        // Small delay because Android device doesn't enable camera immediately
        yield return new WaitForSeconds(SPAWN_GEM_TIME_DELAY);
        ARPlaceObject();
    }

    void ARPlaceObject()
    {
        Vector3 cameraPos = (Camera.current) ? Camera.current.transform.position : new Vector3();
        Pose pose = new Pose(cameraPos + STARTING_GEM_OFFSET_FROM_CAMERA, Quaternion.identity);
        spawnedObject = Instantiate(arObjectToSpawn, pose.position, pose.rotation);
    }

    void UpdateGemPos(Pose pose)
    {
        spawnedObject.transform.position = pose.position;
        spawnedObject.transform.rotation = pose.rotation;
    }

    void TrySnapToARObject()
    {
        // Find trackable objects
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(.5f, .5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.All);

        // Set first object surface as a valid position
        if (hits.Count > 0)
        {
            hasSnappedToARObject = true;
            UpdateGemPos(hits[0].pose);
        }
    }

}

