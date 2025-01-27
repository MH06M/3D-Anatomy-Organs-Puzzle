using UnityEngine;
using TMPro;  // Use this if using TextMeshProUGUI
// using UnityEngine.UI; // Use this if using Text

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Replace with 'Text' if not using TextMeshPro
    private float timeElapsed;
    public bool isRunning;

    private void Start()
    {
        timeElapsed = 0;
        isRunning = true;
    }

    private void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60F);
        int seconds = Mathf.FloorToInt(timeElapsed % 60F);
        timerText.text = $"{minutes:0}:{seconds:00}";
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        timeElapsed = 0;
        UpdateTimerDisplay();
    }
    
}
