using UnityEngine;

public class RegularShot : MonoBehaviour {

    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected GameObject bulletTrail;
    [SerializeField] protected float damage = 2f;

    public virtual void ShootProjectile()
    {
        var bullet = Instantiate(bulletTrail, transform.position, transform.rotation);

        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;
        HealthBar.instance.ReduceHealth(damage, true);
    }
}
