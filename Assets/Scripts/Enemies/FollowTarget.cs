using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowTarget : MonoBehaviour {

    [SerializeField] private Transform target;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotSpeed = 2f;

    private Rigidbody2D rb;

	// Use this for initialization
	private void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	private void FixedUpdate () {
        Vector2 dir = (Vector2) target.position - rb.position;

        dir.Normalize();

        float rotAmount = Vector3.Cross(dir, transform.up).z;
        rb.angularVelocity = -rotAmount * rotSpeed;

        rb.velocity = transform.up * speed;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Wall")
            transform.rotation = Quaternion.LookRotation(transform.forward, target.position - transform.position);
    }

    public void SetTarget(Transform newTarget)
    {
        this.target = newTarget;
    }
}
