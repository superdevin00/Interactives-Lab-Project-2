﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{
    
    public void loadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
