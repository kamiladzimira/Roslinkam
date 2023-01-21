using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int healthValue;

    public void GetDamage(int value)
    {
        if (healthValue > 0)
        {
            healthValue -= value;
            Debug.Log(healthValue);
            if (healthValue <= 0)
            {
                Debug.Log("nie zyjesz!") ;
            }
        }
    }
}
