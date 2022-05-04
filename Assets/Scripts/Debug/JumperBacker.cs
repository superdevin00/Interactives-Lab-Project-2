using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumperBacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(sceneName: "GPSTest");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
