using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSound : MonoBehaviour {
    public AudioSource AudioSrc;

    private void Awake()
    {
        if (AudioSrc == null)
            AudioSrc.GetComponent<AudioSource>();
    }

    public void PlayAnimalSound(AudioClip AnimalSound)
    {
        if (AudioSrc.isPlaying)
            AudioSrc.Stop();
        AudioSrc.PlayOneShot(AnimalSound);
    }
}
