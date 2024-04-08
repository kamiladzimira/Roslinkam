using UnityEngine;
using TMPro;

public class SpawnerView : MonoBehaviour
{
    #region non public fields
    
    [SerializeField] 
    private SeedSpawner _seedSpawner;
    [SerializeField] 
    private TextMeshProUGUI _timer;
    
    #endregion

    #region public fields
    #endregion

    #region non public methods
    
    private void OnEnable()
    {
        _seedSpawner.OnTimerChangedAction += OnTimerChanged;
    }

    private void OnDisable()
    {
        _seedSpawner.OnTimerChangedAction -= OnTimerChanged;
    }

    private void OnTimerChanged(float timerValue)
    {
        if (timerValue <= 0)
        {
            _timer.text = "Ready!";
            return;
        }
        _timer.text = timerValue.ToString("0.00");
    }
    
    #endregion

    #region public methods
    #endregion
}
