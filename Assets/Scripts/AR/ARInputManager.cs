using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ARInputManager : MonoBehaviour
{
    public static ARInputManager i;

    private void Awake()
    {
        if (i == null)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        ARInputManager.OnTouch += DebugHit;
    }

    public static event Action<Touch> OnTouch;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            OnTouch?.Invoke(touch);
        }
    }

    private void DebugHit(Touch touch)
    {
        Vector2 screenPos = touch.position;

        Vector3 start = Camera.current.transform.position;
        Vector3 end = Camera.current.ScreenToWorldPoint(screenPos);
        Vector3 direction = end - start;

        RaycastHit hit;
        if (Physics.Raycast(start, direction, out hit, Mathf.Infinity, 0)) {
            //Debug.DrawRay(transform.position, direction * hit.distance, Color.yellow);
            Debug.DrawRay(transform.position, end, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            //Debug.DrawRay(transform.position, direction * 1000, Color.white);
            Debug.DrawRay(transform.position, end, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
