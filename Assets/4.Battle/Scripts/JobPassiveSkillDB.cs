using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobPassiveSkillDB : MonoBehaviour
{
    private StartBtn startBtn;
    private BattleManager battleManager;

    public int ranger = 0;
    public static int skillUseCount = 0;
    public int fighterDamage = 0;

    int extraDamage = 0;
    private void Start()
    {
        startBtn = GameObject.Find("ActionBtn").GetComponent<StartBtn>();
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
    }

    public void WarriorPassive(ThisCard attack)
    {
        if (attack.job.Equals("전사"))
        {
            if (attack.rating.Equals("평범한")) attack.GetComponent<CardBattle>().playerAtk += 2;
            else if (attack.rating.Equals("특별한")) attack.GetComponent<CardBattle>().playerAtk += 3;
        }
    }
    public void RangerPassive(Monster monster)
    {
        bool check = false;
        for (int i = 0; i < 5; i++)
        {
            if (battleManager.benchCard[i].GetComponent<ThisCard>().job.Equals("궁수"))
            {
                check = true;
                break;
            }
            else
            {
                check = false;
            }
        }
        if (check)
        {
            ranger++;
            if (ranger == 3)
            {
                ranger = 0;
                monster.monster_hp -= 4;
            }
        }
    }

    public void ShielderPassive(ThisCard defense)
    {
        if (defense.job.Equals("방패병"))
        {
            if (defense.rating.Equals("평범한")) defense.GetComponent<CardBattle>().armor++;
            else if (defense.rating.Equals("특별한")) defense.GetComponent<CardBattle>().armor += 2;
        }
    }
    public void MagePassive(ThisCard mage)
    {
        if (startBtn.cardPoint.transform.GetChild(0).GetComponent<ThisCard>().job.Equals("마법사"))
        {
            if (startBtn.cardPoint.transform.GetChild(0).GetComponent<ThisCard>().rating.Equals("평범한"))
            {
                mage.GetComponent<CardBattle>().playerAtk += skillUseCount * 1;
            }
            else if (startBtn.cardPoint.transform.GetChild(0).GetComponent<ThisCard>().rating.Equals("특별한"))
            {
                mage.GetComponent<CardBattle>().playerAtk += skillUseCount * 1;
            }
        }
    }

    public void PriestPassive(ThisCard healCard)
    {
        bool check = false;
        for (int i = 0; i < 5; i++)
        {
            if (battleManager.benchCard[i].GetComponent<ThisCard>().job.Equals("사제"))
            {
                check = true;
                break;
            }
        }
        if (check)
        {
            healCard.GetComponent<CardBattle>().playerHp += 3;
        }
    }
    public void KnightPassive(ThisCard knight)
    {
        if (knight.id == 15)
        {
            string monsterRating = startBtn.monsterPoint.transform.GetChild(0).GetComponent<ThisMonster>().monster_class;
            if (monsterRating.Equals("S") || monsterRating.Equals("S+"))
            {
                knight.damage += 3;
                knight.health += 3;
            }
        }
    }
    public void SwordManPassive(ThisCard swordMan)
    {
        swordMan.GetComponent<CardBattle>().transform.parent = swordMan.GetComponent<CardBattle>().bench;
        swordMan.GetComponent<CardBattle>().transform.position = swordMan.GetComponent<CardBattle>().myPos;
        swordMan.GetComponent<CardBattle>().playerRest = swordMan.restTime;
        battleManager.AllCardRest();
        PriestPassive(swordMan);
    }
    public void AssassinPassive(Monster monster)
    {
        if (monster._isMonsterDead)
        {
            for (int i = 0; i < 5; i++)
            {
                if (battleManager.benchCard[i].GetComponent<ThisCard>().id == 12)
                {
                    battleManager.benchCard[i].GetComponent<ThisCard>().damage += 4;
                    break;
                }
            }
        }
    }
    public bool InventorPassive()
    {
        bool change = false;
        for (int i = 0; i < 5; i++)
        {
            if (battleManager.benchCard[i].GetComponent<ThisCard>().id == 13)
            {
                change = true;
                break;
            }
        }
        return change;
    }

    public int Fighter()
    {
        if(startBtn.cardPoint.transform.GetChild(0).GetComponent<ThisCard>().id == 14)
        {
            extraDamage = 1 * fighterDamage;
            return extraDamage;
        } else
        {
            fighterDamage = 0;
            extraDamage = 1 * fighterDamage;
            return extraDamage;
        }
    }
}
