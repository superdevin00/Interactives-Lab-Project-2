using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeInText : MonoBehaviour
{

   // [SerializeField]  tx;
    [SerializeField] float startingVal;
    [SerializeField] float multiplier;
    Color col;

    // Start is called before the first frame update
    void Start()
    {
      //  tx = 
      //  col = tx.color;
        col.a = startingVal;
    }

    // Update is called once per frame
    void Update()
    {
        col.a += Time.deltaTime * multiplier;
     //   tx.color = col;

    }
}
