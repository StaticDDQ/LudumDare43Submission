using UnityEngine;
using System.Collections;

public class Dodge : SubGrade
{
    [SerializeField] private float speed = 2f;
    private GameObject player;

    private bool isDodging = false;

    public override void GainAbility()
    {
        player = transform.parent.gameObject;
    }

    public override void RemoveAbility()
    {
        player.tag = "Player";
        player.GetComponent<PlayerController>().SetCanControl(true);

        Destroy(this.gameObject);
    }

    public override void UseAbility()
    {
        if (!isDodging)
        {
            StartCoroutine(Dodged(1f));
        }
    }

    private IEnumerator Dodged(float dur)
    {
        isDodging = true;

        player.GetComponent<PlayerController>().SetCanControl(false);

        player.layer = 12;
        float elapsedTime = 0.0f;
        while(elapsedTime < dur)
        {
            player.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        player.GetComponent<PlayerController>().SetCanControl(true);
        player.layer = 8;

        isDodging = false;
    }
}
