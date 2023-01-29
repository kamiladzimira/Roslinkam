using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator enemyMovementAnimator;
    [SerializeField] private EnemyComponentsContainer enemyComponentsContainer;
    public StateIdle StateIdle { get; private set; }
    public StateTrigger StateTrigger { get; private set; }
    public StateAttack StateAttack { get; private set; }
    public Animator EnemyMovementAnimator => enemyMovementAnimator;

    IEnemyState enemyState;

    private void Awake()
    {
        StateIdle = new StateIdle(enemyComponentsContainer);
        StateTrigger = new StateTrigger(enemyComponentsContainer);
        StateAttack = new StateAttack(enemyComponentsContainer);
        enemyState = StateIdle;
        enemyState.OnEnter();

    }

    private void Update()
    {
        IEnemyState lastState = enemyState;
        enemyState = enemyState.DoState();
        if (lastState != enemyState)
        {
            enemyState.OnEnter();
        }
    }



}
