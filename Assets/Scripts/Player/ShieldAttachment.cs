using UnityEngine;

public class ShieldAttachment : MonoBehaviour {

    private SpriteRenderer shieldSprite;
    [SerializeField] private float colorSpeed = 15;
    [SerializeField] private Color shieldColor;
    [SerializeField] private Color damagedColor;
    private Color currColor;
    private bool hasShield = false;

	// Use this for initialization
	void Start () {
        shieldSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        currColor = shieldColor;
	}
	
	// Update is called once per frame
	void Update () {
        if (hasShield)
        {
            shieldSprite.color = Color.Lerp(shieldSprite.color, currColor, Time.deltaTime * colorSpeed);
        }
        else
        {
            shieldSprite.color = Color.Lerp(shieldSprite.color, Color.clear, Time.deltaTime * colorSpeed);
        }
	}

    public void ShowShield(bool shieldReady)
    {
        this.hasShield = shieldReady;
        if (this.hasShield)
            currColor = shieldColor;
    }

    public void TookDamage(float currArmor)
    {
        if(currArmor <= 0)
        {
            hasShield = false;
        }
        else if (currArmor < 20)
        {
            currColor = damagedColor;
        }
        //Play Sound
    }
}
