using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    //Timer Vars
    private float timeLeft;
    private float startingTime = 60;
    
    private int score;
    private int totalGemsCollected;
    private int gemsOnHand;
    private int gemsDeposited;

    [SerializeField] TMP_Text timerText;


    // Start is called before the first frame update
    void Start()
    {
        timeLeft = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            //Do something useful or Load a new game scene depending on your use-case
        }
    }

    public float getTimeLeft()
    {
        return timeLeft;
    }
    public float getScore()
    {
        return score;
    }

    public void addTime(float timeToAdd)
    {
        timeLeft += timeToAdd;
    }
}
