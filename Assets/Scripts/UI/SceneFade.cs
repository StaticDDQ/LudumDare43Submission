using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFade: MonoBehaviour {

    public static SceneFade instance;

	[SerializeField] private Texture2D fadeOutText;
    [SerializeField] private float fadeSpeed = 0.35f;

	private float alpha = 1f;
	private int fadeDir = -1;

    // There is only one instance of this and will appear in every scene
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // it will fade in first and wait till the level is ready to be loaded, afterwards it will fade out
    public IEnumerator LoadLevel(int index)
    {
        SetFadeDir(1);
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(index);

        SetFadeDir(-1);
    }

    // assign alpha to either render or unrender the black texture
    private void OnGUI()
	{
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        // Restrict values from 0 to 1 only
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutText);
	}

    public void SetFadeDir(int dir)
    {
        this.fadeDir = dir;
    }
}
