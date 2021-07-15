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
                if (!_isTexting) StartCoroutine(GuideTextControl("�뺴�� ��ġ���� �ʾҽ��ϴ�."));
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
            if (!_isTexting) StartCoroutine(GuideTextControl("�뺴�� ��ġ���� �ʾҽ��ϴ�."));
        }
    }

    IEnumerator GuideTextControl(String text)
    {
        guideText.transform.GetChild(0).GetComponent<Text>().text = text;
        _isTexting = true;
        guideText.SetActive(true);
        yield return new WaitForSeconds(1.0f); //������ ������ �ִϸ��̼� �ӵ��� ���� �ٸ� 
        _isTexting = false;
        guideText.SetActive(false);

    }
    void BattleReady()
    {
        battleManager.TurnStart();
        print("�� ���� �޽� -1, ��Ÿ�� -1, ���� ȸ��");
        battleManager.BattleReady();
        print("���� �غ� _isBattle = true, _isSkill = true, _isDrag = true");
        StartCoroutine(GuideTextControl("Trun : " + battleManager.turn + "\n �÷��̾��� ��"));
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
            jobPassiveDB.AssassinPassive(attackMonster); //�ϻ��� �нú�
            if (attackMonster._isMonsterDead && BenchSkillDB.madness) //��� ��ġ��ų
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
            StartCoroutine(GuideTextControl("Trun : " + battleManager.turn + "\n ���� ��"));
            yield return new WaitForSeconds(1.0f); //ĳ������ ���� �ִϸ��̼� �ð��� ���� �ٲ�. if�� ����ؼ� �������� ĳ������ id�� �޾ƿ� ó��
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
