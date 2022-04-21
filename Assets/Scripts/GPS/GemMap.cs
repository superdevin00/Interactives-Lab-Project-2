using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemMap : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject gemButton;
    private GameObject currentButton;
    public AreaOfPlay aop;
    public GameObject player;
    void Start()
    {
        currentButton = Instantiate(gemButton, new Vector3(-0.8f, -3f, 0), Quaternion.identity);
        currentButton.GetComponent<GemButton>().gemMap = gameObject;
        currentButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Collider2D[] colliders = new Collider2D[30];
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(LayerMask.NameToLayer("Player"));
        int count = GetComponent<Collider2D>().OverlapCollider(contactFilter, colliders);
        for(int i = 0; i < count; i++)
        {
            currentButton.SetActive(true);
        }
        if(count == 0)
        {
            currentButton.SetActive(false);
        }
        */
        if (GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>()))
        {
            currentButton.SetActive(true);
        }
        else
        {
            currentButton.SetActive(false);
        }
    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            currentButton.SetActive(true);
        }
        else
        {
            currentButton.SetActive(false);
        }
    }*/

    private void OnDestroy()
    {
        aop.generator = true;
        Destroy(currentButton);
    }
}
