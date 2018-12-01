using UnityEngine;

public class Projectile : MonoBehaviour {

    private float damageAmount = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //apply damage
        }

        Destroy(gameObject);
    }
}
