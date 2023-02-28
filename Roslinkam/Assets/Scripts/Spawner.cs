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
    [SerializeField] private int _spawnAmount = 20;
    private ObjectPool<Bullet> _bulletPool;
    private ShootAttack _shootAttack;
    Action<int, string> a;

    Func<int, string> b;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        a += (i,s) => { };

        b += (name) => { return "g"; };

        string Example2(int y)
        {
            return "g";
        }

        void Example(int g, string t)
        {

        }

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
        }, collectionCheck: false, 10, 20);
    } 

    private Bullet CreateBullet()
    {
        var bullet = Instantiate(_bulletPrefab);
        //bullet.Setup()
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
