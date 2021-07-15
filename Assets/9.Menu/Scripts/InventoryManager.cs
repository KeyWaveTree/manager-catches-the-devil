using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] invenSlot;

    public void AddInven(int itemId)
    {
        for (int i = 0; i < invenSlot.Length; i++)
        {
            if (!invenSlot[i].GetComponent<ItemDrag>()._isUse)
            {
                invenSlot[i].GetComponent<ItemDrag>()._isUse = true;
                invenSlot[i].GetComponent<SpriteRenderer>().sprite = ItemDB.itemList[itemId].itemSprite;
                invenSlot[i].GetComponent<ItemDrag>().itemId = itemId;
                break;
            }
        }
    }
}
