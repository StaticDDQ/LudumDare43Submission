using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyWing : EnemyMovement {

    [SerializeField] private float hitDamage = 10f;
    [SerializeField] private float speed = 2f;
    private Rigidbody2D rb;
    private bool isColliding = false;
    private Transform target;

    // Use this for initialization
    protected override void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate () {
        rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isColliding && collision.transform.tag == "Wall")
        {
            transform.Rotate(0, 0, transform.rotation.z + 180 + Random.Range(-45,45));
            transform.rotation = Quaternion.LookRotation(transform.forward, target.position - transform.position);
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(hitDamage);
        }

        isColliding = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }
}
