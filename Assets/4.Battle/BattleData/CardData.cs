using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardData : MonoBehaviour
{
    public static CardData instance;
    public static int gold = 0; //µ·
    public static int[] mercId = new int[5];
    public static int[] mercATK = new int[5];
    public static int[] mercHP = new int[5];
    public static int[,] items = new int[5, 2];

    void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void CardDeck()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            Transform menu = GameObject.Find("MenuCanvas").transform.Find("Bag");
            for (int i = 0; i < 5; i++)
            {
                mercId[i] = menu.GetChild(i).GetComponent<ThisCard>().id;
                mercATK[i] = menu.GetChild(i).GetComponent<ThisCard>().damage;
                mercHP[i] = menu.GetChild(i).GetComponent<ThisCard>().health;
                for(int j = 0; j < 2; j++)
                {
                    items[i, j] = menu.GetChild(i).GetComponent<ThisCard>().items[j];
                }
                print(mercId[i]);
            }
        } else
        {
            for (int i = 0; i < 5; i++)
            {
                mercId[i] = GameObject.Find("Merc" + i).GetComponent<ThisCard>().id;
                mercATK[i] = GameObject.Find("Merc" + i).GetComponent<ThisCard>().damage;
                mercHP[i] = GameObject.Find("Merc" + i).GetComponent<ThisCard>().health;
                for (int j = 0; j < 2; j++)
                {
                    items[i, j] = GameObject.Find("Merc" + i).GetComponent<ThisCard>().items[j];
                }
                print(mercId[i]);
            }
        }
    }
}
