using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region non public fields
    
    [SerializeField] 
    private PlayerComponentsContainer _playerComponentsContainer;
    
    #endregion

    #region public fields
    #endregion

    #region non public methods

    private void Start()
    {
        GameManager.GetInstance().RegisterPlayer(_playerComponentsContainer.HealthController);
    }

    #endregion

    #region public methods
    #endregion
}
