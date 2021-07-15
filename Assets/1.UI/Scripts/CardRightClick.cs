using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardRightClick : MonoBehaviour
{
    public GameObject infoCard;
    public static int getCardId;

    private bool infoCardActive = false;
    GameObject informationCard;
    int[] items = new int[2];
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<ThisCard>() != null && hit.collider.gameObject.GetComponent<ThisCard>().id != 0)
                {
                    if (!infoCardActive)
                    {
                        infoCardActive = true;
                        getCardId = hit.transform.gameObject.GetComponent<ThisCard>().id;
                        for(int i = 0; i < 2; i++)
                        {
                            items[i] = hit.transform.gameObject.GetComponent<ThisCard>().items[i];
                        }
                        SelectCard();
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider == null || hit.collider != null)
            {
                infoCardActive = false;
                Destroy(informationCard);
            }
        }
    }
    void SelectCard()
    {
        informationCard = Instantiate(infoCard, new Vector3(-4.1f, 0f, -1f), Quaternion.identity) as GameObject; //position x: -4.1 scale x: 2.2, y2.2
        informationCard.name = "InfoCard";

        for (double i = 1; i < 2.2; i += 0.1 * Time.deltaTime)
        {
            informationCard.transform.localScale = new Vector3((float)i, (float)i, 1);
        }
        informationCard.transform.GetChild(4).Find("Panel").GetChild(0).GetComponent<Text>().text += CardDataBase.cardList[getCardId].fieldSkill;
        informationCard.transform.GetChild(4).Find("Panel").GetChild(1).GetComponent<Text>().text += CardDataBase.cardList[getCardId].benchSkill;

        informationCard.transform.GetChild(4).Find("Item1").GetComponent<Image>().sprite = ItemDB.itemList[items[0]].itemSprite;
        informationCard.transform.GetChild(4).Find("Item2").GetComponent<Image>().sprite = ItemDB.itemList[items[1]].itemSprite;
    }
}
