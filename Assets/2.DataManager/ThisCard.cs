using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ThisCard : MonoBehaviour
{
    public List<CardList> thisCard = new List<CardList>();
    public int thisId;

    public int id; //각 카드의 아이디
    public string cardName; //각 카드의 이름
    public string rating; //각 카드의 레어도
    public int damage; //각 카드의 공격력
    public int health; //각 카드의 체력
    public int armor; //각 카드의 방어도
    public string synergy; //각 카드의 시너지속성
    public int mana; //각 카드의 마나 
    public string fieldSkill; //각 카드의 필드스킬
    public string benchSkill; //각 카드의 벤치스킬
    public string job; // 각 카드의 직업
    public int[] items = new int[2]; //각 카드의 아이템
    public int restTime = 0; //각 카드의 휴식 시간, 3이 기본 휴식기간
    public int fieldCool; //각 카드의 필드스킬 쿨타임
    public int fieldMana; //각 카드의 필드스킬 사용 시 마나
    public int benchMana; //각 카드의 벤치스킬 사용 시 마나

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
