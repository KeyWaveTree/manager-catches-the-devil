using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchSkillDB : MonoBehaviour
{
    private StartBtn startBtn;
    private BattleManager battleManager;

    public static bool damaged = false; //왕실대장군 변수
    public static bool addDamage = false; //석양의 무법자 변수
    public static bool insteadDamage = false; //창기병 변수 대신 맞아줌
    public static bool manaSaving = false; //깨우친 현자 변수 출전 중인 아군 마나 -1
    public static bool selectRest = false; //초급 신관 변수 지정한 아군 휴식 -1
    private int patienceCount = 0; //방랑검사 변수 4회 사용 시 체력 +20
    public static int anger = 0; //무도가 변수 공격력 +1
    public static bool madness = false; //불멸의 기사 변수 이번 턴 적 사망 시 스테이지 동안 공격력 +3
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
        switch (useCardId) //id를 받아서 스킬을 사용한다.
        {
            case 1: //용사지망생 벤치스킬
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.cardPoint.transform.childCount != 0)
                    {
                        startBtn.cardPoint.transform.GetChild(0).GetComponent<CardBattle>().playerAtk += 2;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana); //CardDB의 id로 접속하여 필요 마나 가져옴.
                    }
                }
                break;
            case 2: //왕실대장군 벤치스킬
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    damaged = true;
                    battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                }
                break;
            case 3: //야수사냥꾼 벤치스킬
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().Blind();
                    battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                }
                break;
            case 4: //석양의 무법자 벤치스킬
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    addDamage = true;
                    battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                }
                break;
            case 5: //불굴의 방패병 벤치스킬
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.cardPoint.transform.childCount != 0)
                    {
                        startBtn.cardPoint.transform.GetChild(0).GetComponent<CardBattle>().armor += 4;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                    }
                }
                break;
            case 6: //창기병 벤치스킬
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.cardPoint.transform.childCount != 0)
                    {
                        insteadDamage = true;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                    }
                }
                break;
            case 7: //화염마법사 벤치스킬
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0)
                    {
                        startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_hp -= 1;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                    }
                }
                break;
            case 8: //깨우친 현자 벤치스킬
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.cardPoint.transform.childCount != 0)
                    {
                        manaSaving = true;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                    }
                }
                break;
            case 9: //초급 신관 벤치스킬
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    selectRest = true;
                    battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                }
                break;
            case 10: //고위 성직자 벤치스킬
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.cardPoint.transform.childCount != 0)
                    {
                        startBtn.cardPoint.transform.GetChild(0).GetComponent<CardBattle>().playerHp += 3;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                    }
                }
                break;
            case 11: //방랑검사 벤치스킬
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
            case 12: //밤의 자객 벤치스킬
                if (battleManager.totalMana >= CardDataBase.cardList[useCardId].benchMana)
                {
                    if (startBtn.monsterPoint.transform.childCount != 0)
                    {
                        int random = Random.Range(0, 2); //50% 확률
                        if (random == 1) startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_hp -= 4;
                        battleManager.ManaChange(CardDataBase.cardList[useCardId].benchMana);
                    }
                }
                break;
            case 13: //발명가 벤치스킬
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
            case 14://무도가 벤치스킬
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
            case 15: //불멸의 기사 벤치스킬
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
                print("그런건 없다");
                break;
        }
    }
}
