using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set;}

    [SerializeField] private Bullet _bulletPrefab;
    //[SerializeField] private int _spawnAmount = 20;
    [SerializeField] private int _defaultCapacity = 200;
    [SerializeField] private int _maxCapacity = 500;
    private ObjectPool<Bullet> _bulletPool;
  
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        _bulletPool = new ObjectPool<Bullet>(createFunc: CreateBullet, actionOnGet: (bullet) =>
        {
            bullet.gameObject.SetActive(true);
        }, (bullet) =>
        {
            bullet.gameObject.SetActive(false);
            bullet.transform.SetParent(transform);
            bullet.ResetBullet();
        }, (bullet) =>
        {
            Destroy(bullet.gameObject);
        }, collectionCheck: false, _defaultCapacity, _maxCapacity);
    } 

    private Bullet CreateBullet()
    {
        var bullet = Instantiate(_bulletPrefab);
        return bullet;
    }

    public Bullet GetBullet()
    {
        return _bulletPool.Get();
    }

    public void ReturnBulletBackToPool(Bullet bullet)
    {
        _bulletPool.Release(bullet);
    }
}
