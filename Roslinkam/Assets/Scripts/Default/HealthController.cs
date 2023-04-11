using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int healthValue;
    [SerializeField] private Sprite healthValueImage;

    public event Action OnDied;

    public void GetDamage(int value)
    {
        if (healthValue > 0)
        {
            
            healthValue -= value;
            Debug.Log( "Your health value is: " + healthValue);
            if (healthValue <= 0)
            {
                OnDied?.Invoke();
            }
        }
    }
}
