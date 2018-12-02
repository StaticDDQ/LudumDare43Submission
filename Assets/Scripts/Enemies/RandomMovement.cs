using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RandomMovement : FollowTarget {

    [SerializeField] private Vector2 minRange;
    [SerializeField] private Vector2 maxRange;
    private Vector2 targetPoint;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    private void SetRandomPosition()
    {
        float x = Random.Range(minRange.x, maxRange.x);
        float y = Random.Range(minRange.y, maxRange.y);
        targetPoint = new Vector2(x, y);
    }
	
	// Update is called once per frame
	private void FixedUpdate () {
        if (targetPoint == null)
            SetRandomPosition();
        else
        {
            Vector2 dir = targetPoint - rb.position;

            dir.Normalize();

            float rotAmount = Vector3.Cross(dir, transform.up).z;
            rb.angularVelocity = -rotAmount * rotSpeed;

            rb.velocity = transform.up * speed;

        if (Vector2.Distance(transform.position, targetPoint) < 1)
            {
                SetRandomPosition();
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall" && targetPoint != null)
        {
            transform.rotation = Quaternion.LookRotation(transform.forward, targetPoint - (Vector2)transform.position);
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(hitDamage);
        }
    }
}
