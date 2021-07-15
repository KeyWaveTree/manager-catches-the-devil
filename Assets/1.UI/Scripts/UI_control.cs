using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class UI_control : MonoBehaviour
{
    public GameObject menu;
    public GameObject bag;
    public GameObject recruit;
    public GameObject shop;   // x 0.0144, y -0.0145 이동 후 위치, 이동 전 위치 x -18.25
    private stage_move sm;

    public PlayableDirector playDir;
    public TimelineAsset inMenu;
    public TimelineAsset outMenu;

    public bool _move = false;

    static public bool _isMenuIn = false;
    public AudioSource BGM;
    private GameObject storeSound;

    private void Start()
    {
        sm = GameObject.Find("StageMoveManager").GetComponent<stage_move>();
        storeSound = GameObject.Find("SoundManager").gameObject;

        GotchaData.poolToken = 2;
        if (sm.chapter == 1 && sm.chapterChange.clear_stage == 0)
        {
            GotchaData.poolChance = 3;
        }
        else
        {
            GotchaData.poolChance = 1;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _move = !_move;
            if (_move)
            {
                playDir.Stop();
                playDir.Play(inMenu);
                _isMenuIn = true;
                BGM.volume = 0.4f;
            }
            else
            {
                playDir.Stop();
                playDir.Play(outMenu);
                _isMenuIn = false;
                BGM.volume = 1f;
            }
        }
    }

    public void Bag()
    {
        bag.SetActive(true);
        recruit.SetActive(false);
        shop.SetActive(false);
    }

    public void Recruit()
    {
        recruit.SetActive(true);
        shop.SetActive(false);
        bag.SetActive(false);
    }

    public void Shop()
    {
        shop.SetActive(true);
        recruit.SetActive(false);
        bag.SetActive(false);
        storeSound.GetComponent<AudioSource>().Stop();
        storeSound.GetComponent<AudioSource>().clip = storeSound.GetComponent<SoundManager>().storeMaster;
        storeSound.GetComponent<AudioSource>().Play();
    }
}
