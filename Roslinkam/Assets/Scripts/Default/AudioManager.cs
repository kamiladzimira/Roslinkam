using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private AudioSource hitSoundSource;
    [SerializeField] private AudioSource explodeSoundSource;
    [SerializeField] private AudioSource shootSoundSource;
    [SerializeField] private AudioSource itemPickUpSoundSource;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            DontDestroyOnLoad(gameObject);
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

    public void PlayPickUpSound()
    {
        itemPickUpSoundSource.Play();
    }

    public void PlayExplodeSound()
    {
        explodeSoundSource.Play();
    }

    public void PlayShootSound()
    {
        shootSoundSource.Play();
    }
}




