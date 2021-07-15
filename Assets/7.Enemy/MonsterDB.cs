using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDB : MonoBehaviour
{
    public static List<MonsterList> monsterList = new List<MonsterList>();

    //각 몬스터의 아이디/ 각 몬스터의 이름/ 각 몬스터의 종족 /각 몬스터의 계급 /각 몬스터의 공격력/ 각 몬스터의 체력 /각 몬스터의 스킬 / 몬스터 이미지/ 몬스터 백그라운드

    void Awake()
    {
        monsterList.Add(new MonsterList(0, "", "", "", 0, 0, "", Resources.Load<Sprite>("Character/DefaultCard"), Resources.Load<Sprite>("CardBackGround")));
        //고블린
        monsterList.Add(new MonsterList(1, "나약한 고블린", "고블린", "D", 15, 30, "", Resources.Load<Sprite>("Monster/Goblin"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(2, "근육질 고블린", "고블린", "C", 15, 40, "", Resources.Load<Sprite>("Monster/Goblin"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(3, "포악한 고블린", "고블린", "B", 20, 50, "", Resources.Load<Sprite>("Monster/Goblin"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(4, "정예 고블린", "고블린", "A", 25, 85, "이 스테이지 동안 죽은 아군 고블린 하나당 공격력 + 1", Resources.Load<Sprite>("Monster/Goblin_A"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(5, "고블린 부족장", "고블린", "S", 42, 160, "공격할 때 방어하는 용병이 가지고 있는 아이템 하나당 공격력 +3 (최대6)", Resources.Load<Sprite>("Monster/Goblin_MidBoss"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(6, "고블린 족장", "고블린", "S+", 43, 220, "체력이 일정 이하로 감소 할 시 공격력 상승", Resources.Load<Sprite>("Monster/Goblin_Boss"), Resources.Load<Sprite>("CardBackGround")));
        //언데드
        monsterList.Add(new MonsterList(7, "겁먹은 해골병사", "언데드", "D", 20, 70, "", Resources.Load<Sprite>("Monster/Undead"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(8, "분노한 해골병사", "언데드", "C", 20, 80, "", Resources.Load<Sprite>("Monster/Undead"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(9, "거대한 해골병사", "언데드", "B", 25, 90, "", Resources.Load<Sprite>("Monster/Undead"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(10, "해골군함", "언데드", "A", 27, 140, "죽으면 공격력 10 체력 1로 부활하고 해당 턴을 이어간다.", Resources.Load<Sprite>("Monster/Undead_A"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(11, "해골 군단장", "언데드", "S", 38, 210, "자신을 죽인 적에게 매 턴마다 체력이 2씩 깎이는 저주를 건다.", Resources.Load<Sprite>("Monster/Undead_MidBoss"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(12, "엘더 리치", "언데드", "S+", 40, 320, "체력이 0이하로 떨어지면 5턴 동안 체력 0상태로 죽지 않고 버틴다.", Resources.Load<Sprite>("Character/DefaultCard"), Resources.Load<Sprite>("CardBackGround")));
    }
}