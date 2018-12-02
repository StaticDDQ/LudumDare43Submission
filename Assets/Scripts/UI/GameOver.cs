using UnityEngine;

public class GameOver : MonoBehaviour {

    public void ExitGame()
    {
        Time.timeScale = 1.0f;
        AudioManager.instance.StopSound("theme");
        StartCoroutine(SceneFade.instance.LoadLevel(0));
    }
}
