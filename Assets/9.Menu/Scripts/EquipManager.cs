using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public GameObject equipSlot;
    public GameObject[] merc;
    public int nowUseMercId;

    public void MercChange(int mercId)
    {
        nowUseMercId = mercId;
        if (equipSlot.activeSelf)
        {
            equipSlot.SetActive(false);
        }
        else
        {
            equipSlot.SetActive(true);
        }
        equipSlot.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = ItemDB.itemList[merc[mercId].GetComponent<ThisCard>().items[0]].itemSprite;
        equipSlot.transform.GetChild(1).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = ItemDB.itemList[merc[mercId].GetComponent<ThisCard>().items[1]].itemSprite;

    }
}
