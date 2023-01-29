using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttack : IEnemyState
{
    EnemyComponentsContainer enemyComponentsContainer;
    [SerializeField] private Animator animator;


    public StateAttack(EnemyComponentsContainer enemyComponentsContainer)
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
                                > enemyComponentsContainer.EnemyController.AttackDistance + 0.2)
        {
            return enemyComponentsContainer.EnemyController.StateTrigger;
        }

        return this;
        
    }

    public void OnEnter()
    {
        enemyComponentsContainer.EnemyAnimatorController.ResetAllTriggers();
        enemyComponentsContainer.EnemyAnimator.SetTrigger("Attack");
    }
}
