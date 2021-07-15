using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public Text tipText;
    private stage_move stageManager;
    public string[] tipTextArray;

    public GameObject loadingEvent;
    private void Start()
    {
        stageManager = GameObject.Find("StageMoveManager").GetComponent<stage_move>();
        TipText();
        StartCoroutine(LoadScene());
    }

    void TipText()
    {
        int random = Random.Range(0, tipTextArray.Length);
        tipText.text = tipTextArray[random];
    }
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(stageManager.moveSceneName);
        op.allowSceneActivation = false;
        while (!op.isDone)
        {
            yield return null;
            if (op.progress < 0.9f)
            {
                loadingEvent.GetComponent<Animator>().SetBool("LoadingEnd", false);
            }
            else
            {
                loadingEvent.GetComponent<Animator>().SetBool("LoadingEnd", true);
                if (Input.GetMouseButtonUp(0))
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
