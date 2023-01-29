using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;

    public void DealDamageToTarget(HealthController target)
    {
        target.GetDamage(damage);
    }
}
