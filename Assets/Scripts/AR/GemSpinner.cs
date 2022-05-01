using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpinner : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float spinSpeed = 30f;
    [SerializeField] float hoverHeight = .5f;
    [SerializeField] float hoverTime = 2f;

    float hoverTimer = 0f;

    void Update()
    {
        Spin();
        Hover();
    }

    void Spin()
    {
        float spinAmount = spinSpeed * Time.deltaTime;
        target.Rotate(Vector3.up, spinAmount);
    }

    void Hover()
    {
        float sin = Mathf.Sin((hoverTimer / hoverTime) * 2 * Mathf.PI);
        float y = Mathf.Lerp(-hoverHeight, hoverHeight, (sin + 1) / 2);

        target.transform.position = new Vector3(target.position.x, y, target.position.z);

        hoverTimer += Time.deltaTime;
    }
}
