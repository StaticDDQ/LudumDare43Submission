using UnityEngine;

public class Lazer : RegularShot {

    private GameObject l;

    public override void ShootProjectile()
    {
        if(l == null)
        {
            l = Instantiate(bulletTrail, transform.position + transform.up * 0.75f, transform.rotation, transform);
            Destroy(l, 0.25f);
        }
    }

    
}
