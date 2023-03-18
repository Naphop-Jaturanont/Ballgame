using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [SerializeField] private AudioClip[] musicClips;
    [SerializeField] private AudioClip[] sfxClips;

    private Dictionary<string, AudioClip> musicDict = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> sfxDict = new Dictionary<string, AudioClip>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

       

        // Load music clips into dictionary
        foreach (AudioClip clip in musicClips)
        {
            musicDict.Add(clip.name, clip);
        }

        // Load sfx clips into dictionary
        foreach (AudioClip clip in sfxClips)
        {
            sfxDict.Add(clip.name, clip);
        }
    }

    public void PlayMusic(string clipName, bool loop = true)
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }

        musicSource.clip = musicDict[clipName];
        musicSource.loop = loop;
        musicSource.Play();
    }

    public void PlaySFX(string clipName, float volume = 1f)
    {
        sfxSource.PlayOneShot(sfxDict[clipName], volume);
    }
}