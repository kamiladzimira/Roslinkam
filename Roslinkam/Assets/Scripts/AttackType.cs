using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackType : MonoBehaviour
{
    public abstract void DoAttack(int damage);
}
