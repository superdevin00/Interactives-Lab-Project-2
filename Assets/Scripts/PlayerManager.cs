using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    //Timer Vars
    private float timeLeft;
    private float startingTime = 60;
    
    private int score;
    private int totalGemsCollected;
    private int gemsOnHand;
    private int gemsDeposited;

    public GameObject gemMap;

    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text gemsText;
    [SerializeField] Button shopButton;
    [SerializeField] Button gemButton;


    void Awake()
    {
        gemsDeposited = 25;
        gemsOnHand = 12;
        timeLeft = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Timer stuffs
        timeLeft -= Time.deltaTime;
        timerText.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            //Do something useful or Load a new game scene depending on your use-case
        }

        gemsText.text = gemsOnHand.ToString("0");
    }

    public float getTimeLeft()
    {
        return timeLeft;
    }
    public float getScore()
    {
        return score;
    }

    public int getGemsCollected()
    {
        return totalGemsCollected;
    }

    public int getGemsDeposited()
    {
        return gemsDeposited;
    }

    public void givePlayerGems(int gemsToGive)
    {
        gemsOnHand += gemsToGive;
        totalGemsCollected += gemsToGive;
    }

    public void depositGems()
    {
        gemsDeposited += gemsOnHand;
        gemsOnHand = 0;
    }
    public void useDepositedGems(int gemsToUse)
    {
        gemsDeposited -= gemsToUse;
    }

    public void addTime(float timeToAdd)
    {
        timeLeft += timeToAdd;
    }

    public void setShopButtonVisibility(bool isVisible)
    {
        shopButton.gameObject.SetActive(isVisible);
    }

    public void setGemButtonVisibility(bool isVisible)
    {
        gemButton.gameObject.SetActive(isVisible);
    }

    public void goToGemScene()
    {
        SceneManager.LoadSceneAsync("ARTest");
        Destroy(gemMap);
    }
}
