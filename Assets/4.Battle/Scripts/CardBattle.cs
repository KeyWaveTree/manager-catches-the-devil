using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using TMPro;

public delegate void HeroDeadHandler();
public delegate void WakeUp();
public delegate void Damaged();
public delegate void ExtraDamage();
public delegate void OverHeal();
public delegate void ArmorEvnet();

public class CardBattle : MonoBehaviour
{
    private BattleManager battleManager;
    private JobPassiveSkillDB jobPassiveDB;

    public bool cardDrop = false;

    private Vector2 initMousePos;
    public Vector2 myPos;

    private Synergy synergyManager;
    private Transform battlePoint;
    public Transform bench;
    private StartBtn startBtn;

    public TextMesh restTimeText;
    public GameObject armorIcon;
    private Animator deadAnim;

    public event HeroDeadHandler OnPlayerDie;
    public event WakeUp wakeUp;
    public event Damaged damagedPlayer;
    private event ExtraDamage extraDamage;
    private event OverHeal overHeal;
    private event ArmorEvnet armorEvent;

    int _playerHp;
    public int originalHp;
    public int playerHp
    {
        get { return _playerHp; }
        set
        {
            _playerHp = value;
            if (playerHp <= 0) OnPlayerDie();
            if (playerHp > 0) damagedPlayer();
            if (playerHp > originalHp) overHeal();
        }
    }
    int _extraAtk = 0;
    public int originalAtk = 0;
    public int playerAtk
    {
        get { return _extraAtk; }
        set
        {
            _extraAtk = value;

            if (playerAtk >= 0) extraDamage();
        }
    }
    int _playerRest = 0;
    public int playerRest
    {
        get { return _playerRest; }
        set
        {
            _playerRest = value;
            if (playerRest >= 0) wakeUp();
        }
    }
    public int playerFieldCool;
    int _armor = 0;
    public int armor
    {
        get { return _armor; }
        set
        {
            _armor = value;
            if (armor >= 0) armorEvent();
        }
    }
    private void Awake()
    {
        OnPlayerDie += new HeroDeadHandler(DeadHero);
        damagedPlayer += new Damaged(DamagedPlayer);
        damagedPlayer += new Damaged(HealthChange);
        overHeal += new OverHeal(OverHealBan);
        wakeUp += new WakeUp(PlayerWakeUp);
        extraDamage += new ExtraDamage(PlusDamage);
        armorEvent += new ArmorEvnet(ArmorImage);

        startBtn = GameObject.Find("ActionBtn").GetComponent<StartBtn>();
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        jobPassiveDB = GameObject.Find("SkillManager").GetComponent<JobPassiveSkillDB>();
        synergyManager = GameObject.Find("SynergyBar").GetComponent<Synergy>();
        battlePoint = GameObject.Find("BattleCardPoint").transform;
        deadAnim = GameObject.Find("DeadAnim").GetComponent<Animator>();
        bench = GameObject.Find("Bench").transform;
        armorIcon = transform.Find("Armor").gameObject;
        myPos = transform.position;

        playerRest = 0;
        playerFieldCool = 0;
    }
    private IEnumerator Start()
    {
        jobPassiveDB.KnightPassive(GetComponent<ThisCard>());
        yield return new WaitForSeconds(0.1f);
        originalAtk = GetComponent<ThisCard>().damage;
        originalHp = GetComponent<ThisCard>().health;
        _playerHp = GetComponent<ThisCard>().health;
    }
    private void OnMouseUp()
    {
        //SetLayerRecursively(this.transform, "Default");
        if (battleManager._isDrag && !battleManager.ReplaceBan())
        {
            if (cardDrop && battlePoint.childCount == 0)
            {
                transform.parent = battlePoint;
                transform.localPosition = new Vector2(0, 0);
                battleManager._isDrag = false;
                battleManager._isBattle = true;
                if (battleManager.turn > 1 && jobPassiveDB.InventorPassive())
                {
                    playerAtk += 3;
                    armor += 3;
                }
                jobPassiveDB.fighterDamage = 0;
            }
            else
            {
                if (transform.parent.name.Equals("BattleCardPoint"))
                {
                    transform.parent = bench; //벤치로 돌려줌
                    transform.position = myPos;//벤치에서 자기 위치로 감
                    playerRest = GetComponent<ThisCard>().restTime;
                    jobPassiveDB.PriestPassive(GetComponent<ThisCard>());
                    print("벤치로 돌아감");
                }
                else
                {
                    this.transform.position = myPos;
                }
            }
        }
    }

    private void OnMouseDrag()
    {
        if (battleManager._isDrag && playerRest == 0 && !battleManager.ReplaceBan())
        {
            if (this.gameObject.GetComponent<ThisCard>().id != 0)
            {
                //SetLayerRecursively(this.transform, "Attack");

                Vector2 mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 worldObjectPosition = Camera.main.ScreenToWorldPoint(mouseDragPosition);

                Vector2 diffPos = worldObjectPosition - initMousePos;

                initMousePos = Input.mousePosition;
                initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);

                this.transform.position =
                    new Vector2(Mathf.Clamp(this.transform.position.x + diffPos.x, myPos.x + -0.1f, myPos.x + 0.1f),
                    Mathf.Clamp(this.transform.position.y + diffPos.y, myPos.y, myPos.y + 1.5f));
            }
        }
    }

    public void OnMouseDown()
    {
        if (battleManager._isDrag && !battleManager.ReplaceBan())
        {
            cardDrop = false;
            initMousePos = Input.mousePosition;
            initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);
        }
        if (BenchSkillDB.selectRest)
        {
            playerRest -= 1;
            BenchSkillDB.selectRest = false;
        }
        if (FieldSkillDB.highPriest)
        {
            playerHp += 6;
            FieldSkillDB.highPriest = false;
        }
    }

    void DeadHero()
    {
        deadAnim.gameObject.SetActive(true);
        deadAnim.Play("PlayerDead", -1, 0);
        GetComponent<ThisCard>().health = 0;
        GetComponent<ThisCard>().items[0] = 0;
        GetComponent<ThisCard>().items[1] = 0;
        Invoke("BenchBack", 0.5f);
    }
    void OverHealBan()
    {
        if (originalHp < playerHp)
        {
            _playerHp = originalHp;
            GetComponent<ThisCard>().health = originalHp;
        }
    }
    void DamagedPlayer()
    {
        if (BenchSkillDB.damaged)
        {
            startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_attack -= 1;
            print("적의 공격력 깍음 " + startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_attack);
            BenchSkillDB.damaged = false;
        }
    }
    void HealthChange()
    {
        if (originalHp > playerHp)
        {
            GetComponent<ThisCard>().health = playerHp;
        }
    }
    void PlayerWakeUp()
    {
        if (playerRest > 0)
        {
            restTimeText.text = playerRest + "";
            restTimeText.gameObject.SetActive(true);
        }
        else if (playerRest <= 0)
        {
            restTimeText.text = playerRest + "";
            restTimeText.gameObject.SetActive(false);
            print(gameObject.name + "의 휴식이 끝났다!");
        }
    }

    void PlusDamage()
    {
        GetComponent<ThisCard>().damage = originalAtk + playerAtk;
        print(playerAtk + "공격력 강화");
    }

    public void FieldSkillGo()
    {
        if (transform.parent.name.Equals("BattleCardPoint") && battleManager._isSkill)
        {
            if (GetComponent<ThisCard>().id == 4 && playerFieldCool <= 0)
            {
                battleManager.fieldSkillDB.contiAtack = true;
                if (battleManager.fieldSkillDB.contiAtack)
                {
                    transform.parent.GetComponent<SkillUse>().FieldSkillUse();
                }
            }
            else if (playerFieldCool <= 0)
            {
                transform.parent.GetComponent<SkillUse>().FieldSkillUse();
                playerFieldCool = GetComponent<ThisCard>().fieldCool;
            }
            else
            {
                print("필드스킬 쿨타임 중 : " + playerFieldCool);
            }
        }
    }

    void ArmorImage()
    {
        if (armor > 0)
        {
            armorIcon.transform.GetChild(0).GetComponent<TextMeshPro>().text = armor.ToString();
            armorIcon.SetActive(true);
        }
        else
        {
            armorIcon.transform.GetChild(0).GetComponent<TextMeshPro>().text = 0.ToString();
            armorIcon.SetActive(false);
        }
    }

    void BenchBack()
    {
        GetComponent<ThisCard>().thisCard[0] = CardDataBase.cardList[0];
        GetComponent<ThisCard>().CardChange();

        transform.parent = bench; //벤치로 돌려줌
        transform.position = myPos;//벤치에서 자기 위치로 감
        battleManager.AllCardRest();

        OnPlayerDie -= new HeroDeadHandler(DeadHero);
        OnPlayerDie -= new HeroDeadHandler(DamagedPlayer);
        wakeUp -= new WakeUp(PlayerWakeUp);
        StartCoroutine(synergyManager.plz());
        print("플레이어 주금");
    }

    public void SetLayerRecursively(Transform trans, string name)
    {
        trans.gameObject.layer = LayerMask.NameToLayer(name);
        foreach(Transform child in trans)
        {
            SetLayerRecursively(child, name);
        }
    }
}
