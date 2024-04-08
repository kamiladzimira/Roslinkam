using UnityEngine;

public class EnemyTargetFinder : MonoBehaviour
{
    #region non public fields

    private HealthController _target;
    
    #endregion

    #region public fields

    public HealthController Target => _target;

    #endregion

    #region non public methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerComponentsContainer tmpTarget = collision.GetComponent<PlayerComponentsContainer>();
        if (tmpTarget == null)
        {
            return;
        }
        _target = tmpTarget.HealthController;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        HealthController tmpTarget = collision.GetComponent<HealthController>();
        if (tmpTarget != _target)
        {
            return;
        }
        _target = null;
    }

    #endregion

    #region public methods
    #endregion
}
