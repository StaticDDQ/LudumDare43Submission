using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] protected GameObject explodeEffect;
    [SerializeField] protected float shootInterval = 1f;
	[SerializeField] protected float maxHealth = 20f;
    protected bool canShoot = true;
    private RegularShot rs;

    // Initialize sprite and health
	protected virtual void Start(){
        rs = GetComponent<RegularShot>();

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

    // Explode animation, temporary uninteractable for 1 second
    protected IEnumerator Explode()
    {
        GetComponent<Animator>().Play("explodeAnimEnemy");
        Instantiate(explodeEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
