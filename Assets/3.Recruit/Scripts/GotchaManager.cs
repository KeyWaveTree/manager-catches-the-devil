using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GotchaManager : MonoBehaviour
{
    public CardGotcha[] cardList;
    public RaycastHit2D hit;

    public GameObject fieldSkillText;
    public GameObject benchSkillText;

    int cnt = 1;
    List<int> cardArray = new List<int>();
    public GameObject[] poolCard;
    private void Start()
    {
        cardArray.Add(0);
        for (int i = 1; i < 16; i++)
        {
            cardArray.Add(i);
        }
        for (int i = 0; i < 5; i++)
        {
            cardArray.Remove(poolCard[i].GetComponent<ThisCard>().id);
        }
    }
    public void ChoiceDisable(int ID)
    {
        for (int i = 0; i < 3; i++)
        {
            if (cardList[i].gotchaID != ID)
            {
                cardList[i].choiceImage.SetActive(false);
            }
            else
            {
                fieldSkillText.GetComponent<Text>().text = "출전 스킬 : " + cardList[i].GetComponent<ThisCard>().fieldSkill;
                benchSkillText.GetComponent<Text>().text = "벤치 스킬 : " + cardList[i].GetComponent<ThisCard>().benchSkill;
            }
        }
    }
    public void reroll() //카드 재뽑기
    {
        if (GotchaData.poolToken != 0)
        {
            fieldSkillText.GetComponent<Text>().text = "출전 스킬 : ";
            benchSkillText.GetComponent<Text>().text = "벤치 스킬 : ";

            int[] list = new int[cardList.Length];
            for (int i = 0; i < list.Length; i++)
            {
                int random = UnityEngine.Random.Range(1, 16);
                if (cardArray.Contains(random))
                {
                    list[i] = random;
                    cardArray.Remove(random);
                }
                else
                {
                    if (cardArray.Count <= 1)
                    {
                        list[i] = 0;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
            for (int i = 0; i < cardList.Length; i++)
            {
                cardList[i].GetComponent<ThisCard>().thisCard[0] = CardDataBase.cardList[list[i]];
                cardList[i].GetComponent<ThisCard>().CardChange();
                cardList[i].GetComponent<CardGotcha>().choiceImage.SetActive(false);
            }
            GotchaData.poolToken--;
        }
    }

    private void OnEnable()
    {
        cardList = FindObjectsOfType<CardGotcha>();
        if (cnt == 1)
        {
            Invoke("reroll", 0.001f);
            cnt--;
        }
    }
}
