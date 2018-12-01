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

    public override bool RemoveAbility()
    {
        if (player.GetComponent<PlayerController>().GetIsInvulnerable())
            return false;
        Destroy(this, 0.1f);
        return true;
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
