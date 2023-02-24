using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] int damage;
    private EnemyComponentsContainer enemyComponentsContainer;
    private HealthController target;

    public int Damage => damage;

    private void Update()
    {
        MoveBullet(speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleDealDamage(collision);

    }

    public void Setup(EnemyComponentsContainer container)
    {
        enemyComponentsContainer = container;
        target = enemyComponentsContainer.EnemyTargetFinder.Target;
    }

    private void MoveBullet(int speed)
    {
        transform.position = Vector2.MoveTowards(transform.position,
            target.transform.position, Time.deltaTime * speed);
    }

    private void HandleDealDamage(Collider2D collision)
    {
        HealthController target = collision.GetComponent<HealthController>();

        if (target == null)
        {
            return;
        }
        target.GetDamage(damage);
        Destroy(gameObject);
    }

}
