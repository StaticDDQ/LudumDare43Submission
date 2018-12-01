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

    public override bool RemoveAbility()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        return true;
    }

    public override void UseAbility()
    {
        if (canBlink && !isBlinking)
            StartCoroutine(Blinking());
    }

    private IEnumerator Blinking()
    {
        isBlinking = false;
        player.GetComponent<Animator>().Play("Blinked");
        yield return new WaitForSeconds(0.25f);
        transform.position = (Vector2) mainCam.ScreenToWorldPoint(Input.mousePosition);
        yield return new WaitForSeconds(1f);
        isBlinking = true;
    }

    private void Update()
    {
        float dist = Vector2.Distance(player.transform.position, (Vector2)mainCam.ScreenToWorldPoint(Input.mousePosition));
        if(dist <= maxDist)
        {
            canBlink = true;
        } else
        {
            canBlink = false;
        }
    }
}
