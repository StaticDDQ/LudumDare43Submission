using UnityEngine;

public class HealthGain : MonoBehaviour {

    [SerializeField] private EnemyDifficulty difficulty;
    [SerializeField] private float gainAmount = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HealthBar.instance.RestoreHealth(gainAmount * difficulty.HealthGainReducedMultiplier);
            AudioManager.instance.PlaySound("gainHealth");
            RandomDrops.instance.ItemTaken();
            Destroy(this.gameObject);
        }
    }
}
