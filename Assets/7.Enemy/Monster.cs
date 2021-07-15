using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void AddDamage();
public delegate void MonsterDead();
public delegate void ConnectHp();
public delegate void ConnectAtk();

public class Monster : MonoBehaviour
{
    public event AddDamage addDamage;
    public event MonsterDead monsterDead;
    public event ConnectHp connectHp;
    public event ConnectAtk connectAtk;

    private Animator deadAnim;
    public int _monster_hp;
    public int monster_hp
    {
        get { return _monster_hp; }
        set
        {
            _monster_hp = value;
            if (monster_hp >= 0 || monster_hp <= 0) connectHp();
            if (monster_hp > 0 && BenchSkillDB.addDamage) addDamage();
            if (monster_hp <= 0) monsterDead();
        }
    }

    public int _monster_attack;
    public int monster_attack
    {
        get { return _monster_attack; }
        set
        {
            _monster_attack = value;
            if (monster_attack > 0) connectAtk();
        }
    }

    public bool _isStun = false;
    public bool _isMonsterDead = false;
    private BattleManager battleManager;
    public MonsterBattleManager monsterManager;

    private void Start()
    {
        addDamage += new AddDamage(DoubleDamage);
        monsterDead += new MonsterDead(DieMonster);
        connectHp += new ConnectHp(SynchroHp);
        connectAtk += new ConnectAtk(SynchroAtk);

        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterBattleManager>();
        _monster_attack = GetComponent<ThisMonster>().monster_attack;
        _monster_hp = GetComponent<ThisMonster>().monster_health;
        deadAnim = GameObject.Find("DeadAnim").GetComponent<Animator>();
    }

    public void Blind()
    {
        int prob = Random.Range(0, 20); //확률 계산 5% 확률로 감나빗.
        if (prob == 4) //4가 나올 시 5%의 확률로 인한 감나빗이 발동한다.
        {
            _isStun = true;
        }
        else
        {
            _isStun = false;
        }
    }

    void DoubleDamage()
    {
        _monster_hp -= 2;
        GetComponent<ThisMonster>().monster_health = _monster_hp;
        print("추가데미지를 입음!");
    }
    void DieMonster()
    {
        deadAnim.gameObject.SetActive(true);
        if (monster_hp < 0)
        {  
            deadAnim.Play("Monster_OverKill", -1, 0);
        }
        else if(monster_hp == 0)
        {
            deadAnim.Play("Monster_Dead", -1, 0);
        }
        Invoke("MonsterDieWait", 0.5f);
    }
    void SynchroHp()
    {
        if(monster_hp < 0)
        {
            GetComponent<ThisMonster>().monster_health = 0;
        } else
        {
            GetComponent<ThisMonster>().monster_health = monster_hp;
        }
    }

    void SynchroAtk()
    {
        GetComponent<ThisMonster>().monster_attack = this.monster_attack;
    }

    void MonsterDieWait()
    {
        _isMonsterDead = true;
    }
}
