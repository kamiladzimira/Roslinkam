using UnityEngine;

public class PlayerTargetFinder : MonoBehaviour
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
        HealthController tmpTarget = collision.GetComponent<HealthController>();
        if (tmpTarget == null)
        {
            return;
        }
        _target = tmpTarget;
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
