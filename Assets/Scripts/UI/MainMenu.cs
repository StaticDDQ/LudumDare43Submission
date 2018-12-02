using UnityEngine;

public class MainMenu : MonoBehaviour {

    private bool playGame = false;

	// Use this for initialization
	void Awake () {
        //GetComponent<Animator>().Play();
	}
	
	public void PlayGame()
    {
        if (!playGame)
        {
            playGame = true;
            AudioManager.instance.StopSound("mainMenu");
            StartCoroutine(SceneFade.instance.LoadLevel(1));
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
