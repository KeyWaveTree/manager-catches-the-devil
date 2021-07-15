using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterBattleManager : MonoBehaviour
{
    public stage_move sm;
    public int[] monsterSequence = new int[5];
    public int monsterMiddleBoss;
    public int monsterBoss;

    public int monsterCount = 1;
    public GameObject monsterPoint;

    void Start()
    {
        sm = GameObject.FindObjectOfType<stage_move>();
        normalStageMonsterRandom();
        MonsterStatusChange();
    }

    void normalStageMonsterRandom()
    {
        if (sm.chapter == 1)
        {
            switch (sm.chapterChange.clear_stage)
            {
                case 0:
                    for (int i = 0; i < 5; i++)
                    {
                        if (i <= 2)
                        {
                            monsterSequence[i] = MonsterDB.monsterList[1].id;
                        }
                        else
                        {
                            monsterSequence[i] = MonsterDB.monsterList[2].id;
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i < 5; i++)
                    {
                        if (i < 2)
                        {
                            monsterSequence[i] = MonsterDB.monsterList[1].id;
                        }
                        else if (i < 4)
                        {
                            monsterSequence[i] = MonsterDB.monsterList[2].id;
                        }
                        else
                        {
                            monsterSequence[i] = MonsterDB.monsterList[3].id;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < 5; i++)
                    {
                        if (i < 2)
                        {
                            monsterSequence[i] = MonsterDB.monsterList[2].id;
                        }
                        else if (i < 4)
                        {
                            monsterSequence[i] = MonsterDB.monsterList[3].id;
                        }
                        else
                        {
                            monsterSequence[i] = MonsterDB.monsterList[4].id;
                        }
                    }
                    break;
                case 3:
                    monsterMiddleBoss = MonsterDB.monsterList[5].id;
                    break;
                case 4:
                    for (int i = 0; i < 5; i++)
                    {
                        if (i < 3)
                        {
                            monsterSequence[i] = MonsterDB.monsterList[3].id;
                        }
                        else
                        {
                            monsterSequence[i] = MonsterDB.monsterList[4].id;
                        }
                    }
                    break;
                case 5:
                    monsterBoss = MonsterDB.monsterList[6].id;
                    break;
            }
        } else if(sm.chapter == 2)
        {
            switch (sm.chapterChange.clear_stage)
            {
                case 0:
                    for (int i = 0; i < 5; i++)
                    {
                        if (i <= 2)
                        {
                            monsterSequence[i] = MonsterDB.monsterList[7].id;
                        }
                        else
                        {
                            monsterSequence[i] = MonsterDB.monsterList[8].id;
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i < 5; i++)
                    {
                        if (i < 2)
                        {
                            monsterSequence[i] = MonsterDB.monsterList[7].id;
                        }
                        else if (i < 4)
                        {
                            monsterSequence[i] = MonsterDB.monsterList[8].id;
                        }
                        else
                        {
                            monsterSequence[i] = MonsterDB.monsterList[9].id;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < 5; i++)
                    {
                        if (i < 2)
                        {
                            monsterSequence[i] = MonsterDB.monsterList[8].id;
                        }
                        else if (i < 4)
                        {
                            monsterSequence[i] = MonsterDB.monsterList[9].id;
                        }
                        else
                        {
                            monsterSequence[i] = MonsterDB.monsterList[10].id;
                        }
                    }
                    break;
                case 3:
                    monsterMiddleBoss = MonsterDB.monsterList[11].id;
                    break;
                case 4:
                    for (int i = 0; i < 5; i++)
                    {
                        if (i < 3)
                        {
                            monsterSequence[i] = MonsterDB.monsterList[9].id;
                        }
                        else
                        {
                            monsterSequence[i] = MonsterDB.monsterList[10].id;
                        }
                    }
                    break;
                case 5:
                    monsterBoss = MonsterDB.monsterList[12].id;
                    break;
            }
        }
    }

    public void MonsterStatusChange()
    {
        if (monsterPoint.GetComponent<Monster>()._isMonsterDead)
        {
            if(monsterCount > 4)
            {
                int[] goldList = { 500, 600, 700, 800, 900, 1000 };
                CardData.gold += Random.Range(0, goldList.Length);
                CardData.CardDeck();
                sm.chapterChange.clear_stage++;
                sm.moveSceneName = "Main";
                SceneManager.LoadScene("LoadingScene");
            } else
            {
                monsterPoint.GetComponent<Monster>()._isMonsterDead = false;
                monsterPoint.GetComponent<ThisMonster>().thisCard[0] = MonsterDB.monsterList[monsterSequence[monsterCount]];
                monsterPoint.GetComponent<ThisMonster>().MonsterChange();
                monsterCount++;
            }
        } else
        {
            if (sm.chapterChange.clear_stage == 3)
            {
                monsterPoint.GetComponent<ThisMonster>().thisCard[0] = MonsterDB.monsterList[monsterMiddleBoss];
                monsterPoint.GetComponent<ThisMonster>().MonsterChange();
                monsterCount = 5;
            }
            else if (sm.chapterChange.clear_stage == 5)
            {
                monsterPoint.GetComponent<ThisMonster>().thisCard[0] = MonsterDB.monsterList[monsterBoss];
                monsterPoint.GetComponent<ThisMonster>().MonsterChange();
                monsterCount = 5;
            } else
            {
                monsterPoint.GetComponent<ThisMonster>().thisCard[0] = MonsterDB.monsterList[monsterSequence[monsterCount]];
                monsterPoint.GetComponent<ThisMonster>().MonsterChange();
                monsterCount++;
            }
            
        }
    }
}
