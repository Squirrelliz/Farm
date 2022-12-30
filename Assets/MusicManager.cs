using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    private void Awake()
    {
        instance = this;
    }
    [SerializeField] AudioSource audioSource;
    [SerializeField] float timeToSwitch;
    [SerializeField] AudioClip clipToPlay;

    private void Start()
    {
        Play(clipToPlay, true);
    }
    public void Play(AudioClip clip, bool interrupt=false)
    {
        if (clip == null) { return; }
        if (interrupt == true)
        {
            audioSource.volume = 1f;
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            switchTo = clip;
            StartCoroutine(SmoothSwitchMusic());

        }
    }

    AudioClip switchTo;
    float volume;

    IEnumerator SmoothSwitchMusic()
    {
        volume = 1f;
        while (volume > 0f)
        {
            volume -= Time.fixedDeltaTime/timeToSwitch;
            if (volume < 0f) { volume = 0f; }
            audioSource.volume = volume;
            yield return new WaitForEndOfFrame();
        }

        Play(switchTo,true);
    }


}
