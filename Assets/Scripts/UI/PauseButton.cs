using UnityEngine;

public class PauseButton : MonoBehaviour {

    private bool isPaused = false;

    // Update is called once per frame
    private void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused && Time.timeScale == 0.0f)
            {
                return;
            }

            PauseScreen();
        }
    }

    private void PauseScreen() {

        isPaused = !isPaused;

        if(isPaused)
            GetComponent<Animator>().Play("PausePopUp");
        else
            GetComponent<Animator>().Play("PausePopOff");

        Time.timeScale = (isPaused) ? 0.0f : 1.0f;
    }

    public void Resume()
    {
        PauseScreen();
    }

    public void Quit()
    {
        Time.timeScale = 1.0f;
        AudioManager.instance.StopSound("theme");
        StartCoroutine(SceneFade.instance.LoadLevel(0));
    }
}
