using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpinner : MonoBehaviour
{
    [SerializeField] float spinSpeed = 30f;

    void Update()
    {
        float spinAmount = spinSpeed / Time.deltaTime;
        transform.Rotate(Vector3.up, spinAmount);
    }
}
