using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowTarget : MonoBehaviour {

    protected Transform target;
    [SerializeField] protected float hitDamage = 10f;
    [SerializeField] protected float speed = 2f;
    [SerializeField] private float rotSpeed = 2f;

    protected Rigidbody2D rb;

	// Use this for initialization
	protected void Start () {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	private void FixedUpdate () {
        if(target != null)
        {
            Vector2 dir = (Vector2)target.position - rb.position;

            dir.Normalize();

            float rotAmount = Vector3.Cross(dir, transform.up).z;
            rb.angularVelocity = -rotAmount * rotSpeed;
        }

        rb.velocity = transform.up * speed;
	}

    protected virtual void OnCollisionEnter2D(Collision2D collision)
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
