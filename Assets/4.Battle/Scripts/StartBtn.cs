using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class StartBtn : MonoBehaviour
{
    public Sprite[] btnSprite = new Sprite[2];
    public GameObject cardPoint;
    public GameObject monsterPoint;

    private ThisCard attackCard;
    private Monster attackMonster;

    public BattleManager battleManager;
    private JobPassiveSkillDB jobPassiveDB;

    public GameObject guideText;
    private bool _isTexting = false;

    private void Start()
    {
        BattleReady();
        jobPassiveDB = GameObject.Find("SkillManager").GetComponent<JobPassiveSkillDB>();
    }

    private void OnMouseDown()
    {
        this.transform.GetComponent<SpriteRenderer>().sprite = btnSprite[1];
        if (battleManager._isBattle)
        {
            if (cardPoint.transform.childCount != 0)
            {
                attackCard = cardPoint.transform.GetChild(0).GetComponent<ThisCard>();
                attackMonster = monsterPoint.transform.GetChild(0).GetComponent<Monster>();
            }
            else
            {
                if (!_isTexting) StartCoroutine(GuideTextControl("용병이 배치되지 않았습니다."));
            }
        }
    }

    private void OnMouseUp()
    {
        this.transform.GetComponent<SpriteRenderer>().sprite = btnSprite[0];
        if (cardPoint.transform.childCount != 0)
        {
            if (battleManager._isBattle) StartCoroutine(BattleGo());
        }
        else
        {
            if (!_isTexting) StartCoroutine(GuideTextControl("용병이 배치되지 않았습니다."));
        }
    }

    IEnumerator GuideTextControl(String text)
    {
        guideText.transform.GetChild(0).GetComponent<Text>().text = text;
        _isTexting = true;
        guideText.SetActive(true);
        yield return new WaitForSeconds(1.0f); //양피지 펴지는 애니메이션 속도에 따라 다름 
        _isTexting = false;
        guideText.SetActive(false);

    }
    void BattleReady()
    {
        battleManager.TurnStart();
        print("턴 시작 휴식 -1, 쿨타임 -1, 마나 회복");
        battleManager.BattleReady();
        print("전투 준비 _isBattle = true, _isSkill = true, _isDrag = true");
        StartCoroutine(GuideTextControl("Trun : " + battleManager.turn + "\n 플레이어의 턴"));
    }

    IEnumerator BattleGo()
    {
        if (!FieldSkillDB.invalid)
        {
            battleManager.MonsterDefense();
            battleManager.AttackMonster(attackCard, attackMonster);
            battleManager._isBattle = false;
            battleManager._isDrag = false;
            battleManager._isSkill = false;
            jobPassiveDB.AssassinPassive(attackMonster); //암살자 패시브
            if (attackMonster._isMonsterDead && BenchSkillDB.madness) //기사 벤치스킬
            {
                for (int i = 0; i < 5; i++)
                {
                    if (battleManager.benchCard[i].GetComponent<ThisCard>().id == 15)
                    {
                        battleManager.benchCard[i].GetComponent<ThisCard>().damage += 3;
                        break;
                    }
                }
            }
            StartCoroutine(GuideTextControl("Trun : " + battleManager.turn + "\n 적의 턴"));
            yield return new WaitForSeconds(1.0f); //캐릭터의 공격 애니메이션 시간에 따라 바뀜. if문 사용해서 공격중인 캐릭터의 id를 받아와 처리
            if (cardPoint.transform.GetChild(0).GetComponent<ThisCard>().id == 4 && battleManager.fieldSkillDB.contiAtack)
            {
                battleManager.fieldSkillDB.contiAtack = false;
                cardPoint.transform.GetChild(0).GetComponent<CardBattle>().playerFieldCool = cardPoint.transform.GetChild(0).GetComponent<ThisCard>().fieldCool;
            }
            if (!attackMonster._isMonsterDead)
            {
                battleManager.PlayerDefense(attackCard);
                battleManager.DamagedCard(attackCard, attackMonster);             
            }
            else
            {
                StartCoroutine(MonsterDieChange());
            }
        }
        else
        {
            FieldSkillDB.invalid = false;
        }
        yield return new WaitForSeconds(1.0f);
        if (attackCard.id == 11) jobPassiveDB.SwordManPassive(attackCard);
        BattleReady();
    }

    IEnumerator MonsterDieChange()
    {
        yield return new WaitForSeconds(0.5f);
        monsterPoint.transform.GetChild(0).GetComponent<Monster>().monsterManager.MonsterStatusChange();
        monsterPoint.transform.GetChild(0).GetComponent<Monster>()._monster_attack = monsterPoint.transform.GetChild(0).GetComponent<ThisMonster>().monster_attack;
        monsterPoint.transform.GetChild(0).GetComponent<Monster>()._monster_hp = monsterPoint.transform.GetChild(0).GetComponent<ThisMonster>().monster_health;
    }
}
