using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region non public fields

    [SerializeField]
    private AudioSource _backgroundMusicSource;
    [SerializeField]
    private AudioSource _hitSoundSource;
    [SerializeField]
    private AudioSource _explodeSoundSource;
    [SerializeField]
    private AudioSource _shootSoundSource;
    [SerializeField]
    private AudioSource _itemPickUpSoundSource;

    private static AudioManager _instance;

    #endregion

    #region public fields
    #endregion

    #region non public methods

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        PlayBackgroundMusic();
    }

    #endregion

    #region public methods

    public static AudioManager GetInstance()
    {
        return _instance;
    }

    public void PlayBackgroundMusic()
    {
        _backgroundMusicSource.Play();
    }

    public void PlayHitSound()
    {
        _hitSoundSource.Play();
    }

    public void PlayPickUpSound()
    {
        _itemPickUpSoundSource.Play();
    }

    public void PlayExplodeSound()
    {
        _explodeSoundSource.Play();
    }

    public void PlayShootSound()
    {
        _shootSoundSource.Play();
    }

    #endregion
}
