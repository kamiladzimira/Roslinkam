using UnityEngine;

public class EnemyTargetFinder : MonoBehaviour
{
    private HealthController target;

    public HealthController Target => target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerComponentsContainer tmpTarget = collision.GetComponent<PlayerComponentsContainer>();
        if (tmpTarget == null)
        {
            return;
        }
        target = tmpTarget.HealthController;
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
