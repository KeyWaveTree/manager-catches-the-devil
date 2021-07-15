using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIEventSC : MonoBehaviour
{
    public static UIEventSC Instance;
    public static bool tutorial = true;

    public Text announText;
    public int nextStep = 1;
    public Image fade;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void Update()
    {
        Tutorials();
    }
    void Tutorials()
    {
        if (tutorial)
        {
            switch (nextStep)
            {
                case 1:
                    announText.text = "용병이 모집되었다[Tab]을 눌러 확인해보자";
                    
                    if (Input.GetMouseButtonDown(0))
                    {
                        transform.GetChild(0).gameObject.SetActive(false);
                    }
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {
                        transform.GetChild(0).gameObject.SetActive(true);
                        nextStep++;
                    }
                    break;
                case 2:
                    announText.text = "지금 나에겐 고용된 용사가 한 명도 없어.. 거를 처지가 아니지";
                    if (Input.GetMouseButtonDown(0))
                    {
                        transform.GetChild(0).gameObject.SetActive(false);
                    }
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {
                        transform.GetChild(0).gameObject.SetActive(true);
                        nextStep++;
                    }
                    break;
                case 3:
                    announText.text = "1-1 스테이지를 클릭해 몬스터들을 처치하자";
                    if (Input.GetMouseButtonDown(0))
                    {
                        transform.GetChild(0).gameObject.SetActive(false);
                    }
                    break;
                case 4:
                    announText.text = "몬스터를 처치하려면 용사의 힘이 필요해 용사를 전부 모집하자";
                    if (Input.GetMouseButtonDown(0))
                    {
                        Invoke("Tip", 1);
                    }
                    break;
                case 5:
                    if (Input.GetMouseButtonUp(0))
                    {
                        Sibal();
                    }
                    break;
                case 6:
                    announText.text = "용사를 출전시켜 몬스터와 전투를 시켜보자";
                    transform.GetChild(0).gameObject.SetActive(true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        transform.GetChild(0).gameObject.SetActive(false);
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        Sibal();
                    }
                    break;
                case 7:
                    announText.text = "출전하여 필드에 있을 때는 필드스킬 버튼을 눌러 필드스킬을 \n벤치에 있을 때는 벤치스킬 버튼을 눌러 벤치스킬을 사용해 보자";
                    transform.GetChild(0).gameObject.SetActive(true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        transform.GetChild(0).gameObject.SetActive(false);
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        Sibal();
                    }
                    break;
                case 8:
                    announText.text = "매 턴마다 출전 중인 용사를 벤치로 돌려보내고 벤치에 있는 용사를\n 출전시킬 수 있어";
                    transform.GetChild(0).gameObject.SetActive(true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        transform.GetChild(0).gameObject.SetActive(false);
                    }
                    if (Input.GetMouseButtonUp(0))
                    {              
                        tutorial = false;
                    }
                    break;
            }
        } else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    void Tip()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    void Ssibal()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    void Sibal()
    {
        nextStep++;
    }

    public IEnumerator GameOverEvent()
    {
        fade.gameObject.SetActive(true);
        float fadeCount = 0;
        while(fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            fade.color = new Color(0, 0, 0, fadeCount);
        }
        fade.transform.GetChild(0).gameObject.SetActive(true);
        Destroy(GameObject.Find("CardDataBase").gameObject);
        Destroy(GameObject.Find("BattleDataManger").gameObject);
        Destroy(GameObject.Find("StageMoveManager").gameObject);
        Destroy(GameObject.Find("ItemManger").gameObject);
        Destroy(GameObject.Find("TextCanvas").gameObject);

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameStart");
    }
}
