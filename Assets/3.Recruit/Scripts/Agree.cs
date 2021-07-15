using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Agree : MonoBehaviour
{
    public UI_control manager_UI;
    public Toggle bagBtn;

    private GameObject selectGotchaCard;
    void Update()
    {
        if (GotchaData._isArlam)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void Check()
    {
        GotchaData._isArlam = false;

        transform.GetChild(0).gameObject.SetActive(false);
        selectGotchaCard.GetComponent<ThisCard>().thisCard[0] = CardDataBase.cardList[0];
        selectGotchaCard.GetComponent<ThisCard>().CardChange();
        GotchaData.poolChance--;
        bagBtn.isOn = true;
        manager_UI.Bag();
        CardSelect._isSelect = true;
    }

    public void Refusal()
    {
        GotchaData._isArlam = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }
    
    public void CardId(int cardId)
    {
        CardSelect.selectCardId = cardId;
    }

    public void getGotchaCard(GameObject gotchaCard)
    {
        selectGotchaCard = gotchaCard;
    }
}
