using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] private float damageAmount = 10f;
    [SerializeField] private bool enemyBullet = false;
    public EnemyDifficulty difficulty;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!enemyBullet && collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyMovement>().TakeDamage(damageAmount * difficulty.DamageReducedMultiplier);
        }
        else if (enemyBullet && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damageAmount * difficulty.DamageIncreasedMultiplier);
        }

        Destroy(gameObject);
    }
}
