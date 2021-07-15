using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FieldSkillBtn : MonoBehaviour
{
    private GameObject cardPoint;
    public Sprite emptyBtnSprite;
    public Sprite activeBtnSprite;

    private TextMeshPro fieldCoolText;

    private void Start()
    {
        cardPoint = GameObject.Find("BattleCardPoint").gameObject;
        fieldCoolText = transform.GetChild(0).GetComponent<TextMeshPro>();
    }
    private void Update()
    {
        if (cardPoint.transform.childCount != 0)
        {
            if (cardPoint.transform.GetChild(0).GetComponent<CardBattle>().playerFieldCool <= 0)
            {
                fieldCoolText.gameObject.SetActive(false);
                GetComponent<SpriteRenderer>().sprite = activeBtnSprite;
            }
            else
            {
                fieldCoolText.gameObject.SetActive(true);
                fieldCoolText.text = cardPoint.transform.GetChild(0).GetComponent<CardBattle>().playerFieldCool + "";
                GetComponent<SpriteRenderer>().sprite = emptyBtnSprite;
            }
        }
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.6f);
    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        cardPoint.transform.GetChild(0).GetComponent<CardBattle>().FieldSkillGo();
    }
}
