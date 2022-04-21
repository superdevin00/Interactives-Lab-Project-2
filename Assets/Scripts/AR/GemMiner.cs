using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class GemMiner : MonoBehaviour
{
    static float TIME_TO_EXIT_SCENE = 2f;

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
            OnMine(hitInfo.point);
        }
    }

    private void OnMine(Vector3 minePos)
    {
        Instantiate(mineParticleSystemPrefab, minePos, Quaternion.identity, transform);
        PlayerManager playerManager = GameObject.FindObjectOfType<PlayerManager>();
        playerManager.givePlayerGems(1);
        StartCoroutine(WaitForSceneTransition());
    }

    private IEnumerator WaitForSceneTransition()
    {
        yield return new WaitForSeconds(TIME_TO_EXIT_SCENE);
        SceneManager.LoadSceneAsync("GPSTest");
    }
}
