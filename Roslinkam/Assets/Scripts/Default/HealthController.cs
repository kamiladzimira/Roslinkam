using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int healthValue;

    public event Action OnDied;

    public void GetDamage(int value)
    {
        if (healthValue > 0)
        {
            healthValue -= value;
            Debug.Log(healthValue);
            if (healthValue <= 0)
            {
                OnDied?.Invoke();
            }
        }
    }
}
