using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimatorController : MonoBehaviour
{
    #region non public fields

    [SerializeField] 
    private Animator _enemyAnimator;
    [SerializeField]
    private UnityEvent _onAttack;

    #endregion

    #region public fields
    #endregion

    #region non public methods
    #endregion

    #region public methods

    public void OnAttack()
    {
        _onAttack?.Invoke();
    }

    public void ResetAllTriggers()
    {
        _enemyAnimator.ResetTrigger("Trigger");
        _enemyAnimator.ResetTrigger("Walk");
        _enemyAnimator.ResetTrigger("Attack");
    }
    
    #endregion
}
