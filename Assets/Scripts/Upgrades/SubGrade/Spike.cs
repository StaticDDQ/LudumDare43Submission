using UnityEngine;
using System.Collections;

public class Spike : SubGrade {
    
    private Animator spikeAnimator;
    private bool animPlaying = false;

    public override void GainAbility()
    {
        spikeAnimator = GetComponent<Animator>();
    }

    public override bool RemoveAbility()
    {
        if (animPlaying)
            return false;

        Destroy(this, 0.1f);
        return true;
    }

    public override void UseAbility()
    {
        if (!animPlaying)
            StartCoroutine(GenerateSpike());
    }

    private IEnumerator GenerateSpike()
    {
        animPlaying = true;
        spikeAnimator.Play("Spiked");
        yield return new WaitForSeconds(2);
        animPlaying = false;
    }
}
