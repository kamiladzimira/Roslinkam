using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] private TextMeshProUGUI displayedGameOver;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private TextMeshProUGUI coins;
    [SerializeField] PlayerComponentsContainer playerComponentsContainer;
    private HealthController playerHealthController;
    private int loadSceneDelay = 2;

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
    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        gameOver.SetActive(false);
        PlayBackgroundMusic();
    }
    private void Update()
    {
        CoinsValueDispay();
    }
    public void CoinsValueDispay()
    {
        coins.text = playerComponentsContainer.Inventory.Money.ToString();
    }

    private void PlayBackgroundMusic()
    {
        AudioManager.GetInstance().PlayBackgroundMusic();
    }

    public void PlayHitSound()
    {
        AudioManager.GetInstance().PlayHitSound();
    }

    public void PlayExplodeSound()
    {
        AudioManager.GetInstance().PlayExplodeSound();
    }

    public void PlayShootSound()
    {
        AudioManager.GetInstance().PlayShootSound();
    }

    public void RegisterPlayer(HealthController healthController)
    {
       if(playerHealthController != null)
        {
            playerHealthController.OnDied -= OnPlayerDied;
        }
        playerHealthController = healthController;
        playerHealthController.OnDied += OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        gameOver.SetActive(true);
        StartCoroutine(LoadSameSceneWithDelay());
    }

    IEnumerator LoadSameSceneWithDelay()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        int sceneToLoad = activeScene.buildIndex;
        yield return new WaitForSecondsRealtime(loadSceneDelay);
        SceneManager.LoadScene(sceneToLoad);   
    }
}
