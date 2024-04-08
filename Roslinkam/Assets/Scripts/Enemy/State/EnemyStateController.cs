using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    #region non public fields

    [SerializeField]
    private Animator _enemyMovementAnimator;
    [SerializeField]
    private EnemyComponentsContainer _enemyComponentsContainer;
    [SerializeField]
    private float _attackDistance;
    private IEnemyState _enemyState;

    #endregion

    #region public fields

    public StateIdle StateIdle { get; private set; }
    public StateTrigger StateTrigger { get; private set; }
    public StateAttack StateAttack { get; private set; }
    public StateFollowPrey StateWalkToTarget { get; private set; }
    public Animator EnemyMovementAnimator => _enemyMovementAnimator;
    public float AttackDistance => _attackDistance;

    #endregion

    #region non public methods

    private void Awake()
    {
        StateIdle = new StateIdle(_enemyComponentsContainer);
        StateTrigger = new StateTrigger(_enemyComponentsContainer);
        StateAttack = new StateAttack(_enemyComponentsContainer);
        StateWalkToTarget = new StateFollowPrey(_enemyComponentsContainer);
        _enemyState = StateIdle;
        _enemyState.OnEnter();
    }

    private void Update()
    {
        IEnemyState lastState = _enemyState;
        _enemyState = _enemyState.DoState();
        if (lastState != _enemyState)
        {
            _enemyState.OnEnter();
        }
    }

    #endregion

    #region public methods
    #endregion
}
