using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDB : MonoBehaviour
{
    public static List<MonsterList> monsterList = new List<MonsterList>();

    //�� ������ ���̵�/ �� ������ �̸�/ �� ������ ���� /�� ������ ��� /�� ������ ���ݷ�/ �� ������ ü�� /�� ������ ��ų / ���� �̹���/ ���� ��׶���

    void Awake()
    {
        monsterList.Add(new MonsterList(0, "", "", "", 0, 0, "", Resources.Load<Sprite>("Character/DefaultCard"), Resources.Load<Sprite>("CardBackGround")));
        //���
        monsterList.Add(new MonsterList(1, "������ ���", "���", "D", 15, 30, "", Resources.Load<Sprite>("Monster/Goblin"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(2, "������ ���", "���", "C", 15, 40, "", Resources.Load<Sprite>("Monster/Goblin"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(3, "������ ���", "���", "B", 20, 50, "", Resources.Load<Sprite>("Monster/Goblin"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(4, "���� ���", "���", "A", 25, 85, "�� �������� ���� ���� �Ʊ� ��� �ϳ��� ���ݷ� + 1", Resources.Load<Sprite>("Monster/Goblin_A"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(5, "��� ������", "���", "S", 42, 160, "������ �� ����ϴ� �뺴�� ������ �ִ� ������ �ϳ��� ���ݷ� +3 (�ִ�6)", Resources.Load<Sprite>("Monster/Goblin_MidBoss"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(6, "��� ����", "���", "S+", 43, 220, "ü���� ���� ���Ϸ� ���� �� �� ���ݷ� ���", Resources.Load<Sprite>("Monster/Goblin_Boss"), Resources.Load<Sprite>("CardBackGround")));
        //�𵥵�
        monsterList.Add(new MonsterList(7, "�̸��� �ذ񺴻�", "�𵥵�", "D", 20, 70, "", Resources.Load<Sprite>("Monster/Undead"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(8, "�г��� �ذ񺴻�", "�𵥵�", "C", 20, 80, "", Resources.Load<Sprite>("Monster/Undead"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(9, "�Ŵ��� �ذ񺴻�", "�𵥵�", "B", 25, 90, "", Resources.Load<Sprite>("Monster/Undead"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(10, "�ذ���", "�𵥵�", "A", 27, 140, "������ ���ݷ� 10 ü�� 1�� ��Ȱ�ϰ� �ش� ���� �̾��.", Resources.Load<Sprite>("Monster/Undead_A"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(11, "�ذ� ������", "�𵥵�", "S", 38, 210, "�ڽ��� ���� ������ �� �ϸ��� ü���� 2�� ���̴� ���ָ� �Ǵ�.", Resources.Load<Sprite>("Monster/Undead_MidBoss"), Resources.Load<Sprite>("CardBackGround")));
        monsterList.Add(new MonsterList(12, "���� ��ġ", "�𵥵�", "S+", 40, 320, "ü���� 0���Ϸ� �������� 5�� ���� ü�� 0���·� ���� �ʰ� ��ƾ��.", Resources.Load<Sprite>("Character/DefaultCard"), Resources.Load<Sprite>("CardBackGround")));
    }
}