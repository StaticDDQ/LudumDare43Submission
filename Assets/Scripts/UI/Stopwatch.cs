using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour {

    public static Stopwatch instance;
    private Text displayText;
    private float timeAmount;
    private bool stopTimer = true;

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
        displayText = GetComponent<Text>();
        timeAmount = 0;
    }

    // Update is called once per frame
    private void Update () {
        if (!stopTimer)
        {
            timeAmount += Time.deltaTime;
            string sec = (timeAmount % 60).ToString("00");
            string min = Mathf.Floor((timeAmount % 3600) / 60).ToString("00");
            displayText.text = min + ":" + sec;
        }
    }

    public void StopTimer()
    {
        stopTimer = true;
    }

    public void StartTimer()
    {
        stopTimer = false;
    }
}
