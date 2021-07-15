using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ThisCard : MonoBehaviour
{
    public List<CardList> thisCard = new List<CardList>();
    public int thisId;

    public int id; //�� ī���� ���̵�
    public string cardName; //�� ī���� �̸�
    public string rating; //�� ī���� ���
    public int damage; //�� ī���� ���ݷ�
    public int health; //�� ī���� ü��
    public int armor; //�� ī���� ��
    public string synergy; //�� ī���� �ó����Ӽ�
    public int mana; //�� ī���� ���� 
    public string fieldSkill; //�� ī���� �ʵ彺ų
    public string benchSkill; //�� ī���� ��ġ��ų
    public string job; // �� ī���� ����
    public int[] items = new int[2]; //�� ī���� ������
    public int restTime = 0; //�� ī���� �޽� �ð�, 3�� �⺻ �޽ıⰣ
    public int fieldCool; //�� ī���� �ʵ彺ų ��Ÿ��
    public int fieldMana; //�� ī���� �ʵ彺ų ��� �� ����
    public int benchMana; //�� ī���� ��ġ��ų ��� �� ����

    public TextMesh nameText;
    public TextMesh ratingText;
    public TextMesh damageText;
    public TextMesh healthText;
    public TextMesh jobText;
    public TextMesh manaText;
    public Sprite characterImage;
    public Sprite synergyRightImage;
    public Sprite synergyLeftImage;
    public Sprite backgroundImage;

    public SpriteRenderer thatCharacter;
    public SpriteRenderer thatSynergyRight;
    public SpriteRenderer thatSynergyLeft;
    public SpriteRenderer thatBackground;

    void Start()
    {
        if (this.gameObject.name.Substring(0, 4).Equals("Merc"))
        {
            for (int i = 0; i < 5; i++)
            {
                if (int.Parse(this.gameObject.name.Substring(4)) == i)
                {
                    thisCard[0] = CardDataBase.cardList[CardData.mercId[i]];
                    CardChange();
                    damage = CardData.mercATK[i];
                    health = CardData.mercHP[i];
                        for (int j = 0; j < 2; j++)
                        {
                            items[j] = CardData.items[i, j];
                        }
                }
            }
        }
        else if(this.gameObject.name == "InfoCard")
        {
            thisCard[0] = CardDataBase.cardList[CardRightClick.getCardId];
            CardChange();
        } else
        {
            thisCard[0] = CardDataBase.cardList[thisId];
            CardChange();
        }
    }

    void Update()
    {
        if (id != 0)
        {
            damageText.text = "" + damage;
            healthText.text = "" + health;
            ratingText.text = "" + rating;
            manaText.text = "" + mana;
        } else
        {
            damageText.text = "";
            healthText.text = "";
            manaText.text = "";
        }
    }

    public void CardChange()
    {
        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        rating = thisCard[0].rating;
        damage = thisCard[0].damage;
        health = thisCard[0].health;
        synergy = thisCard[0].synergy;
        mana = thisCard[0].mana;
        fieldSkill = thisCard[0].fieldSkill;
        benchSkill = thisCard[0].benchSkill;
        job = thisCard[0].job;
        fieldCool = thisCard[0].fieldCool;
        fieldMana = thisCard[0].fieldMana;
        benchMana = thisCard[0].benchMana;

        nameText.text = "" + cardName;
        ratingText.text = "" + rating;
        damageText.text = "" + damage;
        healthText.text = "" + health;
        manaText.text = "" + mana;

        characterImage = thisCard[0].characterImage;
        synergyRightImage = thisCard[0].synergyRightImage;
        synergyLeftImage = thisCard[0].synergyLeftImage;
        backgroundImage = thisCard[0].backgroundImage;

        thatCharacter.sprite = characterImage;
        thatBackground.sprite = backgroundImage;
        thatSynergyRight.sprite = synergyRightImage;
        thatSynergyLeft.sprite = synergyLeftImage;
    }
}
