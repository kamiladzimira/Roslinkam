using UnityEngine;

public class ExplodeAttack : AttackType
{
    #region non public fields

    [SerializeField] 
    private EnemyComponentsContainer _enemyComponentsContainer;
    [SerializeField] 
    private int _damage;

    #endregion

    #region public fields
    #endregion

    #region non public methods
    #endregion

    #region public methods

    public override void DoAttack(int damage)
    {
        DealDamage(_enemyComponentsContainer.EnemyTargetFinder.Target);
        Destroy(gameObject);
    }

    public void DealDamage(HealthController target)
    {
        if (target == null)
        {
            return;
        }
        target.GetDamage(_damage);
    }

    #endregion
}
