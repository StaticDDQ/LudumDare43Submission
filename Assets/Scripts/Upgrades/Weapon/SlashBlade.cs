using UnityEngine;

public class SlashBlade : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Animator>().Play("Slashed");
	}
}
