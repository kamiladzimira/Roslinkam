using UnityEngine;

public class DamageDealer : MonoBehaviour
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

    public void DealDamageToTarget()
    {
        DealDamage(_enemyComponentsContainer.EnemyTargetFinder.Target);
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
