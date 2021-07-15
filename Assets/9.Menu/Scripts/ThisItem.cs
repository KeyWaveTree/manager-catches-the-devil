using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThisItem : MonoBehaviour
{
    public int itemId = 0;
    public int itemPrice;
    public string itemName;
    public string itemDescrip;

    public TextMeshPro description;
    public TextMeshPro price;

    public GameObject checkText;

    public StoreManager storeManager;
    public GameObject choiceImage;
    public BuyBtn yesBtn;
    public GameObject alarm;

    float time = 0;
    bool delay = false;
    private int clickCnt = 2;
    public int gotchaID;
    void Update()
    {
        if (delay)
        {
            time += Time.deltaTime;
        }
    }
    private void OnMouseDown()
    {
        if (!alarm.activeSelf)
        {
            if (itemId != 0)
            {
                storeManager.ChoiceDisable(gotchaID);
                choiceImage.SetActive(true);
                clickCnt--;

                if (clickCnt == 1)
                {
                    time = 0.0f;
                    delay = true;
                    description.text = ItemDB.itemList[itemId].explanation;
                    price.text = "°¡°Ý : " + ItemDB.itemList[itemId].price + "°ñµå";
                }
                if (clickCnt == 0 && time <= 0.5f)
                {
                    choiceImage.SetActive(false);
                    StopCoroutine("Pulling");
                    clickCnt = 2;
                    yesBtn.GetItemId(gameObject);
                    checkText.SetActive(true);
                }
                else
                {

                    StartCoroutine("Pulling");
                }
            }
        }
    }
    IEnumerator Pulling()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        delay = false;
        clickCnt = 2;
    }

    public void ItemSold(int soldId)
    {
        itemId = 0;
        itemPrice = 0;
        itemName = "";
        itemDescrip = "";
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
