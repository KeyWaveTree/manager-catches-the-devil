using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EventHandler(int chapter);

public class ChapterChange
{
    public event EventHandler eventHandler;

    int _clear_stage = 0;

    public int clear_stage
    {
        get { return _clear_stage; }
        set
        {
            _clear_stage = value;

            if (clear_stage == 6) eventHandler(2);
        }
    }
}
public class stage_move : MonoBehaviour
{
    public int chapter = 1;

    public static stage_move Instance;
    public ChapterChange chapterChange = new ChapterChange();
    public string moveSceneName = "";

    void NextChapter(int chapter)
    {
        this.chapter = 2;
        chapterChange.clear_stage = 0;
    }


    public void Awake()
    {
        chapterChange.eventHandler += new EventHandler(NextChapter);

        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
