using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGotcha : MonoBehaviour
{
    public GameObject choiceImage;
    public GotchaManager gotchaManager;
    public SoundManager soundManager;

    float time = 0;
    bool delay = false;
    public int clickCnt = 2;
    public int gotchaID;

    public GameObject alarm;
    [SerializeField]
    private Agree agreeManager;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    void Update()
    {
        if (delay)
        {
            time += Time.deltaTime;
        }
    }

    private void OnMouseDown()
    {
        if (!alarm.activeSelf)
        {
            if (GotchaData.poolChance != 0)
            {
                if (GetComponent<ThisCard>().id != 0)
                {
                    gotchaManager.ChoiceDisable(gotchaID);
                    choiceImage.SetActive(true);
                    clickCnt--;

                    if (clickCnt == 1)
                    {
                        time = 0.0f;
                        delay = true;

                        CardSelect.selectCardId = this.gameObject.GetComponent<ThisCard>().id;
                        soundManager.chooseCharId = true;
                    }
                    if (clickCnt == 0 && time <= 0.5f)
                    {
                        choiceImage.SetActive(false);
                        StopCoroutine("Pulling");
                        clickCnt = 2;
                        GotchaData._isArlam = true;
                        agreeManager.getGotchaCard(this.gameObject);
                        CardSelect.selectCardId = this.gameObject.GetComponent<ThisCard>().id;
                    }
                    else
                    {
                        StartCoroutine("Pulling");
                    }
                }
            }
        }
    }
    IEnumerator Pulling()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        CardSelect.selectCardId = 0;
        delay = false;
        clickCnt = 2;
    }
}
