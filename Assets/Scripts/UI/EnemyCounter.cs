using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour {

    public static EnemyCounter instance;
    [SerializeField] private SpawnButton sb;
    private Text counterText;
    private int totalAmount = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        counterText = GetComponent<Text>();
    }

    public void SetAmount (int amount) {
        totalAmount = Mathf.Max(0, totalAmount + amount);
        counterText.text = "ENEMIES LEFT: " + totalAmount;
        if(totalAmount == 0)
        {
            sb.RevertButton();
        }
	}
}
