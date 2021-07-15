using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemList
{
    public int id; //�������� ���̵�
    public int price; //�������� ����
    public string itemName; //�������� �̸�
    public string explanation; //�������� ����
    public Sprite itemSprite; //�������� �̹���
    public ItemList(int Id, int Price, string ItemName, string Explanation, Sprite ItemSprite)
    {
        id = Id;
        price = Price;
        itemName = ItemName;
        explanation = Explanation;
        itemSprite = ItemSprite;
    }
}
