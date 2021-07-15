using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class MonsterList
{
    public int id; //각 몬스터의 아이디
    public string monsterName; //각 몬스터의 이름
    public string monsterTribe; //각 몬스터의 종족
    public string rating; //각 몬스터의 계급
    public int damage; //각 몬스터의 공격력
    public int health; //각 몬스터의 체력
    public string fieldSkill; //각 몬스터의 스킬

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
