using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimatorController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onAttack;
    public void OnAttack()
    {
        onAttack?.Invoke();
    }
}


