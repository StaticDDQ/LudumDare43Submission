using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour {

    private Text counterText;

    private void Awake()
    {
        counterText = GetComponent<Text>();
        SetAmount(0);
    }

    public void SetAmount (int amount) {
        if (amount > 0)
            counterText.text = "ENEMIES LEFT: " + amount;
        else
            counterText.text = "ENEMIES LEFT: CLEARED";
	}
}
