using UnityEngine;
using UnityEngine.UI;

public class BoundaryTrigger : MonoBehaviour
{
    public GameObject boundaryCrossPopup;
    public bool isActive = false;

    public void ActivateBoundary()
    {
        isActive = true;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (isActive && other.CompareTag("CameraCollider"))
        {
            boundaryCrossPopup.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (isActive && other.CompareTag("CameraCollider"))
        {
            boundaryCrossPopup.SetActive(false);
        }
    }
}