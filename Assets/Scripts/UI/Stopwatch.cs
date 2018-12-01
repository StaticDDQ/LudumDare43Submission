using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour {

    private Text displayText;
    private float timeAmount;

    private void Awake()
    {
        displayText = GetComponent<Text>();
        timeAmount = 0;
    }

    // Update is called once per frame
    void Update () {
        timeAmount += Time.deltaTime;
        string sec = (timeAmount % 60).ToString("00");
        string min = Mathf.Floor((timeAmount % 3600)/60).ToString("00");
        displayText.text = min + ":" + sec;
    }
}
