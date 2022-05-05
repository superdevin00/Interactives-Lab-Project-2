using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMap : MonoBehaviour
{
    public ShopUI shop;
    //GameObject currentShop;
    public GameObject player;
    void Start()
    {
        shop = GameObject.Find("Shop UI").GetComponent<ShopUI>();
        shop.setShopVisibility(false);
        shop.setButtonVisibility(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>()))
        {
            shop.setButtonVisibility(true);
        }
        else
        {
            shop.setButtonVisibility(false);
            shop.setShopVisibility(false);
        }
    }
}
