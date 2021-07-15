using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGuide : MonoBehaviour
{
    public GameObject card;
    public GameObject gotchaCanvas;

    public void CardState(GameObject card)
    {
        this.card = card;
    }
    public void ChangeYes()
    {
        if (CardSelect._isSelect)
        {
            card.GetComponent<ThisCard>().thisCard[0] = CardDataBase.cardList[CardSelect.selectCardId];
            card.GetComponent<ThisCard>().CardChange();
            RemoveCardData();
            CardSelect._isSelect = false;
            gotchaCanvas.SetActive(false);
        }
    }

    public void ChangeNo()
    {
        gotchaCanvas.SetActive(false);
    }

    public void RemoveCardData()
    {
        card = null;
    }
}
