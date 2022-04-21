using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSPlayer : MonoBehaviour
{
    [SerializeField] GameObject map;
    [SerializeField] GPSLocation gpsloc;
    public bool locationControlled = true;

    private float mapHorzLength;
    private float mapVertLength;
    private float mapHorzMin;
    private float mapVertMin;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sRen = map.GetComponent<SpriteRenderer>();
        mapHorzLength = sRen.sprite.bounds.size.x * map.transform.lossyScale.x;
        mapVertLength = sRen.sprite.bounds.size.y * map.transform.lossyScale.y;
        mapHorzMin = map.transform.position.x - (mapHorzLength / 2);
        mapVertMin = map.transform.position.y - (mapVertLength / 2);

    }

    // Update is called once per frame
    void Update()
    {


        if (locationControlled)
        {
            float tempX = gpsloc.latitude / 0.0357f;
            float tempY = gpsloc.longitude / 0.0176f;
            transform.position = new Vector3(mapHorzMin + (tempX * mapHorzLength), mapVertMin + (tempY * mapVertLength), 5);
        }
        else
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 tapPos = Camera.main.ScreenToWorldPoint(touch.position);
                    transform.position = new Vector3(tapPos.x, tapPos.y, 0);
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 tapPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(tapPos.x, tapPos.y, 0);
            }
        }
    }
}
