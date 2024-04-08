using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    #region non public fields

    [SerializeField]
    private TextMeshProUGUI _displayedGameOver;
    [SerializeField]
    private GameObject _gameOver;
    [SerializeField]
    private TextMeshProUGUI _coins;
    [SerializeField]
    private PlayerComponentsContainer _playerComponentsContainer;

    private static GameManager _instance;
    private HealthController _playerHealthController;
    private int _loadSceneDelay = 2;

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
        }
    }

    private void Start()
    {
        _gameOver.SetActive(false);
    }
    private void Update()
    {
        CoinsValueDispay();
    }

    private void OnPlayerDied()
    {
        _gameOver.SetActive(true);
        StartCoroutine(LoadSameSceneWithDelay());
    }

    private IEnumerator LoadSameSceneWithDelay()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        int sceneToLoad = activeScene.buildIndex;
        yield return new WaitForSecondsRealtime(_loadSceneDelay);
        SceneManager.LoadScene(sceneToLoad);
    }

    #endregion

    #region public methods

    public static GameManager GetInstance()
    {
        return _instance;
    }

    public void CoinsValueDispay()
    {
        _coins.text = _playerComponentsContainer.Inventory.Money.ToString();
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
        if (_playerHealthController != null)
        {
            _playerHealthController.OnDied -= OnPlayerDied;
        }
        _playerHealthController = healthController;
        _playerHealthController.OnDied += OnPlayerDied;
    }

    public void OnGameQuit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    #endregion
}
