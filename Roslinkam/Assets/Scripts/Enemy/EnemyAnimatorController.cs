using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    [SerializeField]
    private UnityEvent onAttack;
    public void OnAttack()
    {
        onAttack?.Invoke();
    }

    public void ResetAllTriggers()
    {
        enemyAnimator.ResetTrigger("Trigger");
        enemyAnimator.ResetTrigger("Walk");
        enemyAnimator.ResetTrigger("Attack");
    }
}


