using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{

    [SerializeField] SpriteRenderer spr;
    Color col;

    // Start is called before the first frame update
    void Start()
    {
        col = spr.color;
        col.a = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        col.a += Time.deltaTime;
        spr.color = col;
    }
}
