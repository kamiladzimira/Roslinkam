using UnityEngine;

public class PlayerComponentsContainer : MonoBehaviour
{
    #region non public fields

    [SerializeField] 
    private PlayerMovement _playerMovement;
    [SerializeField] 
    private Inventory _inventory;
    [SerializeField] 
    private HealthController _healthController;
    [SerializeField] 
    private PlayerTargetFinder _playerTargetFinder;

    #endregion

    #region public fields

    public PlayerMovement PlayerMovement => _playerMovement;
    public Inventory Inventory => _inventory;
    public HealthController HealthController => _healthController;
    public PlayerTargetFinder PlayerTargetFinder => _playerTargetFinder;
    
    #endregion

    #region non public methods
    #endregion

    #region public methods
    #endregion
}
