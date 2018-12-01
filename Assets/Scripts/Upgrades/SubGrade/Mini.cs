using UnityEngine;
using System.Collections;

public class Mini : SubGrade {

    private Transform player;
    private Vector2 miniSize;
    private Vector2 regSize;
    private bool isUsing;

    public override void GainAbility()
    {
        player = transform.parent;
        miniSize = player.localScale * 0.3f;
        regSize = player.localScale;
        isUsing = false;
    }

    public override void RemoveAbility()
    {
        StopAllCoroutines();
        player.localScale = regSize;

        Destroy(this.gameObject);
    }

    public override void UseAbility()
    {
        if(!isUsing)
            StartCoroutine(ResizePlayer(1f));
    }

    private IEnumerator ResizePlayer(float dur)
    {
        isUsing = true;
        float elapsedTime = 0.0f;
        Vector2 startScale = player.localScale;

        while(elapsedTime < dur)
        {
            player.localScale = Vector2.Lerp(startScale, miniSize, elapsedTime / dur);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1);

        startScale = player.localScale;
        elapsedTime = 0.0f;
        while (elapsedTime < dur)
        {
            player.localScale = Vector3.Lerp(startScale, regSize, elapsedTime / dur);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1);

        isUsing = false;
    }
}
