using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSoundManager : MonoBehaviour
{

    public AudioClip[] SkillVoice;

    private AudioSource thisAudioSource;

    void Start()
    {
        thisAudioSource = GetComponent<AudioSource>();
    }

    public void PlaySkillVoice(int thisCard)
    {
        thisAudioSource.Stop();
        thisAudioSource.clip = SkillVoice[thisCard - 1];
        thisAudioSource.Play();
    }
}
