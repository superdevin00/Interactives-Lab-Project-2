﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivations : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("gameStarted") == 1)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("gameStarted") == 1)
        {
            gameObject.SetActive(false);
        }
    }
}
