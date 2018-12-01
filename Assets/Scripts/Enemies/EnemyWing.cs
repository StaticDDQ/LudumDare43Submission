using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyWing : FollowTarget {
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = transform.up * speed;
    }
}
