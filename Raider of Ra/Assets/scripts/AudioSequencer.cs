using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSequencer : Movable
{

    [System.Serializable]
    public class AudioData
    {
        public AudioClip audioClip;
        public float durationGap;
    }

    public AudioData[] audioSequence;
    public float volume = 1.0f;

    private AudioSource audioSource;
    private int currentIndex = 0;
    private bool isPlaying = false;
    protected override void Engage()
    {
        if (!isPlaying)
            PlaySequence();
    }

    public void PlaySequence()
    {
        if (audioSequence.Length > 0 && !isPlaying)
        {
            isPlaying = true;
            currentIndex = 0;
            PlayNextAudio();
        }
    }

    private void PlayNextAudio()
    {
        if (currentIndex < audioSequence.Length)
        {
            AudioData currentAudio = audioSequence[currentIndex];
            audioSource.clip = currentAudio.audioClip;
            audioSource.volume = volume;
            audioSource.Play();
            currentIndex++;
            // dividing by speed: more speed more short the gap is.
            speed = 1f; // erase that if you want this feature
            Invoke("PlayNextAudio", currentAudio.durationGap / speed);
        }
        else
        {
            isPlaying = false;
            engage = false;
        }
    }
}
