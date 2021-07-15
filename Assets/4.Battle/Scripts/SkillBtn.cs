using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBtn : MonoBehaviour
{
    public GameObject connectCard;
    private BattleManager battleManager;
    private BenchSkillDB benchSkill;
    private Synergy synergyManager;
    public bool skillUse = true;
    private void Start()
    {
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        benchSkill = GameObject.Find("SkillManager").GetComponent<BenchSkillDB>();
        synergyManager = GameObject.Find("SynergyBar").GetComponent<Synergy>();
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.6f);
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        if (battleManager._isSkill && connectCard.GetComponent<CardBattle>().playerRest <= 0)
        {
            if (connectCard.transform.parent.name.Equals("Bench") && skillUse)
            {
                benchSkill.BenchSkillUse(connectCard.GetComponent<ThisCard>().id);
                skillUse = false;
                JobPassiveSkillDB.skillUseCount++;
                if (connectCard.GetComponent<ThisCard>().synergy.Equals(synergyManager.synergySelect)) synergyManager.synergyUse++;
            }
            else
            {
                Debug.Log("해당 카드는 출전 중입니다.");
            }
        }
    }
}
