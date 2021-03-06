using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GemButton : MonoBehaviour
{

    public GameObject gemMap;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D col = GetComponent<Collider2D>();


        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 tapPos = Camera.main.ScreenToWorldPoint(touch.position);
                if (Physics2D.OverlapPoint(tapPos) == col)
                {
                    //GO TO GEM
                    SceneManager.LoadSceneAsync("ARTest");
                    //SceneManager.LoadScene("JumpBackToGPSTest");
                    Destroy(gemMap);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Physics2D.OverlapPoint(tapPos) == col)
            {
                //GO TO GEM
                SceneManager.LoadSceneAsync("ARTest");
                //SceneManager.LoadScene("JumpBackToGPSTest");
                Destroy(gemMap);
            }
        }
    }
}
