using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private EnemyComponentsContainer enemyComponentsContainer;
    [SerializeField] private int damage;

    public void DealDamageToTarget()
    {
        DealDamage(enemyComponentsContainer.EnemyTargetFinder.Target);
    }

    public void DealDamage(HealthController target)
    {
        if(target == null)
        {
            return;
        }
        target.GetDamage(damage);
    }
}
