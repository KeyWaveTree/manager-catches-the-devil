using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void SelectCardVoice();
public class SoundManager : MonoBehaviour
{
    public event SelectCardVoice selectCardVoice;

    public AudioClip[] characterChooseVoice;
    public AudioClip storeMaster;

    private AudioSource thisAudioSource;

    bool _chooseCharId = false;
    public bool chooseCharId
    {
        get { return _chooseCharId; }
        set
        {
            _chooseCharId = value;

            if (chooseCharId) selectCardVoice();
        }
    }

    void Start()
    {
        selectCardVoice += new SelectCardVoice(CardVoice);
        thisAudioSource = GetComponent<AudioSource>();
    }


    void CardVoice()
    {
        if (CardSelect.selectCardId != 0)
        {
            chooseCharId = false;
            thisAudioSource.Stop();
            thisAudioSource.clip = characterChooseVoice[CardSelect.selectCardId - 1];
            thisAudioSource.Play();
        }
    }
}
