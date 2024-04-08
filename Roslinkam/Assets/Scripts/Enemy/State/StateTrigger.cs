using UnityEngine;

public class StateTrigger : IEnemyState
{
    #region non public fields

    private EnemyComponentsContainer _enemyComponentsContainer;
    private float _timer;
    private bool _shouldMove;
    
    #endregion

    #region public fields
    #endregion

    #region non public methods

    private IEnemyState HandleBeforeMove()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _shouldMove = true;
            return _enemyComponentsContainer.EnemyController.StateWalkToTarget;
        }
        return this;
    }

    #endregion

    #region public methods

    public StateTrigger(EnemyComponentsContainer enemyComponentsContainer)
    {
        this._enemyComponentsContainer = enemyComponentsContainer;
    }

    public IEnemyState DoState()
    {
        if(_enemyComponentsContainer.EnemyTargetFinder.Target == null)
        {
            return _enemyComponentsContainer.EnemyController.StateIdle;
        }
        if (!_shouldMove)
        {
            return HandleBeforeMove();
        }
        return this;
    }

    public void OnEnter()
    {
        _timer = 1;
        _shouldMove = false;
        _enemyComponentsContainer.EnemyAnimatorController.ResetAllTriggers();
        _enemyComponentsContainer.EnemyAnimator.SetTrigger("Trigger");
    }

    #endregion
}
