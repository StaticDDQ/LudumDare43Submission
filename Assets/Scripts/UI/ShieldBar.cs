using UnityEngine;

public class ShieldBar : MonoBehaviour {

    public static ShieldBar instance;
    [SerializeField] private ShieldAttachment sa;
    [SerializeField] private float shieldAmount = 0;
    [SerializeField] private float UISpeed = 2;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.4f, shieldAmount / 100f, 1), Time.deltaTime * UISpeed);
    }

    // Update is called once per frame
    public void GainAmount (float amount) {
        if(this.shieldAmount <= 0)
        {
            sa.ShowShield(true);
        }
        this.shieldAmount = Mathf.Min(shieldAmount + amount, 100);
    }

    public void LoseAmount(float amount)
    {
        this.shieldAmount = Mathf.Max(0, shieldAmount - amount);
        if(this.shieldAmount > 0)
            sa.TookDamage(this.shieldAmount);
    }

    public float GetShieldAmount()
    {
        return this.shieldAmount;
    }
}
