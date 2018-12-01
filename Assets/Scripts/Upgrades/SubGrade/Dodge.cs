using UnityEngine;

public class Dodge : SubGrade
{
    private GameObject player;
    private Animator dodgeAnim;

    private bool isDodging = false;

    public override void GainAbility()
    {
        player = transform.parent.gameObject;
        dodgeAnim = GetComponent<Animator>();
    }

    public override void RemoveAbility()
    {
        player.GetComponent<PlayerController>().StopAllCoroutines();
        player.tag = "Player";
        Destroy(this);
    }

    public override void UseAbility()
    {
        if (!player.GetComponent<PlayerController>().GetIsInvulnerable())
        {
            dodgeAnim.Play("Dodged");
            StartCoroutine(player.GetComponent<PlayerController>().Invulnerable(1f));
        }
    }
}
