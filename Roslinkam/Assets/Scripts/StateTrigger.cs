using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTrigger : IEnemyState
{
    EnemyComponentsContainer enemyComponentsContainer;
    private float _timer;
    private bool _shouldMove;

    public StateTrigger(EnemyComponentsContainer enemyComponentsContainer)
    {
        this.enemyComponentsContainer = enemyComponentsContainer;
    }

    public IEnemyState DoState()
    {
        if(enemyComponentsContainer.EnemyTargetFinder.Target == null)
        {
            return enemyComponentsContainer.EnemyController.StateIdle;
        }
        if(!_shouldMove)
        {
            return HandleBeforeMove();
        }

        if (Vector2.Distance(enemyComponentsContainer.EnemyMovement.transform.position,
                             enemyComponentsContainer.EnemyTargetFinder.Target.transform.position)
                                < enemyComponentsContainer.EnemyController.AttackDistance)
        {
            return enemyComponentsContainer.EnemyController.StateAttack;
        }

        enemyComponentsContainer.EnemyMovement.Move(enemyComponentsContainer.EnemyTargetFinder.Target.transform);
        return this;
    }

    private IEnemyState HandleBeforeMove()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _shouldMove = true;
            enemyComponentsContainer.EnemyAnimatorController.ResetAllTriggers();
            enemyComponentsContainer.EnemyAnimator.SetTrigger("Walk");
        }
        return this;
    }

    public void OnEnter()
    {
        _timer = 1;
        _shouldMove = false;
        enemyComponentsContainer.EnemyAnimatorController.ResetAllTriggers();
        enemyComponentsContainer.EnemyAnimator.SetTrigger("Trigger");
    }
}
