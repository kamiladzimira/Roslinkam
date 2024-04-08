using UnityEngine;
using TMPro;

public class StatisticsView : MonoBehaviour
{
    #region non public fields
    
    [SerializeField] 
    private TextMeshProUGUI _coins;
    [SerializeField] 
    private PlayerComponentsContainer _playerComponentsContainer;
    
    #endregion

    #region public fields
    #endregion

    #region non public methods
    
    private void Update()
    {
        CoinsValueDispay();
    }
    
    #endregion

    #region public methods
    
    public void CoinsValueDispay()
    {
        _coins.text = _playerComponentsContainer.Inventory.Money.ToString();
    }
    
    #endregion
}
