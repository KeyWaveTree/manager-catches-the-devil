using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUse : MonoBehaviour
{
    private FieldSkillDB fieldSkillManager;
    private StartBtn startBtn;
    private void Start()
    {
        fieldSkillManager = GameObject.Find("SkillManager").GetComponent<FieldSkillDB>();
        startBtn = GameObject.Find("ActionBtn").GetComponent<StartBtn>();
    }

    public void FieldSkillUse()
    {
        fieldSkillManager.FieldSkill(transform.GetChild(0).GetComponent<ThisCard>().id);
        JobPassiveSkillDB.skillUseCount++;
    }
     
    public void FieldEvent()
    {
        startBtn.cardPoint.transform.GetChild(0).GetComponent<CardBattle>().FieldSkillGo();
    }
}
