using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(RegularShot))]
public class PlayerController : MonoBehaviour {

    [SerializeField] private float force;

    private Camera cam;
    private Rigidbody2D rigid;
    private RegularShot shootAbility;
    private bool isInvulnerable = false;
    private bool canControl = true;

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
            if (canControl)
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos = cam.ScreenToWorldPoint(mousePos);

                Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

                transform.up = direction;
            }

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

    public void TakeDamage(float amount)
    {
        if (!isInvulnerable)
        {
            HealthBar.instance.ReduceHealth(amount, false);
            StartCoroutine(Invulnerable(2f));
        }
    }

    private IEnumerator Invulnerable(float dur)
    {
        isInvulnerable = true;
        gameObject.layer = 12;
        GetComponent<Animator>().Play("invulnerableState");
        yield return new WaitForSeconds(dur);
        gameObject.layer = 8;
        isInvulnerable = false;
    }

    public bool GetIsInvulnerable()
    {
        return this.isInvulnerable;
    }

    public void SetCanControl(bool control)
    {
        this.canControl = control;
    }
}
