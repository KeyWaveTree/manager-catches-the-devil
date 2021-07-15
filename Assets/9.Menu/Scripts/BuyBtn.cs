using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBtn : MonoBehaviour
{
    GameObject tempItem;
    public GameObject WaringText;
    public InventoryManager invenManager;
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.6f);
    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        if (gameObject.name.Equals("No"))
        {
            No();
        } else if (gameObject.name.Equals("Yes"))
        {
            Yes();
        }
    }

    public void GetItemId(GameObject item)
    {
        tempItem = item;
    }
    void Yes()
    {
        if (ItemDB.itemList[tempItem.GetComponent<ThisItem>().itemId].price > CardData.gold)
        {
            WaringText.SetActive(true);
            Invoke("textMove", 0.5f);
        } else
        {
            invenManager.AddInven(tempItem.GetComponent<ThisItem>().itemId);
            transform.parent.gameObject.SetActive(false);
            CardData.gold -= ItemDB.itemList[tempItem.GetComponent<ThisItem>().itemId].price;
            tempItem.GetComponent<ThisItem>().ItemSold(tempItem.GetComponent<ThisItem>().itemId);
        }
    }

    void No()
    {
        transform.parent.gameObject.SetActive(false);
    }

    void textMove()
    {
        WaringText.SetActive(false);
        transform.parent.gameObject.SetActive(false);
    }
}
