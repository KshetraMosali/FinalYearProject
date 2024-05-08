using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Key : MonoBehaviour
{
    public Timer timer;

    public Animator doorAnimator;

    private void Start()
    {
        // Set the initial state of the key object
        gameObject.SetActive(false);
    }

    void Update()
    {
        HandleKeyTouch();
    }

    public void HandleKeyTouch()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check if the touch phase is began
            if (touch.phase == TouchPhase.Began)
            {
                // Create a ray from the touch position
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Check if the ray hits the key object
                if (Physics.Raycast(ray, out hit) && hit.transform == transform)
                {
                    // Check if the timer is still running
                    if (timer != null && timer.IsTimerRunning())
                    {                        
                        Destroy(gameObject);

                        // Stop the timer and activate the game won panel
                        timer.StopTimer();
                        timer.ActivateGameWonPanel();

                        doorAnimator.SetBool("isDoorOpen", false);
                    }
                }
            }
        }
    }

    public void ActivateKey()
    {
        // Activate the key object
        gameObject.SetActive(true); 
    }

}
