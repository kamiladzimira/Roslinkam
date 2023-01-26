using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private AudioSource hitSoundSource;

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

    public void PlayBackgroundMusic()
    {
        backgroundMusicSource.Play();
    }

    public void PlayHitSound()
    {
        hitSoundSource.Play();

    }

    }
}


