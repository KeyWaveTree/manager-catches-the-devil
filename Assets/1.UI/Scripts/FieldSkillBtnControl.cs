using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSkillBtnControl : MonoBehaviour
{
    public GameObject FSBtn;
    private GameObject cardPoint;

    private void Start()
    {
        cardPoint = GameObject.Find("BattleCardPoint").gameObject;
    }
    void Update()
    {
        if(cardPoint.transform.childCount != 0)
        {
            FSBtn.SetActive(true);
        } else
        {
            FSBtn.SetActive(false);
        }
    }
}
