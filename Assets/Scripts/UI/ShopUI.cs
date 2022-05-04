using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private bool retainShop;

    public Sprite testSprite;
    PlayerManager player;
    [SerializeField] TMP_Text gemsDeposited;
    //[SerializeField] Button shopButton;


    private void Awake()
    {
        player = GameObject.Find("PlayerUI").GetComponent<PlayerManager>();
        container = transform.Find("Container");
        shopItemTemplate = container.Find("ShopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
        container.gameObject.SetActive(false);
    }

    private void Start()
    {
        //Object Persistence
        DontDestroyOnLoad(transform.gameObject);

        //Retain on Load of New Scene
        if (!retainShop)
        {
            retainShop = true;
            DontDestroyOnLoad(transform.gameObject);
            Debug.Log("Camera Loaded");
        }
        else
        {
            Destroy(gameObject);
        }

        CreateItemButton(ItemEnum.item.test, testSprite, "Test", 1, 0);
        CreateItemButton(ItemEnum.item.test, testSprite, "Test2", 17, 1);
        CreateItemButton(ItemEnum.item.test, testSprite, "Test3", 2, 2);
        CreateItemButton(ItemEnum.item.TimeIncrease, testSprite, "Timer Increase", 10, 3);
    }

    private void Update()
    {
        gemsDeposited.text = player.getGemsDeposited().ToString("0");
    }

    private void CreateItemButton(ItemEnum.item itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.Find("Panel").GetComponent<RectTransform>();
        RectTransform shopButtonRectTransform = shopItemTransform.Find("BuyButton").GetComponent<RectTransform>();


        float shopItemHeight = 410f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);
        shopButtonRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);


        shopItemRectTransform.Find("Item Name").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemRectTransform.Find("Item Cost").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemRectTransform.Find("Item Icon").GetComponent<Image>().sprite = itemSprite;

        shopItemTransform.GetComponentInChildren<Button>().onClick.AddListener(delegate { BuyItem(itemType,itemCost); } );

    }

    private void BuyItem(ItemEnum.item item, int cost)
    {
        
        int playerMoney = player.getGemsDeposited();

        if (cost <= playerMoney)
        {
            //Remove item cost from player bank
            player.useDepositedGems(cost);

            //Do thing depending on item type
            switch (item)
            {
                case ItemEnum.item.test:
                    Debug.Log("test");
                    break;

                case ItemEnum.item.DetectRangeIncrease:
                    break;

                case ItemEnum.item.TimeIncrease:
                    player.addTime(30f);
                    break;
            }
        }
        else
        {
            Debug.Log("not enough gems");
        }
    }

    public void setShopVisibility(bool isVisible)
    {
        container.gameObject.SetActive(isVisible);
    }

    public void toggleShopVisibility()
    {
        if (container.gameObject.activeInHierarchy == true)
        {
            container.gameObject.SetActive(false);
        }
        else
        {
            container.gameObject.SetActive(true);
        }
        
    }


    public void setButtonVisibility(bool isVisible)
    {
        player.setShopButtonVisibility(isVisible);
    }
}
