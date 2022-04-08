using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpinner : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float spinSpeed = 30f;
    [SerializeField] float hoverOffset = .5f;
    [SerializeField] float hoverTime = 2f;

    float hoverTimer = 0f;

    void Update()
    {
        Spin();
        Hover();
    }

    void Spin()
    {
        float spinAmount = spinSpeed / Time.deltaTime;
        target.Rotate(Vector3.up, spinAmount);
    }

    void Hover()
    {
        float sin = Mathf.Sin(hoverTimer / hoverTime);
        float y = Mathf.Lerp(-hoverOffset, hoverOffset, sin);

        target.transform.position = new Vector3(target.position.x, y, target.position.z);
    }
}
