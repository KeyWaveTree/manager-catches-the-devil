using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSkillDB : MonoBehaviour
{
    private StartBtn startBtn;
    private BattleManager battleManager;
    private SkillSoundManager skillSoundManager;

    public bool attackBan = false; //왕실대장군 변수 공격 1턴 봉인
    public bool contiAtack = true; //석양의 무법자 변수 연속공격
    public int tempTurn = 0; //불굴의 방패병 변수 턴
    public bool halfDamage = false; //창기병 변수 데미지 절반
    public static bool highPriest = false;//고위 성직자 변수 지정 카드 체력 회복 +6
    public bool breaking = false; //방랑검객 변수 적 공격력 -5
    public static bool invalid = false; //암살자 변수 공격 봉인
    public bool invincibility = false; //무도가 변수 1턴 동안 데미지 안받음

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
            case 1: //용사지망생 필드스킬
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
            case 2: //왕실대장군 필드스킬
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
            case 3: //야수사냥꾼 필드스킬
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
            case 4: //석양의 무법자 필드스킬
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
            case 5: //불굴의 방패병 필드스킬
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
            case 6: //창기병 필드스킬
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
            case 7: //화염마법사 필드스킬
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
            case 8: //깨우친 현자 필드스킬
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
            case 9: //초급 신관 필드스킬
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
            case 10: //고위성직자 필드스킬
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
            case 11: //방랑검객 필드스킬
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
            case 12: //암살자 필드스킬
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
            case 13: //발명가 필드스킬
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
            case 14: //무도가 필드스킬
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
            case 15: //불멸의 기사 필드스킬
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
