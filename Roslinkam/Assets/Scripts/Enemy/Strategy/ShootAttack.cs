using UnityEngine;

public class ShootAttack : AttackType
{
    [SerializeField] private EnemyComponentsContainer enemyComponentsContainer;
    [SerializeField] private Bullet bullet;

    public override void DoAttack(int damage)
    {
        CreateBullet(bullet);
    }

    public void CreateBullet(Bullet bullet)
    {
        Bullet currentBullet = Spawner.Instance.GetBullet();
        currentBullet.transform.SetParent(null);
        currentBullet.transform.position = transform.position;
        currentBullet.Setup(enemyComponentsContainer);
    }
}
