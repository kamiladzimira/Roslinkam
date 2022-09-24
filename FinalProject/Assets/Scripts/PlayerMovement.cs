using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb2D;
    Vector2 movementVector;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void OnWalk(InputAction.CallbackContext context)
    {
       movementVector = context.ReadValue<Vector2>();
       
    }

    private void OnMove()
    {
        rb2D.MovePosition(rb2D.position + movementVector * moveSpeed * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        OnMove();
    }
}
