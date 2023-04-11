using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private float _healthValue;
    [SerializeField] private float _maxHealthValue;
    [SerializeField] private Image _healthValueImage;

    public event Action OnDied;
    private void Start()
    {
        _healthValue = _maxHealthValue;
        SetHealthBar();
    }
    public void SetHealthBar()
    {
        _healthValueImage.fillAmount = _healthValue/_maxHealthValue;
    }
    public void GetDamage(float value)
    {
        if (_healthValue > 0)
        {
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
}
