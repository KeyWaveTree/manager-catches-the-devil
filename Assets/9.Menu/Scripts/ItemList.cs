using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemList
{
    public int id; //아이템의 아이디
    public int price; //아이템의 가격
    public string itemName; //아이템의 이름
    public string explanation; //아이템의 설명
    public Sprite itemSprite; //아이템의 이미지
    public ItemList(int Id, int Price, string ItemName, string Explanation, Sprite ItemSprite)
    {
        id = Id;
        price = Price;
        itemName = ItemName;
        explanation = Explanation;
        itemSprite = ItemSprite;
    }
}
