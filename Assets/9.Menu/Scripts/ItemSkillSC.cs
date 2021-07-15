using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSkillSC : MonoBehaviour
{
    private void Start()
    {
        for(int i = 0; i < 2; i++)
        {
            if(GetComponent<ThisCard>().items[i] != 0)
            {
                ItemSkill(GetComponent<ThisCard>().items[i]);
            }
            
        }
    }
    void ItemSkill(int itemNum)
    {
        switch (itemNum)
        {
            case 1: //Å¬·Î¹ö
                GetComponent<ThisCard>().damage += 6;
                break;
            case 2:
                GetComponent<CardBattle>().playerHp += 40;
                break;
            case 3:
                GetComponent<CardBattle>().playerHp += 30;
                break;
            case 4:
                GetComponent<ThisCard>().health += 20;
                break;
            case 5:
                GetComponent<ThisCard>().damage += 3;
                GetComponent<CardBattle>().playerHp += 3;
                break;
            case 6:
                GetComponent<ThisCard>().damage += 5;
                break;
            case 7:
                GetComponent<CardBattle>().armor += 10;
                break;
            case 8:
                GetComponent<CardBattle>().armor += 8;
                break;
            case 9:
                GetComponent<ThisCard>().damage += 3;
                break;
            case 10:
                GetComponent<CardBattle>().playerHp += 10;
                break;
            case 11:
                GetComponent<ThisCard>().damage += 10;
                GetComponent<CardBattle>().playerHp -= 10;
                break;
            case 12:
                GetComponent<ThisCard>().damage += 15;
                break;
            case 13:
                GetComponent<ThisCard>().damage += 7;
                GetComponent<CardBattle>().armor += 7;
                break;
            case 14:
                GetComponent<CardBattle>().playerHp += 15;
                break;
            case 15:
                GetComponent<ThisCard>().damage += 13;
                break;
            case 16:
                GetComponent<ThisCard>().damage += 7;
                GetComponent<CardBattle>().playerHp += 7;
                break;
            case 17:
                break;
            case 18:
                GetComponent<ThisCard>().damage += 5;
                GetComponent<CardBattle>().armor += 3;
                break;
            case 19:
                GetComponent<ThisCard>().damage += 10;
                break;
            case 20:
                GetComponent<ThisCard>().damage += 20;
                GetComponent<CardBattle>().playerHp -= 20;
                break;
        }
    }
}