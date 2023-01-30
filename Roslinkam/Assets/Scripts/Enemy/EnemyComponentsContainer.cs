using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponentsContainer : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private EnemyAnimatorController enemyAnimatorController;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private EnemyTargetFinder enemyTargetFinder;

    public EnemyMovement EnemyMovement => enemyMovement;
    public EnemyAnimatorController EnemyAnimatorController => enemyAnimatorController;
    public EnemyController EnemyController => enemyController;
    public Animator EnemyAnimator => enemyAnimator;
    public EnemyTargetFinder EnemyTargetFinder => enemyTargetFinder;

}
