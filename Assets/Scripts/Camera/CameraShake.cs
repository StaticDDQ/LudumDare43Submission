using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour {


    public void DoShake()
    {
        StartCoroutine(ShakeCamera());
    }

    private IEnumerator ShakeCamera(float dur = 1f, float intensity = 1f)
    {
        Vector3 camPos = transform.localPosition;

        float elapsed = 0.0f;
        float timeIntensity;

        while(elapsed < dur)
        {
            timeIntensity = 1 - elapsed / dur;

            float x = Random.Range(-1, 1) * intensity * timeIntensity;
            float y = Random.Range(-1, 1) * intensity * timeIntensity;

            transform.localPosition = new Vector3(x, y, camPos.z);
            elapsed += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        transform.localPosition = camPos;
    }
}
