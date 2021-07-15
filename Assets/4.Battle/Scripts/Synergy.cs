using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void SynergyStack();
public class Synergy : MonoBehaviour
{
    public event SynergyStack synergyStackEvent;
    private SpriteRenderer synergy;

    static public int synergyStack = 0;

    public Sprite[] synergy_blue;
    public Sprite[] synergy_red;
    public Sprite[] synergy_yellow;
    public Sprite[] synergy_green;
    public Sprite[] synergy_white;
    Sprite _default;

    public ThisCard[] cards;
    public string[] synergyTemp;
    public string synergySelect;

    public bool p = false;

    int _synergyUse = 0;
    public int synergyUse
    {
        get { return _synergyUse; }
        set
        {
            _synergyUse = value;
            if (synergyUse >= 0) synergyStackEvent();
        }
    }
    private StartBtn startBtn;
    private BattleManager battleManager;
    void Start()
    {
        synergyStackEvent += new SynergyStack(SwapSynergy);
        synergy = transform.GetChild(0).GetComponent<SpriteRenderer>();
        synergy.sprite = _default;

        synergyTemp = new string[cards.Length];
        startBtn = GameObject.Find("ActionBtn").GetComponent<StartBtn>();
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();

        StartCoroutine(plz());
    }

    public void SwapSynergy()
    {
        if (p)
        {
            if (synergyUse > 3)
            {
                synergyUse = 0;
                SynergySkill();
            }
            else
            {
                switch (synergySelect)
                {
                    case "빨간색":
                        synergy.sprite = synergy_red[synergyUse];
                        break;
                    case "회색":
                        synergy.sprite = synergy_white[synergyUse];
                        break;
                    case "파란색":
                        synergy.sprite = synergy_blue[synergyUse];
                        break;
                    case "초록색":
                        synergy.sprite = synergy_green[synergyUse];
                        break;
                    case "노란색":
                        synergy.sprite = synergy_yellow[synergyUse];
                        break;
                }
            }
        }
        else
        {
            synergyUse = 0;
        }
    }

    bool CheckSynergy()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            synergyTemp[i] = cards[i].synergy;
        }
        bool flag = false;
        string[] checkSynergyArray = { "빨간색", "회색", "초록색", "노란색", "파란색" };
        int synergyCheck = 0; //시너지가 3개 이상 있는지 확인
        for (int i = 0; i < checkSynergyArray.Length; i++)
        {
            synergyCheck = 0;
            string tempSynergy = checkSynergyArray[i];
            for (int j = 0; j < cards.Length; j++)
            {
                if (synergyTemp[j] == tempSynergy)
                {
                    synergyCheck++;
                    if (synergyCheck >= 3)
                    {
                        synergySelect = synergyTemp[j];
                        flag = true;
                        break;
                    }
                }
            }
            if (flag) break;
        }
        bool chooseSynergy = synergyCheck >= 3 ? true : false;
        return chooseSynergy;
    }

    public IEnumerator plz()
    {
        yield return new WaitForSeconds(0.1f);
        p = CheckSynergy();
        _synergyUse = 0;
        if (p)
        {
            switch (synergySelect)
            {
                case "빨간색":
                    synergy.sprite = synergy_red[0];
                    break;
                case "회색":
                    synergy.sprite = synergy_white[0];
                    break;
                case "파란색":
                    synergy.sprite = synergy_blue[0];
                    break;
                case "초록색":
                    synergy.sprite = synergy_green[0];
                    break;
                case "노란색":
                    synergy.sprite = synergy_yellow[0];
                    break;
            }
        }
    }

    void SynergySkill()
    {
        switch (synergySelect)
        {
            case "빨간색":
                if (startBtn.cardPoint.transform.childCount != 0)
                {
                    startBtn.cardPoint.transform.GetChild(0).GetComponent<CardBattle>().playerAtk += 7;
                }
                break;
            case "회색":
                if (startBtn.monsterPoint.transform.childCount != 0)
                {
                    startBtn.monsterPoint.transform.GetChild(0).GetComponent<Monster>().monster_hp -= 8;
                }
                break;
            case "파란색":
                if (battleManager.totalMana < 15)
                {
                    battleManager.totalMana += 5;
                    if (battleManager.totalMana > 15) battleManager.totalMana = 15;
                    battleManager.manaText.text = battleManager.totalMana + "";
                }
                break;
            case "초록색":
                if (startBtn.cardPoint.transform.childCount != 0)
                {
                    startBtn.cardPoint.transform.GetChild(0).GetComponent<CardBattle>().armor += 5;
                }
                break;
            case "노란색":
                for (int i = 0; i < 5; i++)
                {
                    if (battleManager.benchCard[i].GetComponent<ThisCard>().id != 0)
                    {
                        battleManager.benchCard[i].GetComponent<ThisCard>().health += 3;
                    }
                }
                break;
        }
    }
}
