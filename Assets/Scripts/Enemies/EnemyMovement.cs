using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] protected EnemyDifficulty difficulty;
    [SerializeField] protected GameObject explodeEffect;
    [SerializeField] protected float shootInterval = 1f;
	[SerializeField] protected float maxHealth = 20f;
    [SerializeField] protected float spikedDamage = 5;

    protected bool canShoot = true;
    private RegularShot rs;

    // Initialize sprite and health
	protected virtual void Start(){
        rs = GetComponent<RegularShot>();
        maxHealth *= difficulty.HealthIncreasedMultiplier;

        InvokeRepeating("FireShot", 1f, shootInterval);
	}

    protected virtual void FireShot()
    {
        if (canShoot)
        {
            rs.ShootProjectile();
        }
    }

    // Play explode animation when health reaches to 0
    public void TakeDamage(float amount){
        maxHealth -= amount;
		if (maxHealth <= 0) {

            canShoot = false;
            StartCoroutine(Explode());
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spike")
        {
            TakeDamage(spikedDamage * difficulty.DamageReducedMultiplier);
        }
    }

    // Explode animation, temporary uninteractable for 1 second
    protected IEnumerator Explode()
    {
        GetComponent<Animator>().Play("EnemyExplode");
        var effect = Instantiate(explodeEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
