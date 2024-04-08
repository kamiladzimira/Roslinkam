using UnityEngine;

public class EnemyComponentsContainer : MonoBehaviour
{
    #region non public fields

    [SerializeField] 
    private EnemyMovement _enemyMovement;
    [SerializeField] 
    private EnemyAnimatorController _enemyAnimatorController;
    [SerializeField] 
    private EnemyStateController _enemyController;
    [SerializeField] 
    private Animator _enemyAnimator;
    [SerializeField] 
    private EnemyTargetFinder _enemyTargetFinder;
    [SerializeField] 
    private HealthController _enemyHealthController;
    
    #endregion

    #region public fields

    public EnemyMovement EnemyMovement => _enemyMovement;
    public EnemyAnimatorController EnemyAnimatorController => _enemyAnimatorController;
    public EnemyStateController EnemyController => _enemyController;
    public Animator EnemyAnimator => _enemyAnimator;
    public EnemyTargetFinder EnemyTargetFinder => _enemyTargetFinder;
    public HealthController HealthController => _enemyHealthController;

    #endregion

    #region non public methods
    #endregion

    #region public methods
    #endregion
}
