using UnityEngine;

public class GrabWeapon : MonoBehaviour {

    [SerializeField] private RegularShot weaponIcon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().ReplaceWeapon(weaponIcon, weaponIcon.damage, weaponIcon.bulletSpeed, weaponIcon.bulletTrail, weaponIcon.particle);
            Destroy(this.gameObject);
        }
    }
}
