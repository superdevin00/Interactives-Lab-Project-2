using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GemMiner : MonoBehaviour
{
    [SerializeField] GameObject mineParticleSystemPrefab;

    private void OnEnable()
    {
        ARInputManager.OnTouch += TryMine;
    }

    private void OnDisable()
    {
        ARInputManager.OnTouch -= TryMine;
    }

    private void TryMine(Touch touch)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 100f));
        Ray ray = new Ray(cameraPos, touchPos - cameraPos);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, ~0, QueryTriggerInteraction.Collide))
        {
            Instantiate(mineParticleSystemPrefab, hitInfo.point, Quaternion.identity, transform);
        }
    }
}
