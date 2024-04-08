using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    #region non public fields

    [SerializeField]
    private float _maxHealthValue;
    [SerializeField]
    private Image _healthValueImage;

    private float _healthValue;

    #endregion

    #region public fields

    public event Action OnDied;

    #endregion

    #region non public methods

    private void Start()
    {
        _healthValue = _maxHealthValue;
        SetHealthBar();
    }

    #endregion

    #region public methods

    public void SetHealthBar()
    {
        _healthValueImage.fillAmount = _healthValue/_maxHealthValue;
    } 

    public void GetDamage(float value)
    {
        if (_healthValue > 0)
        {
            Debug.Log(_healthValue);
            _healthValueImage.fillAmount -= value;
            _healthValue -= value;
            SetHealthBar();
            if (_healthValue <= 0)
            {
                _healthValueImage.fillAmount = 0;
                OnDied?.Invoke();
            }
        }
    }

    #endregion
}
