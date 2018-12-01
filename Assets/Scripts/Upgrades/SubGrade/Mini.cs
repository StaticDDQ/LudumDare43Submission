using UnityEngine;
using System.Collections;

public class Mini : SubGrade {

    private Transform player;
    private Vector3 miniSize;
    private Vector3 regSize;
    private bool isUsing = false;

    public override void GainAbility()
    {
        player = transform.parent;
        miniSize = new Vector3(player.localScale.x * 0.3f, player.localScale.y * 0.3f, player.localScale.z * 0.3f);
        regSize = player.localScale;
    }

    public override bool RemoveAbility()
    {
        if (isUsing)
            return false;

        Destroy(this, 0.1f);
        return true;
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
        while(elapsedTime < dur)
        {
            player.localScale = Vector3.Lerp(player.localScale, miniSize, elapsedTime/dur);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1);

        elapsedTime = 0.0f;
        while (elapsedTime < dur)
        {
            player.localScale = Vector3.Lerp(player.localScale, regSize, elapsedTime / dur);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1);

        isUsing = false;
    }
}
