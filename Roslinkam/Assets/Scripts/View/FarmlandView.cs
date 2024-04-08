using UnityEngine;
using TMPro;

public class FarmlandView : MonoBehaviour
{
    #region non public fields
    
    [SerializeField] 
    private Farmland _farmland;
    [SerializeField] 
    private TextMeshProUGUI _timer;
    [SerializeField]
    private SpriteRenderer _seedRenderer;
    
    #endregion

    #region public fields
    #endregion

    #region non public methods
    
    private void OnEnable()
    {
        _farmland.OnTimerChangedAction += OnTimerChanged;
        _farmland.OnPlantSeededAction += OnPlantSeeded;
    }

    private void OnDisable()
    {
        _farmland.OnTimerChangedAction -= OnTimerChanged;
        _farmland.OnPlantSeededAction -= OnPlantSeeded;
    }

    private void OnTimerChanged(float timerValue)
    {
        if(timerValue <= 0)
        {
            timerValue = 0;
            _timer.gameObject.SetActive(false);
            _seedRenderer.sprite = null;
        }
        _timer.text = timerValue.ToString("0.00");
    }

    private void OnPlantSeeded()
    {
        _timer.gameObject.SetActive(true);
        _seedRenderer.sprite = _farmland.Seed.Sprite;
    }
    
    #endregion

    #region public methods
    #endregion
}
