using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetFinder : MonoBehaviour
{
    private HealthController target;

    public HealthController Target => target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthController tmpTarget = collision.GetComponent<HealthController>();
        if (tmpTarget == null)
        {
            return;
        }
        if (tmpTarget.GetComponent<PlayerComponentsContainer>() == null)
        {
            return;
        }
        target = tmpTarget;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        HealthController tmpTarget = collision.GetComponent<HealthController>();
        if (tmpTarget != target)
        {
            return;
        }
        target = null;
    }
}