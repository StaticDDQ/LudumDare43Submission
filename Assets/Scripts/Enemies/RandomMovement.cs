using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RandomMovement : FollowTarget {

    [SerializeField] private Vector2 minRange;
    [SerializeField] private Vector2 maxRange;
    [SerializeField] private bool isHarmful = true;
    private Vector2 targetPoint;
    private bool hasCollided = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        SetRandomPosition();
	}

    private void SetRandomPosition()
    {
        float x = Random.Range(minRange.x, maxRange.x);
        float y = Random.Range(minRange.y, maxRange.y);
        targetPoint = new Vector2(x, y);
    }
	
	// Update is called once per frame
	private void FixedUpdate () {

        Vector2 dir = targetPoint - rb.position;

        dir.Normalize();

        float rotAmount = Vector3.Cross(dir, transform.up).z;
        rb.angularVelocity = -rotAmount * rotSpeed;

        rb.velocity = transform.up * speed;

        if (Vector2.Distance(transform.position, targetPoint) < 5f)
        {
            SetRandomPosition();
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasCollided)
        {
            Collider2D cd = collision.contacts[0].collider;
            if (cd.tag == "Wall")
            {
                transform.rotation = Quaternion.LookRotation(transform.forward, targetPoint - (Vector2)transform.position);
            }
            else if (isHarmful && cd.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerController>().TakeDamage(hitDamage);
            }
        }

        hasCollided = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        hasCollided = false;
    }
}
