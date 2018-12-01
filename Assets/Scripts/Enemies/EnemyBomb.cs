using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyBomb : MonoBehaviour {

    [SerializeField] private float damage = 10f;
    [SerializeField] private float timer = 5f;
    [SerializeField] private float maxRange = 5f;
    [SerializeField] private float explodeSpeed = 2f;
    [SerializeField] private Transform explodeSprite;
    private Vector2 maxExplodeRadius;
    private CircleCollider2D c;

    private void Start()
    {
        c = GetComponent<CircleCollider2D>();
        maxExplodeRadius = Vector2.one * maxRange;
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        } else
        {
            c.radius = Mathf.Lerp(0, maxRange, Time.deltaTime * explodeSpeed);
            explodeSprite.localScale = Vector2.Lerp(Vector2.zero, maxExplodeRadius, Time.deltaTime * explodeSpeed);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
