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

    private void Start()
    {
        gameOver.SetActive(false);
        AudioManager.GetInstance().PlayBackgroundMusic();
    }
    private void Update()
    {
        CoinsValueDispay();
    }
    public void CoinsValueDispay()
    {
        coins.text = playerComponentsContainer.Inventory.Money.ToString();
    }

    public static GameManager GetInstance()
    {
        return instance;
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

    /*public void RemoveElementFromList(EnemyHealthController enemyHealthController)
    {
        enemyHealthControllers.Remove(enemyHealthController);
        HandleWinningCase();
    }

    public void AddElementToList(EnemyHealthController enemyHealthController)
    {
        enemyHealthControllers.Add(enemyHealthController);
    }

    public void PlayParticle(EnemyHealthController enemyHealthController)
    {
        ps.transform.position = enemyHealthController.transform.position;
        ps.Play(true);
    }

    public void HandleWinningCase()
    {
        if (enemyHealthControllers.Count != 0)
        {
            return;
        }
        displayedCongrats.gameObject.SetActive(true);
        StartCoroutine(LoadSameScene());
    }*/

}
