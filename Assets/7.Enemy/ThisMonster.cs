using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ThisMonster : MonoBehaviour
{
    public List<MonsterList> thisCard = new List<MonsterList>();

    public int monster_id;
    public string monster_name; // 몬스터 이름
    public string tribe; //종족
    public string monster_class; // A - A등급 ,  S - 중간보스 ,  S+ - 보스

    public int monster_health;
    public int monster_attack;

    public TextMesh monster_attackText;
    public TextMesh monster_healthText;
    public TextMesh monster_classText;
    public TextMesh monster_nameText;

    public SpriteRenderer thatCharacter;
    public SpriteRenderer thatBackground;

    void Update()
    {
        monster_attackText.text = monster_attack + "";
        monster_healthText.text = monster_health + "";
    }

    public void MonsterChange()
    {
        monster_id = thisCard[0].id;
        monster_name = thisCard[0].monsterName;
        tribe = thisCard[0].monsterTribe;
        monster_class = thisCard[0].rating;
        monster_health = thisCard[0].health;
        monster_attack = thisCard[0].damage;

        monster_attackText.text = thisCard[0].damage + "";
        monster_healthText.text = thisCard[0].health + "";
        monster_classText.text = thisCard[0].rating;
        monster_nameText.text = thisCard[0].monsterName;

        thatCharacter.sprite = thisCard[0].characterImage;
        thatBackground.sprite = thisCard[0].backgroundImage;
    }
}
