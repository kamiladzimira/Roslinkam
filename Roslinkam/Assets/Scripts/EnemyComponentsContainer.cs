using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponentsContainer : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private EnemyAnimatorController enemyAnimatorController;
    [SerializeField] private EnemyController enemyController;

    public EnemyMovement EnemyMovement => enemyMovement;
    public EnemyAnimatorController EnemyAnimatorController => enemyAnimatorController;
    public EnemyController EnemyController => enemyController;
}
