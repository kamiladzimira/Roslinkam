using System.Collections.Generic;
using UnityEngine;

public class StateIdle : IEnemyState
{
    #region non public fields

    private EnemyComponentsContainer _enemyComponentsContainer;
    private Transform _currentTarget;
    private int _routeIndex;
    private EnemyMovement enemyMovement => _enemyComponentsContainer.EnemyMovement;

    #endregion

    #region public fields
    #endregion

    #region non public methods
    #endregion

    #region public methods

    public StateIdle(EnemyComponentsContainer enemyComponentsContainer)
    {
        this._enemyComponentsContainer = enemyComponentsContainer;
        _routeIndex = 0;
        _currentTarget = enemyComponentsContainer.EnemyMovement.Route[_routeIndex];
    }

    public IEnemyState DoState()
    {
        enemyMovement.Move(_currentTarget);
        Transform enemyTransform = enemyMovement.transform;
        List<Transform> route = enemyMovement.Route;

        if (Vector2.Distance(enemyTransform.position, _currentTarget.position) < enemyMovement.PositionAccuracy)
        {
            _routeIndex = (_routeIndex + 1) % route.Count;
            _currentTarget = route[_routeIndex];
        }

        if(_enemyComponentsContainer.EnemyTargetFinder.Target == null)
        {
            return this;
        }
        return _enemyComponentsContainer.EnemyController.StateTrigger;
    }

    public void OnEnter()
    {
        _enemyComponentsContainer.EnemyAnimatorController.ResetAllTriggers();
        _enemyComponentsContainer.EnemyAnimator.SetTrigger("Walk");
    }   

    #endregion
}
