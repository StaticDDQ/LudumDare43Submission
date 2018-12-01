using UnityEngine;

public class ExplosionEffect : MonoBehaviour {

    [SerializeField] private float lingerTime = 0.5f;
    [SerializeField] private float maxRange = 5f;
    [SerializeField] private float explodeSpeed = 2f;
    [SerializeField] private float damage = 40f;
    private SpriteRenderer sr;
    private Vector2 maxExplodeRadius;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        maxExplodeRadius = Vector2.one * maxRange;
    }

    private void Update()
    {
        transform.localScale = Vector2.Lerp(transform.localScale, maxExplodeRadius, Time.deltaTime * explodeSpeed);
        sr.color = Color.Lerp(sr.color, Color.clear, Time.deltaTime * lingerTime);
        if (sr.color.a < 0.1f)
            Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
