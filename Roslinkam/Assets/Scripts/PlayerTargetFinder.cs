using UnityEngine;

public class PlayerTargetFinder : MonoBehaviour
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
