using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchSkillDB : MonoBehaviour
{
    private StartBtn startBtn;
    private BattleManager battleManager;

    public static bool damaged = false; //�սǴ��屺 ����
    public static bool addDamage = false; //������ ������ ����
    public static bool insteadDamage = false; //â�⺴ ���� ��� �¾���
    public static bool manaSaving = false; //����ģ ���� ���� ���� ���� �Ʊ� ���� -1
    public static bool selectRest = false; //�ʱ� �Ű� ���� ������ �Ʊ� �޽� -1
    private int patienceCount = 0; //����˻� ���� 4ȸ ��� �� ü�� +20
    public static int anger = 0; //������ ���� ���ݷ� +1
    public static bool madness = false; //�Ҹ��� ��� ���� �̹� �� �� ��� �� �������� ���� ���ݷ� +3
    void Start()
    {
        startBtn = GameObject.Find("ActionBtn").GetComponent<StartBtn>();
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
    }
    public static void init()
    {
        damaged = false;
        addDamage = false;
        insteadDamage = false;
        manaSaving = false;
        selectRest = false;
        madness = false;
        JobPassiveSkillDB.skillUseCount = 0;
        FieldSkillDB.highPriest = false;
    }
    public void BenchSkillUse(int useCardId)
    {
        switch (useCardId) //id�� �޾Ƽ� ��ų�� ����Ѵ�.
        {
            case 1: //��������� ��ġ��ų
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.cardPoint.transform.childCount != 0)
                    {
                        startBtn.cardPoint.transform.GetChild(0).GetComponent<CardBattle>().playerAtk += 2;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana); //CardDB�� id�� �����Ͽ� �ʿ� ���� ������.
                    }
                }
                break;
            case 2: //�սǴ��屺 ��ġ��ų
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    damaged = true;
                    battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                }
                break;
            case 3: //�߼���ɲ� ��ġ��ų
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().Blind();
                    battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                }
                break;
            case 4: //������ ������ ��ġ��ų
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    addDamage = true;
                    battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                }
                break;
            case 5: //�ұ��� ���к� ��ġ��ų
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.cardPoint.transform.childCount != 0)
                    {
                        startBtn.cardPoint.transform.GetChild(0).GetComponent<CardBattle>().armor += 4;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                    }
                }
                break;
            case 6: //â�⺴ ��ġ��ų
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.cardPoint.transform.childCount != 0)
                    {
                        insteadDamage = true;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                    }
                }
                break;
            case 7: //ȭ�������� ��ġ��ų
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0)
                    {
                        startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_hp -= 1;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                    }
                }
                break;
            case 8: //����ģ ���� ��ġ��ų
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.cardPoint.transform.childCount != 0)
                    {
                        manaSaving = true;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                    }
                }
                break;
            case 9: //�ʱ� �Ű� ��ġ��ų
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    selectRest = true;
                    battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                }
                break;
            case 10: //���� ������ ��ġ��ų
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.cardPoint.transform.childCount != 0)
                    {
                        startBtn.cardPoint.transform.GetChild(0).GetComponent<CardBattle>().playerHp += 3;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                    }
                }
                break;
            case 11: //����˻� ��ġ��ų
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    patienceCount++;
                    if (patienceCount >= 4)
                    {
                        patienceCount = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            if (battleManager.benchCard[i].GetComponent<ThisCard>().id.Equals(useCardId))
                            {
                                battleManager.benchCard[i].GetComponent<CardBattle>().playerHp += 20;
                                break;
                            }
                        }
                    }
                    battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                }
                break;
            case 12: //���� �ڰ� ��ġ��ų
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0)
                    {
                        int random = Random.Range(0, 2); //50% Ȯ��
                        if (random == 1) startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_hp -= 4;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                    }
                }
                break;
            case 13: //�߸� ��ġ��ų
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.cardPoint.transform.childCount != 0)
                    {
                        startBtn.cardPoint.transform.GetChild(0).GetComponent<CardBattle>().playerAtk += 2;
                        startBtn.cardPoint.transform.GetChild(0).GetComponent<CardBattle>().armor += 2;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                    }
                }
                break;
            case 14://������ ��ġ��ų
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    anger = 1;
                    for (int i = 0; i < 5; i++)
                    {
                        if (battleManager.benchCard[i].GetComponent<ThisCard>().id == useCardId)
                        {
                            battleManager.benchCard[i].GetComponent<ThisCard>().damage += anger;
                            break;
                        }
                    }
                    battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                }
                break;
            case 15: //�Ҹ��� ��� ��ġ��ų
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0)
                    {
                        madness = true;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                    }
                }
                break;
            default:
                print("�׷��� ����");
                break;
        }
    }
}
