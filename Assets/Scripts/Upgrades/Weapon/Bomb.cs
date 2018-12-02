using System.Collections;
using UnityEngine;

public class Bomb : RegularShot {

    private bool canShoot = true;

    public override void ShootProjectile()
    {
        if (canShoot)
        {
            Instantiate(particle, transform.position, transform.rotation);
            base.ShootProjectile();
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
}
