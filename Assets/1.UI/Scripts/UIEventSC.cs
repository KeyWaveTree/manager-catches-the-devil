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
                    announText.text = "�뺴�� �����Ǿ���[Tab]�� ���� Ȯ���غ���";
                    
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
                    announText.text = "���� ������ ���� ��簡 �� �� ����.. �Ÿ� ó���� �ƴ���";
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
                    announText.text = "1-1 ���������� Ŭ���� ���͵��� óġ����";
                    if (Input.GetMouseButtonDown(0))
                    {
                        transform.GetChild(0).gameObject.SetActive(false);
                    }
                    break;
                case 4:
                    announText.text = "���͸� óġ�Ϸ��� ����� ���� �ʿ��� ��縦 ���� ��������";
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
                    announText.text = "��縦 �������� ���Ϳ� ������ ���Ѻ���";
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
                    announText.text = "�����Ͽ� �ʵ忡 ���� ���� �ʵ彺ų ��ư�� ���� �ʵ彺ų�� \n��ġ�� ���� ���� ��ġ��ų ��ư�� ���� ��ġ��ų�� ����� ����";
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
                    announText.text = "�� �ϸ��� ���� ���� ��縦 ��ġ�� ���������� ��ġ�� �ִ� ��縦\n ������ų �� �־�";
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
