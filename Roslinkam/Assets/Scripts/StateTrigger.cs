using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTrigger : IEnemyState
{
    EnemyComponentsContainer enemyComponentsContainer;
    float timer;
    bool shouldMove;

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
        if(!shouldMove)
        {
            return HandleBeforeMove();
        }
        
        enemyComponentsContainer.EnemyMovement.Move(enemyComponentsContainer.EnemyTargetFinder.Target.transform);
        return this;
    }

    private IEnemyState HandleBeforeMove()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            shouldMove = true;
            enemyComponentsContainer.EnemyAnimatorController.ResetAllTriggers();
            enemyComponentsContainer.EnemyAnimator.SetTrigger("Walk");
        }
        return this;
    }

    public void OnEnter()
    {
        timer = 1;
        shouldMove = false;
        enemyComponentsContainer.EnemyAnimatorController.ResetAllTriggers();
        enemyComponentsContainer.EnemyAnimator.SetTrigger("Trigger");
    }
}
