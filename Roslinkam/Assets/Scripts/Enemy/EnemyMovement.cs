using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    #region non public fields

    [SerializeField]
    private List<Transform> _route;
    [SerializeField]
    private float _positionAccuracy = 0.5f;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private SpriteRenderer _sprite;
    [SerializeField]
    private int _speed;

    private Vector2 _lastPos;

    #endregion

    #region public fields

    public List<Transform> Route => _route;
    public float PositionAccuracy => _positionAccuracy;
    public int Speed => _speed;

    #endregion

    #region non public methods

    private void Awake()
    {
        _lastPos = transform.position;
    }

    private void FlipSprite(Vector2 movementDirection)
    {
        if (movementDirection.x < 0)
        {
            _sprite.flipX = true;
        }
        else
        {
            _sprite.flipX = false;
        }
    }

    #endregion

    #region public methods

    public void Move(Transform currentTarget)
    {
        _lastPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, _speed * Time.deltaTime);
        Vector2 movementdirection = ((Vector2)transform.position - _lastPos).normalized;
        FlipSprite(movementdirection);
    }

    #endregion
}