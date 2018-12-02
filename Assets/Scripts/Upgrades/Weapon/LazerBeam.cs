using UnityEngine;

public class LazerBeam : MonoBehaviour {

    private LineRenderer lr;
    [SerializeField] private EnemyDifficulty difficulty;
    [SerializeField] private Transform hitPoint;
    [SerializeField] private float dmg = 5f;
    private bool hasHit = false;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        hitPoint.position = hit.point;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, hitPoint.position);
       
        if(hit.collider.tag == "Enemy" && !hasHit)
        {
            hit.collider.GetComponent<EnemyMovement>().TakeDamage(dmg * difficulty.DamageReducedMultiplier);
            hasHit = true;
        }
	}
}
