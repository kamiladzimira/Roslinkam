using UnityEngine;

public class ShootAttack : AttackType
{
    #region non public fields

    [SerializeField] 
    private EnemyComponentsContainer _enemyComponentsContainer;
    [SerializeField] 
    private Bullet _bullet;
    
    #endregion

    #region public fields
    #endregion

    #region non public methods
    #endregion

    #region public methods

    public override void DoAttack(int damage)
    {
        CreateBullet(_bullet);
    }

    public void CreateBullet(Bullet bullet)
    {
        Bullet currentBullet = Spawner.Instance.GetBullet();
        currentBullet.transform.SetParent(null);
        currentBullet.transform.position = transform.position;
        currentBullet.Setup(_enemyComponentsContainer);
    }

    #endregion
}
