using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class GemMiner : MonoBehaviour
{
    static float TIME_TO_EXIT_SCENE = 1f;

    [SerializeField] GameObject mineParticleSystemPrefab;

    bool hasMined = false;

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
        if (hasMined)
            return;
        hasMined = true;

        Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0f));
        Ray ray = new Ray(touchPos, Vector3.forward);

        RaycastHit[] hitInfos = Physics.RaycastAll(ray, Mathf.Infinity, ~0, QueryTriggerInteraction.Collide);
        foreach (RaycastHit hitInfo in hitInfos)
        {
            if (hitInfo.collider.tag == "Gem")
            {
                OnMine(hitInfo.point);
                break;
            }
        }
    }

    private void OnMine(Vector3 minePos)
    {
        Instantiate(mineParticleSystemPrefab, minePos, Quaternion.identity, transform);
        PlayerManager.i.givePlayerGems(1);
        StartCoroutine(WaitForSceneTransition());
    }

    private IEnumerator WaitForSceneTransition()
    {
        yield return new WaitForSeconds(TIME_TO_EXIT_SCENE);
        SceneManager.LoadSceneAsync("GPSTest");
    }
}
