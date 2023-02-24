using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : AttackType
{
    [SerializeField] private EnemyComponentsContainer enemyComponentsContainer;
    [SerializeField] private int damage;
    public override void DoAttack(int damage)
    {
        DealDamage(enemyComponentsContainer.EnemyTargetFinder.Target);
    }

    public void DealDamage(HealthController target)
    {
        if (target == null)
        {
            return;
        }
        if (true)
        {

        }
        target.GetDamage(damage);
    }
}
