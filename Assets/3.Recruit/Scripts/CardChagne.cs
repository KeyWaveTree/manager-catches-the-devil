using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardChagne : MonoBehaviour
{
    public ChangeGuide changeGuide;
    public int[] itemId = new int[2];
    EquipManager equipManager;

    private void Start()
    {
        equipManager = GameObject.Find("InvenManager").GetComponent<EquipManager>();
    }
    private void OnMouseUp()
    {
        if (!changeGuide.gotchaCanvas.activeSelf)
        {
            if (CardSelect._isSelect)
            {
                if (transform.GetComponent<ThisCard>().id.Equals(0)) //용병이 없는 공간일 시
                {
                    transform.GetComponent<ThisCard>().thisCard[0] = CardDataBase.cardList[CardSelect.selectCardId];
                    transform.GetComponent<ThisCard>().CardChange();
                    changeGuide.RemoveCardData();
                    CardSelect._isSelect = false;
                }
                else //용병이 있는 공간일 시
                {
                    changeGuide.gotchaCanvas.SetActive(true);
                    changeGuide.CardState(this.gameObject);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (GetComponent<ThisCard>().id != 0)
        {
            equipManager.MercChange(int.Parse(gameObject.name.Substring(4)));
        }
    }
}
