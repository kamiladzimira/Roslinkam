using UnityEngine;

public class StateFollowPrey : IEnemyState
{
    #region non public fields

    private EnemyComponentsContainer _enemyComponentsContainer;
    
    #endregion

    #region public fields
    #endregion

    #region non public methods
    #endregion

    #region public methods

    public StateFollowPrey(EnemyComponentsContainer enemyComponentsContainer)
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
                                < _enemyComponentsContainer.EnemyController.AttackDistance)
        {
            return _enemyComponentsContainer.EnemyController.StateAttack;
        }
        _enemyComponentsContainer.EnemyMovement.Move(_enemyComponentsContainer.EnemyTargetFinder.Target.transform);
        return this;
    }

    public void OnEnter()
    {
        _enemyComponentsContainer.EnemyAnimatorController.ResetAllTriggers();
        _enemyComponentsContainer.EnemyAnimator.SetTrigger("Walk");
    }

    #endregion
}
