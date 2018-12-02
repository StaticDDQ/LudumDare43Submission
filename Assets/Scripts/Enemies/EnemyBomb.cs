using UnityEngine;

public class EnemyBomb : MonoBehaviour {

    private float timer;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private GameObject explosion;
    [SerializeField] private Color minColor;
    [SerializeField] private Color maxColor;
    private SpriteRenderer sr;
    private bool hasExploded = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        timer = Random.Range(10, 15);
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
            if (!hasExploded)
            {
                hasExploded = true;
                Instantiate(explosion, transform.position, Quaternion.identity);
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Camera.main.GetComponent<CameraShake>().DoShake();
                Destroy(gameObject);
            }
        }
    }
}
