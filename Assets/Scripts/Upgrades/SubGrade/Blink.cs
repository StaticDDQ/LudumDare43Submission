using UnityEngine;
using System.Collections;

public class Blink : SubGrade {

    [SerializeField] private float maxDist = 2f;
    [SerializeField] private Texture2D newCursor;
    private GameObject player;
    private Camera mainCam;
    private bool canBlink = true;
    private bool isBlinking = false;

    public override void GainAbility()
    {
        player = transform.parent.gameObject;
        mainCam = Camera.main;
        Cursor.SetCursor(newCursor,Vector2.zero, CursorMode.Auto);
    }

    public override void RemoveAbility()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Destroy(this.gameObject);
    }

    public override void UseAbility()
    {
        if (canBlink && !isBlinking)
            StartCoroutine(Blinking());
    }

    private IEnumerator Blinking()
    {
        isBlinking = true;
        player.GetComponent<Animator>().Play("Blinked");
        yield return new WaitForSeconds(0.25f);
        player.transform.position = (Vector2) mainCam.ScreenToWorldPoint(Input.mousePosition);
        yield return new WaitForSeconds(1f);
        isBlinking = false;
    }

    private void Update()
    {
        float dist = Vector2.Distance(player.transform.position, mainCam.ScreenToWorldPoint(Input.mousePosition));

        if(dist <= maxDist)
        {
            //indication you can
            canBlink = true;
        } else
        {
            //indication you cannot
            canBlink = false;
        }
    }
}
