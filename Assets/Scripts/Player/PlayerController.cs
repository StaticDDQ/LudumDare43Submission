using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    [SerializeField] private float force;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject bulletTrail;

    private Camera cam;
    private Rigidbody2D rigid;

    private void Awake()
    {
        cam = Camera.main;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = cam.ScreenToWorldPoint(mousePos);

            Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

            transform.up = direction;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShootProjectile();
            }
        }
    }

    private void ShootProjectile()
    {
        var bullet = (GameObject)Instantiate(bulletTrail, transform.position + transform.up * 0.9f, transform.rotation);

        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;
        Destroy(bullet, 1.1f);
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * force;
        float moveVertical = Input.GetAxis("Vertical") * force;
        Vector2 dir = new Vector2(moveHorizontal, moveVertical);

        rigid.AddForce(dir, ForceMode2D.Force);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    // Explode animation, temporary uninteractable for 1 second
    private void Explode()
    {
        // Spawn particle system
        Destroy(gameObject);
    }
}
