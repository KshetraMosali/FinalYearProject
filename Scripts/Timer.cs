using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 120f; // Total time for the countdown (in seconds)
    private float currentTime; // Current time left
    public Text timerText; // Reference to the UI text element to display the timer

    private bool isTimerRunning = false; // Flag to indicate if the timer is running

    public GameObject gameOverPopup;
    public GameObject gameWonPopup;
    public GameObject timerPanel;

    public BoundaryTrigger[] boundaryTriggers;

    public GameObject keypadCanvas;

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;

            // Update UI text to display remaining time
            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Check if time has run out
            if (currentTime <= 0f)
            {
                // Stop the timer and display a message indicating that the player has lost
                StopTimer();
                ActivateGameOverPanel();
            }
        }
    }

    public bool IsTimerRunning()
    {
        return isTimerRunning;
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = totalTime;
        timerText.text = string.Format("{0:00}:{1:00}", totalTime / 60, totalTime % 60);
    }

    public void ActivateGameOverPanel()
    {
        gameOverPopup.SetActive(true);
        
        Destroy(timerPanel);
        Destroy(keypadCanvas);

        foreach (BoundaryTrigger trigger in boundaryTriggers)
        {
            trigger.gameObject.SetActive(false);
        }
        
    }

    public void ActivateGameWonPanel()
    {
        gameWonPopup.SetActive(true);
        Destroy(timerPanel);

        foreach (BoundaryTrigger trigger in boundaryTriggers)
        {
            trigger.gameObject.SetActive(false);
        }
    }

}
