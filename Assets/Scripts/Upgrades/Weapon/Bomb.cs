using System.Collections;
using UnityEngine;

public class Bomb : RegularShot {

    private bool canShoot = true;

    public override void ShootProjectile()
    {
        if (canShoot)
        {
            var effect = Instantiate(particle, transform.position + transform.up * 0.5f, transform.rotation, transform);
            base.ShootProjectile();
            StartCoroutine(Cooldown());
            Destroy(effect, 0.5f);
        }
    }

    private IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
}
