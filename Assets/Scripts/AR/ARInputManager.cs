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
}
