using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyWing : EnemyMovement {

    private Transform target;
    [SerializeField] protected float hitDamage = 10f;
    [SerializeField] protected float speed = 2f;
    private Rigidbody2D rb;

    // Use this for initialization
    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void FixedUpdate () {
        rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall" && target != null)
        {
            transform.rotation = Quaternion.LookRotation(transform.forward, target.position - transform.position);
            print(transform.rotation);
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(hitDamage);
        }
    }
}
