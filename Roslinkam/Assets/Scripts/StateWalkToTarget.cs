using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWalkToTarget : IEnemyState
{
    EnemyComponentsContainer enemyComponentsContainer;
  
    public StateWalkToTarget(EnemyComponentsContainer enemyComponentsContainer)
    {
        this.enemyComponentsContainer = enemyComponentsContainer;
    }

    public IEnemyState DoState()
    {
        if (enemyComponentsContainer.EnemyTargetFinder.Target == null)
        {
            return enemyComponentsContainer.EnemyController.StateIdle;
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

    public void OnEnter()
    {
        enemyComponentsContainer.EnemyAnimatorController.ResetAllTriggers();
        enemyComponentsContainer.EnemyAnimator.SetTrigger("Walk");
    }
}
