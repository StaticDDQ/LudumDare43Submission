using UnityEngine;

public class Shield : MonoBehaviour {

    [SerializeField] private float shieldGain = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ShieldBar.instance.GainAmount(shieldGain);
            Destroy(this.gameObject);
        }
    }
}
