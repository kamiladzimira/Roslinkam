using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> route;
    [SerializeField] private float positionAccuracy = 0.5f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private int speed;
    private Vector2 lastPos;
    public List<Transform> Route => route;
    public float PositionAccuracy => positionAccuracy;
    public int Speed => speed;
    private void Awake()
    {
        lastPos = transform.position;
    }

    public void Move(Transform currentTarget)
    {
        lastPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
        Vector2 movementdirection = ((Vector2)transform.position - lastPos).normalized;
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