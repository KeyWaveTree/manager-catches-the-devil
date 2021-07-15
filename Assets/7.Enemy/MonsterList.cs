using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class MonsterList
{
    public int id; //�� ������ ���̵�
    public string monsterName; //�� ������ �̸�
    public string monsterTribe; //�� ������ ����
    public string rating; //�� ������ ���
    public int damage; //�� ������ ���ݷ�
    public int health; //�� ������ ü��
    public string fieldSkill; //�� ������ ��ų

    public Sprite characterImage;
    public Sprite backgroundImage;

    public MonsterList(int Id, string MonsterName, string MonsterTribe, string Rating, int Damage, int Health, string FieldSkill, Sprite CharacterImage, Sprite BackgroundImage)
    {
        id = Id;
        monsterName = MonsterName;
        monsterTribe = MonsterTribe;
        rating = Rating;
        damage = Damage;
        health = Health;
        fieldSkill = FieldSkill;

        characterImage = CharacterImage;
        backgroundImage = BackgroundImage;
    }
}
