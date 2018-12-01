using UnityEngine;

public class EnemyBomb : MonoBehaviour {

    [SerializeField] private float timer = 5f;
    [SerializeField] private GameObject explosion;
    [SerializeField] private Color minColor;
    [SerializeField] private Color maxColor;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer < 2)
            {
                sr.color = Color.Lerp(sr.color, maxColor, Time.deltaTime * 5f);
            } else
            {
                sr.color = Color.Lerp(minColor, maxColor, Mathf.PingPong(Time.time, 1));
            }
        }
        else
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
