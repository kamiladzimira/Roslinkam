using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking.Types;
using UnityEngine.Serialization;
using UnityEngine.Subsystems;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _damage;
    private EnemyComponentsContainer _enemyComponentsContainer;
    private HealthController _target;
    private float _timer = 0;
    private float _followTime = 2;
    private float _lifeTime = 3;
    private Vector3 _direction;

    public int Damage => _damage;

    private void Update()
    {
        _timer += Time.deltaTime;
        MoveBullet(_speed);
        if (_timer > _lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleDealDamage(collision);
    }

    public void Setup(EnemyComponentsContainer container)
    {
        _enemyComponentsContainer = container;
        _target = _enemyComponentsContainer.EnemyTargetFinder.Target;
    }

    private void MoveBullet(int speed)
    {
        if (_timer <= _followTime)
        {
            _direction = (_target.transform.position - transform.position).normalized;
        }
        Vector3 newPosition = transform.position + _direction * speed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void HandleDealDamage(Collider2D collision)
    {
        HealthController target = collision.GetComponent<HealthController>();

        if (target == null)
        {
            return;
        }
        target.GetDamage(_damage);
        Destroy(gameObject);
    }
}
