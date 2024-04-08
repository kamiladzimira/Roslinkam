using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Subsystems;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _rotationSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private float _followTime = 2;
    [SerializeField] private float _lifeTime = 6;
    private EnemyComponentsContainer _enemyComponentsContainer;
    private HealthController _target;
    private float _timer = 0;
    private Vector3 _direction;

    public int Damage => _damage;

    private void Update()
    {
        _timer += Time.deltaTime;
        if(_target == null)
        {
            Spawner.Instance.ReturnBulletBackToPool(this);
            return;
        }
        CalculateRotation();
        ChangeRotation();
        MoveBullet(_speed);
        if (_timer > _lifeTime)
        {
            Spawner.Instance.ReturnBulletBackToPool(this);
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
        CalculateRotation();
        transform.rotation = Quaternion.LookRotation(Vector3.back, _direction);
    }

    public void ResetBullet()
    {
        _timer = 0;
        _target = null;
        _direction = Vector3.zero;
        _enemyComponentsContainer = null;
    }

    private void MoveBullet(int speed)
    {
        Vector3 newPosition = transform.position + transform.up * speed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void CalculateRotation()
    {
        if (_timer <= _followTime)
        {
            _direction = (_target.transform.position - transform.position).normalized;
        }
    }

    private void HandleDealDamage(Collider2D collision)
    {
        HealthController target = collision.GetComponent<HealthController>();

        if (target == null)
        {
            return;
        }
        target.GetDamage(_damage);
        Spawner.Instance.ReturnBulletBackToPool(this);
    }

    private void ChangeRotation()
    {
        Quaternion rotationTarget = Quaternion.LookRotation(Vector3.back, _direction);
        Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, rotationTarget, _rotationSpeed * Time.deltaTime);
        transform.rotation = newRotation;
    }
}
