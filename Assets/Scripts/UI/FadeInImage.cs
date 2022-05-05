using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInImage : MonoBehaviour
{

    [SerializeField] Image im;
    [SerializeField] float startingVal;
    [SerializeField] float multiplier;
    Color col;

    // Start is called before the first frame update
    void Start()
    {
        col = im.color;
        col.a = startingVal;
    }

    // Update is called once per frame
    void Update()
    {
        col.a += Time.deltaTime * multiplier;
        im.color = col;
        
    }
}
