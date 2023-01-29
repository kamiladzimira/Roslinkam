using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class StateIdle : IEnemyState
{
    private EnemyComponentsContainer enemyComponentsContainer;
    private Transform currentTarget;
    private int routeIndex;
    private EnemyMovement enemyMovement => enemyComponentsContainer.EnemyMovement;

    public StateIdle(EnemyComponentsContainer enemyComponentsContainer)
    {
        this.enemyComponentsContainer = enemyComponentsContainer;
        routeIndex = 0;
        currentTarget = enemyComponentsContainer.EnemyMovement.Route[routeIndex];
    }

    public IEnemyState DoState()
    {

        enemyMovement.Move(currentTarget);
        Transform enemyTransform = enemyMovement.transform;
        List<Transform> route = enemyMovement.Route;

        if (Vector2.Distance(enemyTransform.position, currentTarget.position) < enemyMovement.PositionAccuracy)
        {
            routeIndex = (routeIndex + 1) % route.Count;
            currentTarget = route[routeIndex];
        }

        if(enemyComponentsContainer.EnemyTargetFinder.Target == null)
        {
            return this;
        }
        return enemyComponentsContainer.EnemyController.StateTrigger;
    }

    public void OnEnter()
    {
        enemyComponentsContainer.EnemyAnimatorController.ResetAllTriggers();
        enemyComponentsContainer.EnemyAnimator.SetTrigger("Walk");
    }   
}
