using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage_id : MonoBehaviour
{

    public int stage_num;
    private stage_move stageManger;

    public Sprite[] stageSprite;
    private UIEventSC iEventSC;
    public GameObject[] cards;
    
    private void Start()
    {
        stageManger = GameObject.FindObjectOfType<stage_move>();
        iEventSC = GameObject.FindObjectOfType<UIEventSC>();

        if (stageManger.chapterChange.clear_stage >= stage_num)
        {
            GetComponent<SpriteRenderer>().sprite = stageSprite[1];
        } else
        {
            GetComponent<SpriteRenderer>().sprite = stageSprite[0];
        }
        if(stageManger.chapter == 2)
        {
            transform.GetChild(0).transform.GetComponent<TextMesh>().text = 2 + "-" + stage_num;
        }
    }

    public void OnMouseDown()
    {
        if (!UI_control._isMenuIn) {
            if (stageManger.chapterChange.clear_stage == 0 && stageManger.chapter == 1)
            {
                int count = 0;
                for(int i = 0; i < 5; i++)
                {
                    if(cards[i].GetComponent<ThisCard>().id != 0)
                    {
                        count++;
                    }
                }
                if(count >= 3)
                {
                    CardData.CardDeck();
                    stageManger.moveSceneName = "Chapter" + stageManger.chapter;
                    iEventSC.nextStep = 5;
                    SceneManager.LoadScene("LoadingScene");
                } else
                {
                    iEventSC.nextStep = 4;
                    iEventSC.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
            else if (stageManger.chapterChange.clear_stage == stage_num - 1)
            {
                CardData.CardDeck();
                stageManger.moveSceneName = "Chapter" + stageManger.chapter;
                SceneManager.LoadScene("LoadingScene");
            }
        }
    }

}
