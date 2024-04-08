using System.Collections.Generic;
using UnityEngine;
using System;

public class SeedSpawner : MonoBehaviour
{
    #region non public fields
    
    [SerializeField] 
    private List <Seed> _seeds;
    [SerializeField] 
    private Transform _spawnPoint;
    [SerializeField] 
    private float _defaultTimer = 5f;
    
    private float _timer;
    private Seed _currentSeed;
    private Shop _shop;

    #endregion

    #region public fields

    public Action<float> OnTimerChangedAction;

    #endregion

    #region non public methods

    private void Start()
    {
        OnTimerChangedAction?.Invoke(_timer);
    }

    private void Update()
    {
        ProcessTimer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandlePlayerTrigger(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Seed seed = collision.GetComponent<Seed>();
        if (seed != _currentSeed)
        {
            return;
        }
        _currentSeed = null;
    }

    private void HandlePlayerTrigger(Collider2D collision)
    {
        PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();

        if (playerMovement == null || _currentSeed != null || _timer > 0)
        {
            return;
        }
        
        _currentSeed = Instantiate(_seeds[UnityEngine.Random.Range(0, _seeds.Count)], _spawnPoint.position, Quaternion.identity, null);
        _timer = _defaultTimer;
    }

    private void ProcessTimer()
    {
        if (_timer <= 0)
        {
            return;
        }
        _timer -= Time.deltaTime;
        OnTimerChangedAction?.Invoke(_timer);
    }
    
    #endregion

    #region public methods
    #endregion
}
