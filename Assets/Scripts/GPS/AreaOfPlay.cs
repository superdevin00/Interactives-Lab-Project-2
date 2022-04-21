using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfPlay : MonoBehaviour
{

    [SerializeField] GameObject upArrow;
    [SerializeField] GameObject downArrow;
    [SerializeField] GameObject start;
    [SerializeField] GameObject player;
    [SerializeField] Collider2D areaBlocked;
    [SerializeField] GameObject gemMap;
    [SerializeField] GameObject shopMap;
    public bool generator = false;
    public bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            transform.position = player.transform.position;
        }

        Collider2D upArrowCol = upArrow.GetComponent<Collider2D>();
        Collider2D downArrowCol = downArrow.GetComponent<Collider2D>();
        Collider2D startCol = start.GetComponent<Collider2D>();

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 tapPos = Camera.main.ScreenToWorldPoint(touch.position);
                //transform.position = new Vector3(tapPos.x, tapPos.y, 0);
                if (Physics2D.OverlapPoint(tapPos) == startCol)
                {
                    gameStarted = true;
                    upArrow.SetActive(false);
                    downArrow.SetActive(false);
                    start.SetActive(false);
                    generator = true;
                    GameObject temp = Instantiate(shopMap, transform.position, Quaternion.identity);
                    temp.GetComponent<ShopMap>().player = player;

                }
                if (Physics2D.OverlapPoint(tapPos) == upArrowCol)
                {
                    transform.localScale = transform.localScale + new Vector3(0.02f, 0.02f, 0f);
                }
                if (Physics2D.OverlapPoint(tapPos) == downArrowCol)
                {
                    transform.localScale = transform.localScale - new Vector3(0.02f, 0.02f, 0f);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //transform.position = new Vector3(tapPos.x, tapPos.y, 0);
            if (Physics2D.OverlapPoint(tapPos) == startCol)
            {
                gameStarted = true;
                upArrow.SetActive(false);
                downArrow.SetActive(false);
                start.SetActive(false);
                generator = true;
                GameObject temp = Instantiate(shopMap, transform.position, Quaternion.identity);
                temp.GetComponent<ShopMap>().player = player;
            }
            if (Physics2D.OverlapPoint(tapPos) == upArrowCol)
            {
                transform.localScale = transform.localScale + new Vector3(0.02f, 0.02f, 0f);
            }
            if (Physics2D.OverlapPoint(tapPos) == downArrowCol)
            {
                transform.localScale = transform.localScale - new Vector3(0.02f, 0.02f, 0f);
            }
        }

        while (generator && gameStarted)
        {
            Vector3 gemLoc = Random.insideUnitCircle * GetComponent<CircleCollider2D>().radius * transform.localScale.x;
            gemLoc.x += transform.position.x;
            gemLoc.y += transform.position.y;
            gemLoc.z = 0;
            if(Physics2D.OverlapPoint(gemLoc) != areaBlocked)
            {
                GameObject gem = Instantiate(gemMap, gemLoc, Quaternion.identity);
                gem.GetComponent<GemMap>().aop = GetComponent<AreaOfPlay>();
                gem.GetComponent<GemMap>().player = player;
                generator = false;
            }
        }
    }
    

}
