using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSOnScreen : MonoBehaviour
{
    [SerializeField] GPSLocation gpsLoc;
    [SerializeField] GPSPlayer gpsPlayer;
    public Text coordinates;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coordinates.text = gpsLoc.longitude.ToString() + "\n" + gpsLoc.latitude.ToString() + "\n" + gpsPlayer.tempX.ToString() + "\n" + gpsPlayer.tempY.ToString() + "\n" + gpsPlayer.transform.position.x.ToString() + "\n" + gpsPlayer.transform.position.y.ToString();
    }
}
