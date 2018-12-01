using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

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

        spriteImg = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update () {

        if(percentageHealth < 100)
        {
            spriteImg.color = Color.blue;
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
            GameOver();
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

    private void GameOver()
    {

    }

    public float GetHealthAmount()
    {
        return this.percentageHealth;
    }
}
