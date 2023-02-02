using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private int damage;
    [SerializeField] protected AttackType attackType;

    public void TryDoAttack()
    {
        attackType?.DoAttack(damage);
    }

    public void SetAttackType(AttackType newAttackType)
    {
        attackType = newAttackType;
    }
}
