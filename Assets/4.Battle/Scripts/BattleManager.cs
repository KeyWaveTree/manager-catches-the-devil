using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public int turn = 0;
    public bool _isDrag = false; //true가 되야지 카드 드래그 가능.
    public bool _isBattle = false; //true가 되야지 공격가능.
    public bool _isSkill = false; //true가 되야지 필드, 벤치 스킬 사용 가능
    public int totalMana = 15;
    public int synergyCheck = 0;
    public GameObject[] benchCard;
    public TextMesh manaText;
    public SkillBtn[] skillBtn;
    private JobPassiveSkillDB jobPassiveDB;
    private StartBtn startBtn;
    public FieldSkillDB fieldSkillDB;

    private Animator monsterAttackAnim;
    private UIEventSC gameOverManager;
    private void Start()
    {
        startBtn = GameObject.Find("ActionBtn").GetComponent<StartBtn>();
        benchCard = GameObject.FindGameObjectsWithTag("Card");
        jobPassiveDB = GameObject.Find("SkillManager").GetComponent<JobPassiveSkillDB>();
        fieldSkillDB = GameObject.Find("SkillManager").GetComponent<FieldSkillDB>();
        monsterAttackAnim = GameObject.Find("MonsterAnimManager").GetComponent<Animator>();
        gameOverManager = GameObject.FindObjectOfType<UIEventSC>().GetComponent<UIEventSC>();
    }

    private void Update()
    {
        if (GameOver())
        {
            StartCoroutine(gameOverManager.GameOverEvent());
        }
    }
    bool GameOver()
    {
        int overCheck = 0;
        for (int i = 0; i < 5; i++)
        {
            if (benchCard[i].GetComponent<ThisCard>().id == 0)
            {
                overCheck++;
            }
        }
        if(overCheck == 5)
        {
            return true;
        } else
        {
            return false;
        }
    }
    public void AttackMonster(ThisCard attackCard, Monster damagedMonster)
    {
        StartCoroutine(AttackMove());
        jobPassiveDB.RangerPassive(damagedMonster);
        if (BenchSkillDB.anger > 0 && attackCard.id == 14) //무도가 벤치스킬
        {
            damagedMonster.monster_hp -= attackCard.damage;
            attackCard.damage -= BenchSkillDB.anger;
            BenchSkillDB.anger = 0;
        }
        else if (attackCard.id == 11) //검객 패시브 스킬
        {
            attackCard.GetComponent<CardBattle>().playerAtk += 5;
            damagedMonster.monster_hp -= attackCard.damage;
        }
        else //일반 공격
        {
            jobPassiveDB.WarriorPassive(attackCard);
            jobPassiveDB.MagePassive(attackCard);
            damagedMonster.monster_hp -= attackCard.damage + jobPassiveDB.Fighter();
            jobPassiveDB.fighterDamage++;
        }

    }
    public void DamagedCard(ThisCard damagedCard, Monster attackMonster)
    {
        if (!attackMonster._isStun && !fieldSkillDB.attackBan) //야수사냥꾼 벤치스킬, 왕실대장군 필드스킬
        {
            monsterAttackAnim.gameObject.SetActive(true);
            if (attackMonster.GetComponent<ThisMonster>().tribe.Equals("고블린")) monsterAttackAnim.Play("GoblinAttack", -1, 0);
            else if (attackMonster.GetComponent<ThisMonster>().tribe.Equals("언데드")) monsterAttackAnim.Play("UndeadAttack", -1, 0);

            if (damagedCard.GetComponent<CardBattle>().armor > 0) // 방어력이 있을 시
            {
                damagedCard.GetComponent<CardBattle>().armor -= attackMonster.monster_attack;
                if (damagedCard.GetComponent<CardBattle>().armor <= 0) //몬스터의 데미지가 방어력보다 높을 때
                {
                    if (fieldSkillDB.halfDamage && damagedCard.id == 6)
                    {
                        damagedCard.GetComponent<CardBattle>().playerHp -= Mathf.Abs(damagedCard.GetComponent<CardBattle>().armor) / 2;
                        damagedCard.GetComponent<CardBattle>().armor = 0;
                    }
                    else
                    {
                        if (!fieldSkillDB.invincibility)
                        {
                            damagedCard.GetComponent<CardBattle>().playerHp -= Mathf.Abs(damagedCard.GetComponent<CardBattle>().armor);
                            damagedCard.GetComponent<CardBattle>().armor = 0;
                        }
                        else
                        {
                            fieldSkillDB.invincibility = false;
                        }
                    }
                    fieldSkillDB.halfDamage = false;
                }
            }
            else
            {
                if (BenchSkillDB.insteadDamage) //창기병 벤치스킬
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (benchCard[i].GetComponent<ThisCard>().id == 6)
                        {
                            benchCard[i].GetComponent<CardBattle>().playerHp -= attackMonster.monster_attack;
                            benchCard[i].GetComponent<CardBattle>().playerHp = benchCard[i].GetComponent<ThisCard>().health;
                            break;
                        }
                    }
                }
                else //그냥 데미지 받기
                {
                    if (!fieldSkillDB.invincibility)
                    {
                        if (fieldSkillDB.halfDamage)
                        {
                            damagedCard.GetComponent<CardBattle>().playerHp -= attackMonster.monster_attack / 2;
                        }
                        else
                        {
                            damagedCard.GetComponent<CardBattle>().playerHp -= attackMonster.monster_attack;
                        }
                        fieldSkillDB.halfDamage = false;
                    }
                    else
                    {
                        fieldSkillDB.invincibility = false;
                    }
                }
            }
        }
        else
        {
            attackMonster._isStun = false;
            fieldSkillDB.attackBan = false;
            print("몬스터의 공격이 빗니감!");
        }
    }

    public void TurnStart()
    {
        turn += 1;
        BenchSkillDB.init();
        for (int i = 0; i < 5; i++)
        {
            if (benchCard[i].GetComponent<ThisCard>().id != 0 && benchCard[i].GetComponent<CardBattle>().playerAtk > 0)
            {
                benchCard[i].GetComponent<CardBattle>().playerAtk = 0;
            }
        }
        for (int i = 0; i < 5; i++)
        {
            skillBtn[i].skillUse = true;
        }
        for (int i = 0; i < 5; i++)
        {
            if (benchCard[i].GetComponent<ThisCard>().id != 0)
            {
                if (benchCard[i].GetComponent<CardBattle>().playerRest > 0)
                {
                    benchCard[i].GetComponent<CardBattle>().playerRest -= 1;
                }
                if (benchCard[i].GetComponent<CardBattle>().playerFieldCool > 0)
                {
                    benchCard[i].GetComponent<CardBattle>().playerFieldCool -= 1;
                }

                if (totalMana < 15)
                {
                    if (benchCard[i].GetComponent<CardBattle>().playerRest <= 0)
                    {
                        totalMana += benchCard[i].GetComponent<ThisCard>().mana;
                        manaText.text = totalMana + "";
                        if (totalMana > 15)
                        {
                            totalMana = 15;
                            manaText.text = totalMana + "";
                        }
                    }
                }
            }
        }
        if (fieldSkillDB.tempTurn > 0 && fieldSkillDB.tempTurn == turn)
        {
            startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_attack += 2;
        }
        if (fieldSkillDB.breaking)
        {
            startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_attack += 5;
            fieldSkillDB.breaking = false;
        }
    }


    public void ManaChange(int mana)
    {
        totalMana -= mana;
        manaText.text = totalMana + "";
    }

    public void BattleReady()
    {
        _isDrag = true;
        _isSkill = true;
        _isBattle = true;
    }

    public void MonsterDefense()
    {

    }

    public void PlayerDefense(ThisCard defenseCard)
    {
        jobPassiveDB.ShielderPassive(defenseCard);
    }

    public bool ReplaceBan()
    {
        int cardLength = 0; //id가 0이 아닌 카드 수
        int restCard = 0; //쉬고 있는 카드 수
        for (int i = 0; i < 5; i++)
        {
            if (benchCard[i].transform.parent.name == "Bench")
            {
                if (benchCard[i].GetComponent<ThisCard>().id != 0)
                {
                    cardLength++;
                    if (benchCard[i].GetComponent<CardBattle>().playerRest > 0)
                    {
                        restCard++;
                    }
                }
            }
        }
        bool banCheck = (cardLength == restCard) ? true : false;
        return banCheck;
    }
    public void AllCardRest()
    {
        int cardLength = 0; //id가 0이 아닌 카드 수
        int restCard = 0; //쉬고 있는 카드 수
        int[] minRestCard = { 0, 0, 0, 0, 0 }; //휴식 중인 카드 넣어둘 배열
        int min = 0; //휴식시간이 제일 적게 남은 턴

        for (int i = 0; i < 5; i++)
        {
            if (benchCard[i].GetComponent<ThisCard>().id != 0)
            {
                cardLength++;
                if (benchCard[i].GetComponent<CardBattle>().playerRest > 0)
                {
                    min = benchCard[i].GetComponent<CardBattle>().playerRest;
                    minRestCard[i] = benchCard[i].GetComponent<CardBattle>().playerRest;
                    restCard++;
                }
            }
        }

        if (cardLength == restCard)
        {
            print("다 휴식중임");
            for (int i = 0; i < minRestCard.Length; i++)
            {
                if (minRestCard[i] != 0)
                {
                    if (min > minRestCard[i])
                    {
                        min = minRestCard[i];
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (benchCard[i].GetComponent<ThisCard>().id != 0)
                {
                    if (benchCard[i].GetComponent<CardBattle>().playerRest == min)
                    {
                        benchCard[i].GetComponent<CardBattle>().playerRest = 0;
                    }
                }
            }
        }
    }

    IEnumerator AttackMove()
    {
        startBtn.cardPoint.transform.position = new Vector2(0f, 0.74f);
        yield return new WaitForSeconds(0.5f);
        startBtn.cardPoint.transform.position = new Vector2(-3.68f, 0.74f);
    }
}
