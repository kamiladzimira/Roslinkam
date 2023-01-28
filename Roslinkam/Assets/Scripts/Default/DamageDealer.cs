using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int damage;
    private HealthController target;

    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        target = collision.GetComponent<HealthController>();
        if (target != null)
        {
            animator.SetTrigger("Attack");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetTrigger("Walk");
    }

    public void DealDamageToTarget()
    {
        target.GetDamage(damage);
    }
}
