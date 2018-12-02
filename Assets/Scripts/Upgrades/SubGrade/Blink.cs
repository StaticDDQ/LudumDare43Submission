using UnityEngine;
using System.Collections;

public class Blink : SubGrade {

    [SerializeField] private GameObject blinkEffect;
    [SerializeField] private float maxDist = 2f;
    [SerializeField] private Texture2D newCursor;
    [SerializeField] private Texture2D failCursor;
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
        var effect = Instantiate(blinkEffect, player.transform.position, Quaternion.identity);
        Destroy(effect, 0.4f);
        player.transform.position = (Vector2) mainCam.ScreenToWorldPoint(Input.mousePosition);
        yield return new WaitForSeconds(0.5f);
        isBlinking = false;
    }

    private void Update()
    {
        float dist = Vector2.Distance(player.transform.position, mainCam.ScreenToWorldPoint(Input.mousePosition));

        if(dist <= maxDist)
        {
            Cursor.SetCursor(newCursor, Vector2.zero, CursorMode.Auto);
            canBlink = true;
        } else
        {
            Cursor.SetCursor(failCursor, Vector2.zero, CursorMode.Auto);
            canBlink = false;
        }
    }
}
