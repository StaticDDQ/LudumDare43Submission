using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public IEnumerator ShakeCamera(float dur = 0.5f, float intensity = 0.4f)
    {
        Vector3 camPos = transform.localPosition;

        float elapsed = 0.0f;
        float timeIntensity;
        float x, y;

        while(elapsed < dur)
        {
            timeIntensity = 1 - elapsed / dur;

            x = Random.Range(-1, 1) * intensity * timeIntensity;
            y = Random.Range(-1, 1) * intensity * timeIntensity;

            transform.localPosition = new Vector3(x, y, camPos.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = camPos;
    }
}
