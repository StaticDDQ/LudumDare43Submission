using System.Collections;
using UnityEngine;

public class RapidShot : RegularShot {

    private bool isFiring = false;

    public override void ShootProjectile()
    {
        if (!isFiring)
        {
            StartCoroutine(ShootInSequence());
        }
    }

    private IEnumerator ShootInSequence()
    {
        isFiring = true;
        base.ShootProjectile();
        yield return new WaitForSeconds(0.25f);
        base.ShootProjectile();
        yield return new WaitForSeconds(0.25f);
        base.ShootProjectile();
        isFiring = false;
    }
}
