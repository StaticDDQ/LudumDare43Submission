using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(RegularShot))]
public class PlayerController : MonoBehaviour {

    [SerializeField] private GameObject explodeEffect;
    [SerializeField] private float force;

    private Camera cam;
    private Rigidbody2D rigid;
    private RegularShot shootAbility;
    private bool isInvulnerable = false;

    private void Awake()
    {
        cam = Camera.main;
        rigid = GetComponent<Rigidbody2D>();
        shootAbility = GetComponent<RegularShot>();
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {

            Vector3 mousePos = Input.mousePosition;
            mousePos = cam.ScreenToWorldPoint(mousePos);

            Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

            transform.up = direction;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                shootAbility.ShootProjectile();
            }
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * force;
        float moveVertical = Input.GetAxis("Vertical") * force;
        Vector2 dir = new Vector2(moveHorizontal, moveVertical);

        rigid.AddForce(dir, ForceMode2D.Force);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(!isInvulnerable && collision.transform.tag == "enemy")
        {
            //HealthBar.instance.ReduceHealth(collision.gameObject.GetComponent<EnemyControl>().GetDamage(), false);
            StartCoroutine(Invulnerable(2f));
        }
    }

    public IEnumerator Invulnerable(float dur)
    {
        isInvulnerable = true;
        transform.tag = "Invulnerable";
        GetComponent<Animator>().Play("invulnerableState");
        yield return new WaitForSeconds(dur);
        transform.tag = "Player";
        isInvulnerable = false;
    }

    // Explode animation, temporary uninteractable for 1 second
    private void Explode()
    {
        Instantiate(explodeEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public bool GetIsInvulnerable()
    {
        return this.isInvulnerable;
    }
}
