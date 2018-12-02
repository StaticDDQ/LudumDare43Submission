using UnityEngine;

public class EnemyShooter : EnemyMovement {

    [SerializeField] private RegularShot shoot1;
    [SerializeField] private RegularShot shoot2;
    [SerializeField] private RegularShot shoot3;
    [SerializeField] private RegularShot shoot4;

    protected override void Start()
    {
        InvokeRepeating("FireShot", 1f, shootInterval);
    }

    protected override void FireShot()
    {
        if (canShoot)
        {
            shootAudio.Play();
            shoot1.ShootProjectile();
            shoot2.ShootProjectile();
            shoot3.ShootProjectile();
            shoot4.ShootProjectile();
        }
    }
}
