
public class Slash : RegularShot {

    public override void ShootProjectile()
    {
        var slash = Instantiate(bulletTrail, transform.position + transform.up * 0.5f, transform.rotation,transform);
        Destroy(slash, 0.5f);

        if (isPlayerShooting)
            HealthBar.instance.ReduceHealth(damage, true);
    }
}
