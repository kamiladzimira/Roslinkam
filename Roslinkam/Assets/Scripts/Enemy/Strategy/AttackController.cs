using UnityEngine;

public class AttackController : MonoBehaviour
{
    #region non public fields

    private int _damage;
    [SerializeField] 
    protected AttackType _attackType;

    #endregion

    #region public fields
    #endregion

    #region non public methods
    #endregion

    #region public methods

    public void TryDoAttack()
    {
        _attackType?.DoAttack(_damage);
    }

    public void SetAttackType(AttackType newAttackType)
    {
        _attackType = newAttackType;
    }

    #endregion
}
