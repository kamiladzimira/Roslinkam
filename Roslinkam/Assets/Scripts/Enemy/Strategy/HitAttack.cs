using UnityEngine;

public class HitAttack : AttackType
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
        target.GetDamage(damage);
    }
}
