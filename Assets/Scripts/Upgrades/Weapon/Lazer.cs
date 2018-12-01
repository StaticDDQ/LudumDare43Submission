using UnityEngine;
using System.Collections;

public class Lazer : RegularShot {

    [SerializeField] private GameObject lazerObj;
    private bool isFiring = false;

    public override void ShootProjectile()
    {
        if (!isFiring)
        {
            isFiring = true;

        }
    }

    
}
