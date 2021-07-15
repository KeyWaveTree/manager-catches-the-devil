using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSkillDB : MonoBehaviour
{
    private StartBtn startBtn;
    private BattleManager battleManager;
    private SkillSoundManager skillSoundManager;

    public bool attackBan = false; //�սǴ��屺 ���� ���� 1�� ����
    public bool contiAtack = true; //������ ������ ���� ���Ӱ���
    public int tempTurn = 0; //�ұ��� ���к� ���� ��
    public bool halfDamage = false; //â�⺴ ���� ������ ����
    public static bool highPriest = false;//���� ������ ���� ���� ī�� ü�� ȸ�� +6
    public bool breaking = false; //����˰� ���� �� ���ݷ� -5
    public static bool invalid = false; //�ϻ��� ���� ���� ����
    public bool invincibility = false; //������ ���� 1�� ���� ������ �ȹ���

    public Animator fieldSkillAnim;

    private void Start()
    {
        startBtn = GameObject.Find("ActionBtn").GetComponent<StartBtn>();
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        skillSoundManager = GameObject.Find("SkillSoundManager").GetComponent<SkillSoundManager>();
        fieldSkillAnim = GameObject.Find("FieldSkillAnim").GetComponent<Animator>();
    }

    public void FieldSkill(int skillUseId)
    {
        fieldSkillAnim.gameObject.SetActive(true);
        switch (skillUseId)
        {
            case 1: //��������� �ʵ彺ų
                if (battleManager.totalMana >= CardDataBase.cardList[skillUseId].fieldMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0) startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_hp -= 3;
                    skillSoundManager.PlaySkillVoice(skillUseId);
                    fieldSkillAnim.Play("NoobWarrior", -1, 0);
                    
                    if (BenchSkillDB.manaSaving && CardDataBase.cardList[skillUseId].fieldMana != 0)
                    {
                        battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana - 1);
                    }
                    else
                    {
                        battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana);
                    }
                }
                break;
            case 2: //�սǴ��屺 �ʵ彺ų
                if (battleManager.totalMana >= CardDataBase.cardList[skillUseId].fieldMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0) attackBan = true;
                    skillSoundManager.PlaySkillVoice(skillUseId);
                    fieldSkillAnim.Play("Royal", -1, 0);
                    if (BenchSkillDB.manaSaving && CardDataBase.cardList[skillUseId].fieldMana != 0)
                    {
                        battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana - 1);
                    }
                    else
                    {
                        battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana);
                    }
                }
                break;
            case 3: //�߼���ɲ� �ʵ彺ų
                if (battleManager.totalMana >= CardDataBase.cardList[skillUseId].fieldMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0)
                    {
                        int random = Random.Range(0, 4);
                        skillSoundManager.PlaySkillVoice(skillUseId);
                        fieldSkillAnim.Play("BeastHunterAni", -1, 0);
                        if (random == 3) startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_hp -= 10;
                        if (BenchSkillDB.manaSaving && CardDataBase.cardList[skillUseId].fieldMana != 0)
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana - 1);
                        }
                        else
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana);
                        }
                    }
                }
                break;
            case 4: //������ ������ �ʵ彺ų
                if (battleManager.totalMana >= CardDataBase.cardList[skillUseId].fieldMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0)
                    {
                        skillSoundManager.PlaySkillVoice(skillUseId);
                        fieldSkillAnim.Play("GunMan", -1, 0);
                        startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_hp -= 3;
                        if (BenchSkillDB.manaSaving && CardDataBase.cardList[skillUseId].fieldMana != 0)
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana - 1);
                        }
                        else
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana);
                        }
                    }
                }
                break;
            case 5: //�ұ��� ���к� �ʵ彺ų
                if (battleManager.totalMana >= CardDataBase.cardList[skillUseId].fieldMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0)
                    {
                        skillSoundManager.PlaySkillVoice(skillUseId);
                        fieldSkillAnim.Play("ShiledMan", -1, 0);
                        startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_attack -= 2;
                        tempTurn = battleManager.turn + 5;
                        if (BenchSkillDB.manaSaving && CardDataBase.cardList[skillUseId].fieldMana != 0)
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana - 1);
                        }
                        else
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana);
                        }
                    }
                }
                break;
            case 6: //â�⺴ �ʵ彺ų
                if (battleManager.totalMana >= CardDataBase.cardList[skillUseId].fieldMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0)
                    {
                        skillSoundManager.PlaySkillVoice(skillUseId);
                        fieldSkillAnim.Play("Lancer", -1, 0);
                        halfDamage = true;
                        if (BenchSkillDB.manaSaving && CardDataBase.cardList[skillUseId].fieldMana != 0)
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana - 1);
                        }
                        else
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana);
                        }
                    }
                }
                break;
            case 7: //ȭ�������� �ʵ彺ų
                if (battleManager.totalMana >= CardDataBase.cardList[skillUseId].fieldMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0)
                    {
                        skillSoundManager.PlaySkillVoice(skillUseId);
                        fieldSkillAnim.Play("FireMage", -1, 0);
                        startBtn.cardPoint.transform.GetChild(0).GetComponent<CardBattle>().playerHp -= 2;
                        startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_hp -= 6;
                        if (BenchSkillDB.manaSaving && CardDataBase.cardList[skillUseId].fieldMana != 0)
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana - 1);
                        }
                        else
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana);
                        }
                    }
                }
                break;
            case 8: //����ģ ���� �ʵ彺ų
                if (battleManager.totalMana >= CardDataBase.cardList[skillUseId].fieldMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0)
                    {
                        skillSoundManager.PlaySkillVoice(skillUseId);
                        fieldSkillAnim.Play("OldMage", -1, 0);
                        startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_hp -= 50;
                        if (BenchSkillDB.manaSaving && CardDataBase.cardList[skillUseId].fieldMana != 0)
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana - 1);
                        }
                        else
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana);
                        }
                    }
                }
                break;
            case 9: //�ʱ� �Ű� �ʵ彺ų
                if (battleManager.totalMana >= CardDataBase.cardList[skillUseId].fieldMana)
                {
                    skillSoundManager.PlaySkillVoice(skillUseId);
                    fieldSkillAnim.Play("NoobPriest", -1, 0);
                    for (int i = 0; i < 5; i++)
                    {
                        if (battleManager.benchCard[i].GetComponent<ThisCard>().id != 0)
                        {
                            battleManager.benchCard[i].GetComponent<CardBattle>().playerHp += 3;
                        }
                    }
                    if (BenchSkillDB.manaSaving && CardDataBase.cardList[skillUseId].fieldMana != 0)
                    {
                        battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana - 1);
                    }
                    else
                    {
                        battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana);
                    }
                }
                break;
            case 10: //���������� �ʵ彺ų
                if (battleManager.totalMana >= CardDataBase.cardList[skillUseId].fieldMana)
                {
                    skillSoundManager.PlaySkillVoice(skillUseId);
                    fieldSkillAnim.Play("HighPriest", -1, 0);
                    highPriest = true;
                    if (BenchSkillDB.manaSaving && CardDataBase.cardList[skillUseId].fieldMana != 0)
                    {
                        battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana - 1);
                    }
                    else
                    {
                        battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana);
                    }
                }
                break;
            case 11: //����˰� �ʵ彺ų
                if (battleManager.totalMana >= CardDataBase.cardList[skillUseId].fieldMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0)
                    {
                        skillSoundManager.PlaySkillVoice(skillUseId);
                        fieldSkillAnim.Play("Yasuo", -1, 0);
                        startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_hp -= 15;
                        startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_attack -= 5;
                        breaking = true;
                        if (BenchSkillDB.manaSaving && CardDataBase.cardList[skillUseId].fieldMana != 0)
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana - 1);
                        }
                        else
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana);
                        }
                    }
                }
                break;
            case 12: //�ϻ��� �ʵ彺ų
                if (battleManager.totalMana >= CardDataBase.cardList[skillUseId].fieldMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0)
                    {
                        skillSoundManager.PlaySkillVoice(skillUseId);
                        fieldSkillAnim.Play("AssassinAni", -1, 0);
                        startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_hp -= 10;
                        invalid = true;
                        if (BenchSkillDB.manaSaving && CardDataBase.cardList[skillUseId].fieldMana != 0)
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana - 1);
                        }
                        else
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana);
                        }
                    }
                }
                break;
            case 13: //�߸� �ʵ彺ų
                if (battleManager.totalMana >= CardDataBase.cardList[skillUseId].fieldMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0)
                    {
                        skillSoundManager.PlaySkillVoice(skillUseId);
                        fieldSkillAnim.Play("Inventor", -1, 0);
                        startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_hp -= 3;
                        startBtn.cardPoint.transform.GetChild(0).GetComponent<CardBattle>().armor += 5;
                        if (BenchSkillDB.manaSaving && CardDataBase.cardList[skillUseId].fieldMana != 0)
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana - 1);
                        }
                        else
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana);
                        }
                    }
                }
                break;
            case 14: //������ �ʵ彺ų
                if (battleManager.totalMana >= CardDataBase.cardList[skillUseId].fieldMana)
                {
                    if (startBtn.cardPoint.transform.childCount != 0)
                    {
                        skillSoundManager.PlaySkillVoice(skillUseId);
                        fieldSkillAnim.Play("FIghter", -1, 0);
                        invincibility = true;
                        if (BenchSkillDB.manaSaving && CardDataBase.cardList[skillUseId].fieldMana != 0)
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana - 1);
                        }
                        else
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana);
                        }
                    }
                }
                break;
            case 15: //�Ҹ��� ��� �ʵ彺ų
                if (battleManager.totalMana >= CardDataBase.cardList[skillUseId].fieldMana)
                {
                    if (startBtn.cardPoint.transform.childCount != 0)
                    {
                        skillSoundManager.PlaySkillVoice(skillUseId);
                        fieldSkillAnim.Play("Knight", -1, 0);
                        if (startBtn.cardPoint.transform.GetChild(0).GetComponent<CardBattle>().originalAtk >
                            startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_attack)
                        {
                            startBtn.cardPoint.transform.GetChild(0).GetComponent<CardBattle>().playerAtk += 10;
                        }
                        if (BenchSkillDB.manaSaving && CardDataBase.cardList[skillUseId].fieldMana != 0)
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana - 1);
                        }
                        else
                        {
                            battleManager.ManaChange(CardDataBase.cardList[skillUseId].fieldMana);
                        }
                    }
                }
                break;
        }
    }
}
