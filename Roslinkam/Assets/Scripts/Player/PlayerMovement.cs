using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb2D;
    Vector2 movementVector;
    Animator animator;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void OnWalk(InputAction.CallbackContext context)
    {
       movementVector = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        rb2D.MovePosition(rb2D.position + (movementVector * moveSpeed * Time.fixedDeltaTime));

        if (movementVector.magnitude > Mathf.Epsilon)
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("XSpeed", movementVector.x);
            animator.SetFloat("YSpeed", movementVector.y);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
}
