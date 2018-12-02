using UnityEngine;

public class Shield : MonoBehaviour {

    [SerializeField] private EnemyDifficulty difficulty;
    [SerializeField] private int shieldGain = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ShieldBar.instance.GainAmount(shieldGain * difficulty.ArmorGainReducedMultiplier);
            AudioManager.instance.PlaySound("gainArmor"); 
            RandomDrops.instance.ItemTaken();
            Destroy(this.gameObject);
        }
    }
}
