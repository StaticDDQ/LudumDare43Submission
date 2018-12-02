using UnityEngine;

public class RegularShot : MonoBehaviour {

    public float bulletSpeed;
    public GameObject particle;
    [SerializeField] protected bool isPlayerShooting = true;
    public float damage = 2f;
    public GameObject bulletTrail;

    public virtual void ShootProjectile()
    {
        var bullet = Instantiate(bulletTrail, transform.position, transform.rotation);

        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;

        if(isPlayerShooting)
            HealthBar.instance.ReduceHealth(damage, true);
    }
}
