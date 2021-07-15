using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterRemain : MonoBehaviour
{
    public MonsterBattleManager monsterManager;

    private void Update()
    {
        if(monsterManager.sm.chapterChange.clear_stage == 3)
        {
            GetComponent<Text>().text = 0 + "";
        } else if (monsterManager.sm.chapterChange.clear_stage == 5)
        {
            GetComponent<Text>().text = 0 + "";
        } else
        {
            GetComponent<Text>().text = 5 - monsterManager.monsterCount + "";
        }    
    }
}
