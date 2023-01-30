using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator enemyMovementAnimator;
    [SerializeField] private EnemyComponentsContainer enemyComponentsContainer;
    [SerializeField] private float attackDistance;
    public StateIdle StateIdle { get; private set; }
    public StateTrigger StateTrigger { get; private set; }
    public StateAttack StateAttack { get; private set; }
    public StateFollowPrey StateWalkToTarget { get; private set; }
    public Animator EnemyMovementAnimator => enemyMovementAnimator;
    public float AttackDistance => attackDistance;

    IEnemyState enemyState;

    private void Awake()
    {
        StateIdle = new StateIdle(enemyComponentsContainer);
        StateTrigger = new StateTrigger(enemyComponentsContainer);
        StateAttack = new StateAttack(enemyComponentsContainer);
        StateWalkToTarget = new StateFollowPrey(enemyComponentsContainer);
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
            Debug.Log(enemyState);
        }
    }
}
