using UnityEngine;

public class HealthGain : MonoBehaviour {

    [SerializeField] private float gainAmount = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HealthBar.instance.RestoreHealth(gainAmount);
        }

        Destroy(this.gameObject);
    }
}
