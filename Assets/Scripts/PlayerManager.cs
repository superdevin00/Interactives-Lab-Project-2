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
    private float totalTimePassed;
    
    private int score;
    private int totalGemsCollected;
    private int gemsOnHand;
    private int gemsDeposited;

    private bool isTimerActive;

    public GameObject gemMap;

    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text gemsText;
    [SerializeField] Button shopButton;
    [SerializeField] Button gemButton;

    [SerializeField] GameObject parent;

    private GameObject playerObject;


    void Awake()
    {
        gemsDeposited = 25;
        gemsOnHand = 12;
        timeLeft = startingTime;
        isTimerActive = false;
    }

    private void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Timer stuffs
        if (isTimerActive)
        {
            timeLeft -= Time.deltaTime;
            totalTimePassed += Time.deltaTime;
        }

        timerText.text = (timeLeft).ToString("0");


        if (timeLeft <= 0)
        {
            increaseScore((int)totalTimePassed * 3);

            PlayerPrefs.SetInt("currentScore", score);

            if (PlayerPrefs.GetInt("highScore") < score)
            {
                PlayerPrefs.SetInt("highScore", score);
            }

            SceneManager.LoadScene("Game Over");
            Destroy(parent);

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
        increaseScore(gemsOnHand * gemsOnHand);
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

    public void addRange(float range)
    {
        playerObject.GetComponent<CircleCollider2D>().radius += range;
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
    public void setTimerActive(bool isActive)
    {
        isTimerActive = isActive;
    }

    public void increaseScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
