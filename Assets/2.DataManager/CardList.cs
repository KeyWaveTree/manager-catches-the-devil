using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class CardList
{
    public int id; //�� ī���� ���̵�
    public string cardName; //�� ī���� �̸�
    public string rating; //�� ī���� ���
    public int damage; //�� ī���� ���ݷ�
    public int health; //�� ī���� ü��
    public string synergy; //�� ī���� �ó����Ӽ�
    public int mana; //�� ī���� ���� 
    public string fieldSkill; //�� ī���� �ʵ彺ų
    public string benchSkill; //�� ī���� ��ġ��ų
    public string job; // �� ī���� ����
    public int fieldCool; //�� ī���� �ʵ� ��ų ��Ÿ��
    public int fieldMana; //�� ī���� �ʵ� ���� �Һ�.
    public int benchMana; //�� ī���� ��ġ ���� �Һ�.

    public Sprite characterImage;
    public Sprite synergyRightImage;
    public Sprite synergyLeftImage;
    public Sprite backgroundImage;

    public CardList(int Id, string CardName, string Rating, int Damage, int Health,string Synergy, 
        int Mana, string FieldSkill, string BenchSkill, string Job, Sprite CharacterImage, 
        Sprite SynergyRightImage, Sprite SynergyLeftImage, Sprite BackgroundImage, int FieldCool, int FieldMana, int BenchMana)
    {
        id = Id;
        cardName = CardName;
        rating = Rating;
        damage = Damage;
        health = Health;
        synergy = Synergy;
        mana = Mana;
        fieldSkill = FieldSkill;
        benchSkill = BenchSkill;
        job = Job;
        fieldCool = FieldCool;
        fieldMana = FieldMana;
        benchMana = BenchMana;

        characterImage = CharacterImage;
        synergyRightImage = SynergyRightImage;
        synergyLeftImage = SynergyLeftImage;
        backgroundImage = BackgroundImage;
    }
}
