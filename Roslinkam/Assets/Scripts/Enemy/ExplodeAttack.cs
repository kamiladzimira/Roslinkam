using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeAttack : AttackType
{
    [SerializeField] private EnemyComponentsContainer enemyComponentsContainer;
    [SerializeField] private int damage;
    public override void DoAttack(int damage)
    {
        DealDamage(enemyComponentsContainer.EnemyTargetFinder.Target);
        Destroy(gameObject);
    }

    public void DealDamage(HealthController target)
    {
        if (target == null)
        {
            return;
        }
        target.GetDamage(damage);
    }
}
