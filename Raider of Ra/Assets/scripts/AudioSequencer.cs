using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioSequencer : Movable
{

    [System.Serializable]
    public class AudioData
    {
        public AudioClip audioClip;
        public string text;
        public float durationGap;
    }
    [SerializeField] TextMeshProUGUI subts;
    public AudioData[] audioSequence;
    public float volume = 1.0f;

    [SerializeField] AudioSource audioSource;
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
            if (subts != null && currentAudio.text != null)
                subts.text = currentAudio.text;
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
