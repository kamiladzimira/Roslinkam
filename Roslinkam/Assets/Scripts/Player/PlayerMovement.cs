using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region non public fields
    
    [SerializeField] 
    private float _moveSpeed = 5f;
    private Rigidbody2D _rb2D;
    private Vector2 _movementVector;
    private Animator _animator;
    
    #endregion

    #region public fields
    #endregion

    #region non public methods

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    private void Move()
    {
        _rb2D.MovePosition(_rb2D.position + (_movementVector * _moveSpeed * Time.fixedDeltaTime));

        if (_movementVector.magnitude > Mathf.Epsilon)
        {
            _animator.SetBool("isWalking", true);
            _animator.SetFloat("XSpeed", _movementVector.x);
            _animator.SetFloat("YSpeed", _movementVector.y);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    #endregion

    #region public methods

    public void OnWalk(InputAction.CallbackContext context)
    {
       _movementVector = context.ReadValue<Vector2>();
    }

    #endregion
}