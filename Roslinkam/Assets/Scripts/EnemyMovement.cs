using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> route;
    [SerializeField] private float positionAccuracy = 0.5f;
    [SerializeField] private float directionAccuracy = 0.1f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private int speed;
    private Transform currentTarget;
    private Vector2 lastPos;
    private int routeIndex;

    private void Awake()
    {
        lastPos = transform.position;
        routeIndex = 0;
        currentTarget = route[routeIndex];
    }

    public void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttack"))
        {
            return;
        }
        Movement();
    }

    private void Movement()
    {
        lastPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        Vector2 movementdirection = ((Vector2)transform.position - lastPos).normalized;

        if (Vector2.Distance(transform.position, currentTarget.position) < positionAccuracy)
        {
            routeIndex = (routeIndex + 1) % route.Count;
            currentTarget = route[routeIndex];
        }
        FlipSprite(movementdirection);
    }

    void FlipSprite(Vector2 movementDirection)
    {
        if (movementDirection.x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
}
