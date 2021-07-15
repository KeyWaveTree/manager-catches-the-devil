using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public GameObject[] product; //0왼쪽 1가운데 2오른쪽
    public ThisItem[] itemList;

    public TextMeshPro description;
    public TextMeshPro price;

    private void Start()
    {
        Renew();
    }
    public void Renew() //상품 갱신
    {
        int[] list = new int[product.Length];
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = Random.Range(1, ItemDB.itemList.Count);
            for (int j = 0; j < i; j++)
            {
                if (list[i] == list[j])
                {
                    i--;
                    break;
                }
            }
        }

        for (int i = 0; i < product.Length; i++)
        {
            product[i].GetComponent<SpriteRenderer>().sprite = ItemDB.itemList[list[i]].itemSprite;
            product[i].GetComponent<ThisItem>().itemId = ItemDB.itemList[list[i]].id;
        }
    }
    public void ChoiceDisable(int ID)
    {
        for (int i = 0; i < 3; i++)
        {
            if (itemList[i].gotchaID != ID)
            {
                itemList[i].choiceImage.SetActive(false);
            }
            else
            {
                description.text = "";
                price.text = "";
            }
        }
    }
}
