using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] private AudioClip background;
    //[SerializeField] private TextMeshProUGUI displayedGameOver;
    [SerializeField] private TextMeshProUGUI coins;
    [SerializeField] PlayerComponentsContainer playerComponentsContainer;

    private void Update()
    {
        CoinsValueDispay();
    }
    public void CoinsValueDispay()
    {
        coins.text = playerComponentsContainer.Inventory.Money.ToString();
    }

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
        AudioManager.GetInstance().PlayBackgroundMusic(background);
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void DisplayScore(int value)
    {
        coins.text = "Score: " + coins.ToString();
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
