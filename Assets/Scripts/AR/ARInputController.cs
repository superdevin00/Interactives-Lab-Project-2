using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInputController : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 screenPos = touch.position;


            Vector3 start = Camera.current.transform.position;
            Vector3 end = Camera.current.ScreenToWorldPoint(screenPos);
            Vector3 direction = end - start;

            RaycastHit hit;
            if (Physics.Raycast(start, direction, out hit, Mathf.Infinity, 0))
            {
                //Debug.DrawRay(transform.position, direction * hit.distance, Color.yellow);
                Debug.DrawRay(transform.position, end, Color.yellow);
                Debug.Log("Did Hit");
            }
            else
            {
                //Debug.DrawRay(transform.position, direction * 1000, Color.white);
                Debug.DrawRay(transform.position, end, Color.white);
                Debug.Log("Did not Hit");
            }
        }
    }
}
