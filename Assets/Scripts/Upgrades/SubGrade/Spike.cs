using UnityEngine;
using System.Collections;

public class Spike : SubGrade {
    
    private Animator spikeAnimator;
    private bool animPlaying = false;

    public override void GainAbility()
    {
        spikeAnimator = GetComponent<Animator>();
    }

    public override void RemoveAbility()
    {
        Destroy(this);
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
