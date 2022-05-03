using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Singleton : MonoBehaviour
{
    public static UI_Singleton i;
    void Awake()
    {
        if (i == null)
        {
            //Retain on Load of New Scene
            i = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Camera Loaded");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
