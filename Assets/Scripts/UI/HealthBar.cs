﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject particles;
    [SerializeField] private GameObject player;
    [SerializeField] private float percentageHealth = 100f;
    [SerializeField] private float recoverSpeed = 0.1f;
    [SerializeField] private float UISpeed = 5;
    public static HealthBar instance;

    private Image spriteImg;
    private bool fullHealth = true;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        AudioManager.instance.PlaySound("theme");
        spriteImg = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update () {

        if(percentageHealth < 100)
        {
            spriteImg.color = Color.cyan;
            fullHealth = false;
        } else
        {
            spriteImg.color = Color.white;
            fullHealth = true;
        }

		if(!fullHealth)
        {
            percentageHealth = Mathf.Lerp(percentageHealth, 101, recoverSpeed * Time.deltaTime);

            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(percentageHealth / 100f, percentageHealth / 100f, 1), Time.deltaTime * UISpeed);
        }
	}

    public void ReduceHealth(float amount, bool fromPlayer)
    {
        float totalDmg = amount;

        if(!fromPlayer && ShieldBar.instance.GetShieldAmount() > 0)
        {
            totalDmg = Mathf.Max(0, amount - ShieldBar.instance.GetShieldAmount());
            ShieldBar.instance.LoseAmount(amount);
        }

        percentageHealth = percentageHealth - totalDmg;

        if(percentageHealth <= 0.0f && fromPlayer)
        {
            percentageHealth = 1f;
            return;
        }

        if(percentageHealth <= 0.0f)
        {
            AudioManager.instance.PlaySound("playerDestroyed");
            StartCoroutine(GameOver());
        }
        else if(!fromPlayer)
        {
            AudioManager.instance.PlaySound("gettingHit");
        }
    }

    public void RestoreHealth(float amount)
    {
        percentageHealth += amount;
        if(percentageHealth > 100)
        {
            percentageHealth = 100.15f;
        }
    }

    private IEnumerator GameOver()
    {
        player.GetComponent<Animator>().Play("explodeAnimPlayer");
        Instantiate(particles, player.transform.position, Quaternion.identity);
        GameOverScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        Destroy(player);
        Time.timeScale = 0f;
    }

    public float GetHealthAmount()
    {
        return this.percentageHealth;
    }
}
