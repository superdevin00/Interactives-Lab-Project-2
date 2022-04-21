using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMap : MonoBehaviour
{
    [SerializeField] GameObject shopButton;
    private GameObject currentShop;
    public GameObject player;
    void Start()
    {
        currentShop = Instantiate(shopButton, new Vector3(1f, -3f, 0), Quaternion.identity);
        currentShop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>()))
        {
            currentShop.SetActive(true);
        }
        else
        {
            currentShop.SetActive(false);
        }
    }
}
