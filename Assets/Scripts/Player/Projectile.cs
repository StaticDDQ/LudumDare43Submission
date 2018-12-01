using UnityEngine;

public class Projectile : MonoBehaviour {

    private float damageAmount = 10f;
    [SerializeField] private bool enemyBullet = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!enemyBullet && collision.gameObject.tag == "Enemy")
        {
            //apply damage
        }
        else if (enemyBullet && collision.gameObject.tag == "Player")
        {

        }

        Destroy(gameObject);
    }
}
