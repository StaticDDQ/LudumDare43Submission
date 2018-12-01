using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Spike : SubGrade {

    [SerializeField] private Sprite extendedSpike;
    private Collider2D spikeCollider;
    private SpriteRenderer sr;
    private Sprite currSpike;
    private bool animPlaying = false;

    public override void GainAbility()
    {
        spikeCollider = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        currSpike = sr.sprite;
    }

    public override void RemoveAbility()
    {
        Destroy(this.gameObject);
    }

    public override void UseAbility()
    {
        if (!animPlaying)
            StartCoroutine(GenerateSpike());
    }

    private IEnumerator GenerateSpike()
    {
        animPlaying = true;
        sr.sprite = extendedSpike;
        spikeCollider.enabled = true;
        yield return new WaitForSeconds(2);
        spikeCollider.enabled = false;
        sr.sprite = currSpike;
        animPlaying = false;
    }
}
