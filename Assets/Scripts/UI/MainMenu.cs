﻿using UnityEngine;

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
            StartCoroutine(SceneFade.instance.LoadLevel(1));
        }
    }
}