using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideIn : MonoBehaviour
{

    [SerializeField] float targetX;
    [SerializeField] float targetY;
    [SerializeField] float interp;
    [SerializeField] RectTransform obj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!(Mathf.Abs(targetX-obj.position.x) < interp * Time.deltaTime && Mathf.Abs(targetY - obj.position.y) < interp * Time.deltaTime))
        {
            if(!(Mathf.Abs(targetX - obj.position.x) < interp * Time.deltaTime))
            {
                obj.position = new Vector2((Mathf.Sign(targetX - obj.position.x) * interp * Time.deltaTime) + obj.position.x, obj.position.y);
            }

            if (!(Mathf.Abs(targetY - obj.position.y) < interp * Time.deltaTime))
            {
                obj.position = new Vector2(obj.position.x, (Mathf.Sign(targetY - obj.position.y) * interp * Time.deltaTime) + obj.position.y);
            }
        }


    }
}
