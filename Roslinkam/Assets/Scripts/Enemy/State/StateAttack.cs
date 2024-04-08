using UnityEngine;

public class StateAttack : IEnemyState
{
    #region non public fields

    private EnemyComponentsContainer _enemyComponentsContainer;
    
    #endregion

    #region public fields
    #endregion

    #region non public methods
    #endregion

    #region public methods

    public StateAttack(EnemyComponentsContainer enemyComponentsContainer)
    {
        this._enemyComponentsContainer = enemyComponentsContainer;
    }

    public IEnemyState DoState()
    {
        if (_enemyComponentsContainer.EnemyTargetFinder.Target == null)
        {
            return _enemyComponentsContainer.EnemyController.StateIdle;
        }

        if (Vector2.Distance(_enemyComponentsContainer.EnemyMovement.transform.position,
                             _enemyComponentsContainer.EnemyTargetFinder.Target.transform.position)
                                > _enemyComponentsContainer.EnemyController.AttackDistance + 0.2)
        {
            return _enemyComponentsContainer.EnemyController.StateWalkToTarget;
        }
        return this;
    }

    public void OnEnter()
    {
        _enemyComponentsContainer.EnemyAnimatorController.ResetAllTriggers();
        _enemyComponentsContainer.EnemyAnimator.SetTrigger("Attack");
    }

    #endregion
}
