using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage_back : MonoBehaviour
{
    public stage_move sm;
    // Start is called before the first frame update
    public void OnMouseDown()
    {
        CardData.CardDeck();
        sm = FindObjectOfType<stage_move>();
        sm.chapterChange.clear_stage++;
        sm.moveSceneName = "Main";
        SceneManager.LoadScene("LoadingScene");
    }
}
