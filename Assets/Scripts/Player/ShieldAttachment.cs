using UnityEngine;

public class ShieldAttachment : MonoBehaviour {

    private SpriteRenderer shieldSprite;
    [SerializeField] private float rotSpeed = 2;
    private bool hasShield = false;

	// Use this for initialization
	void Start () {
        shieldSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (hasShield)
        {
            shieldSprite.color = Color.Lerp(shieldSprite.color, Color.white, Time.deltaTime * 2);
            transform.Rotate(0, 0, Time.deltaTime * rotSpeed);
        }
        else
        {
            shieldSprite.color = Color.Lerp(shieldSprite.color, Color.clear, Time.deltaTime * 2);
        }
	}

    public void SetHasShield(bool isTrue)
    {
        this.hasShield = isTrue;
    }
}
