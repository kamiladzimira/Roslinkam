using System;
using UnityEngine;

public class Farmland : MonoBehaviour
{
    #region non public fields

    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    private Seed _seed;
    private float _timer;
    private bool _isEmpty = true;
    private bool _isActive = false;

    #endregion

    #region public fields

    public Seed Seed => _seed;
    public bool IsEmpty => _isEmpty;
    public bool IsActive => _isActive;

    public event Action<float> OnTimerChangedAction;
    public event Action OnPlantSeededAction;

    #endregion

    #region non public methods

    private void Update()
    {
        ProcessTimer();
    }

    private void Start()
    {
        _spriteRenderer.enabled = false;
    }

    private void ProcessTimer()
    {
        if (_timer <= 0)
        {
            return;
        }
        _timer -= Time.deltaTime;
        OnTimerChangedAction?.Invoke(_timer);
        if (_timer <= 0)
        {
            Instantiate(_seed.Crop, transform.position, Quaternion.identity, null);
            Destroy(_seed.gameObject);
            _isEmpty = true;
        }
    }

    #endregion

    #region public methods

    public void ActiveFarmland()
    {
        if (!_isActive)
        {
            _spriteRenderer.enabled = true;
        }
        _isActive = true;
    }

    public void SeedPlant(Seed seed)
    {
        if (_isActive)
        {
            _timer = seed.GrowingTime;
            this._seed = seed;
            _isEmpty = false;
            OnPlantSeededAction?.Invoke();
        }
    }

    #endregion
}
