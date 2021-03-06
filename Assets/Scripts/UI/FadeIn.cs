using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{

    [SerializeField] SpriteRenderer spr;
    [SerializeField] float startingVal;
    [SerializeField] float multiplier;
    Color col;

    // Start is called before the first frame update
    void Start()
    {
        col = spr.color;
        col.a = startingVal;
    }

    // Update is called once per frame
    void Update()
    {
        col.a += Time.deltaTime * multiplier;
        spr.color = col;
    }
}
