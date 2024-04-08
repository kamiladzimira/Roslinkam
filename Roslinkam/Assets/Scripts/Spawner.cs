using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    #region non public fields
    
    [SerializeField] 
    private Bullet _bulletPrefab;
    [SerializeField] 
    private int _defaultCapacity = 200;
    [SerializeField] 
    private int _maxCapacity = 500;

    private ObjectPool<Bullet> _bulletPool;
    
    #endregion

    #region public fields
    
    public static Spawner Instance { get; private set;}
    
    #endregion

    #region non public methods
    
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
    private void Start()
    {
        _bulletPool = new ObjectPool<Bullet>( CreateBullet, (Bullet bullet) =>
        {
            bullet.gameObject.SetActive(true);
        },  (Bullet bullet) =>
        {
            bullet.gameObject.SetActive(false);
            bullet.transform.SetParent(transform);
            bullet.ResetBullet();
        },  (Bullet bullet) =>
        {
            Destroy(bullet.gameObject);
        },  false,  _defaultCapacity, _maxCapacity);
    } 

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(_bulletPrefab);
        return bullet;
    }
    
    #endregion

    #region public methods
    
    public Bullet GetBullet()
    {
        return _bulletPool.Get();
    }

    public void ReturnBulletBackToPool(Bullet bullet)
    {
        _bulletPool.Release(bullet);
    }
    
    #endregion
}
