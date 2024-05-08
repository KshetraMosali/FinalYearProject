using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SafeManager : MonoBehaviour
{
    public Text displayText;
    private string enteredCode = "";
    private string correctCode = "3125";

    public GameObject keypadCanvas;

    public AudioClip buttonClickAudio;
    public AudioClip errorBeepAudio;
    public AudioClip accessGrantedAudio;

    public Animator safeAnimator;

    public Key key;

    public void OnButtonClick(string digit)
    {
        if (enteredCode.Length < 4)
        {
            enteredCode += digit;
            AudioSource.PlayClipAtPoint(buttonClickAudio, transform.position);
            UpdateDisplay();

            if (enteredCode.Length == 4)
            {
                CheckCode(); // Check the code when all 4 digits are entered
            }
        }
    }

    private void UpdateDisplay()
    {
        displayText.text = enteredCode;
    }

    public void CheckCode()
    {
        if (enteredCode == correctCode)
        {
            displayText.color = Color.green;
            AudioSource.PlayClipAtPoint(accessGrantedAudio, transform.position);
            Destroy(keypadCanvas, 1.5f);
            PlaySafeUnlockAnimation();
            key.ActivateKey(); 
        }
        else
        {
            StartCoroutine(ShowIncorrectCode());
        }
    }

    private void PlaySafeUnlockAnimation()
    {
        safeAnimator.SetTrigger("open");
    }

    private IEnumerator ShowIncorrectCode()
    {
        displayText.color = Color.red;
        AudioSource.PlayClipAtPoint(errorBeepAudio, transform.position);
        yield return new WaitForSeconds(0.7f);
        ClearDisplay();
    }

    public void ClearDisplay()
    {
        enteredCode = "";
        displayText.text = "";
        displayText.color = Color.white;      
    }
}