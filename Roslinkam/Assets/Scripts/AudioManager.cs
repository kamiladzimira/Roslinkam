using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager:MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] private AudioSource backgroundMusic;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public static AudioManager GetInstance()
    {
        return instance;
    }

    public void PlayBackgroundMusic(AudioClip clip)
    {
        backgroundMusic.PlayOneShot(clip);
    }
}
