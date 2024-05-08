using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryTrigger : MonoBehaviour
{
    public Animator doorAnimator; 

    public BoundaryTrigger[] boundaryTriggers;

    public Timer timer;
    public GameObject timerPanel;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CameraCollider"))
        {
            // Update the animator parameter
            doorAnimator.SetBool("isDoorOpen", true);

            // Player has entered the room, start the timer         
            timerPanel.SetActive(true);
            timer.StartTimer();

            // Player has entered the room, activate the boundary triggers
            foreach (BoundaryTrigger trigger in boundaryTriggers)
            {
                trigger.ActivateBoundary();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (Application.isPlaying)
        {
            Destroy(gameObject);
        }
    }

}
