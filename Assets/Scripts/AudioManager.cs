using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource musicAudioSource;
    public AudioSource vfxAudioSource;

    public AudioClip musicClip;
    public AudioClip shootClip;
    public AudioClip playerHitClip;
    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }
    public void PlayVFX(AudioClip clip)
    {
        vfxAudioSource.clip = clip;
        vfxAudioSource.PlayOneShot(clip);
    }
}
