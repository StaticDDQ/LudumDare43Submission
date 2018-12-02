using UnityEngine;

public class SpawnButton : MonoBehaviour {

    [SerializeField] private Sprite buttonOn;
    private Sprite buttonOff;
    private SpriteRenderer sr;
    private bool startSpawning = false;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        buttonOff = sr.sprite;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!startSpawning && collision.gameObject.tag == "Player")
        {
            startSpawning = true;
            sr.sprite = buttonOn;
            WaveSpawner.instance.startSpawning = true;
        }
    }

    public void RevertButton()
    {
        startSpawning = false;
        sr.sprite = buttonOff;
    }
}
