using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSOnScreen : MonoBehaviour
{
    [SerializeField] GPSLocation gpsLoc;
    public Text coordinates;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coordinates.text = "LAT: " + gpsLoc.latitude.ToString() + "\nLON: " + gpsLoc.longitude.ToString() + "\n";
    }
}
