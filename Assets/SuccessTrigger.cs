using UnityEngine;
using TMPro;

public class SuccessTrigger : MonoBehaviour
{
    public WallTimer wallTimer;
    public GameObject successMessage;
    public TextMeshProUGUI successText;
    public AudioSource successSound;

    private void OnTriggerEnter(Collider other)
    {
        Transform current = other.transform;
        while (current != null)
        {
            if (current.CompareTag("Player"))
            {
                Debug.Log("Player entered SuccessTrigger!");

                if (wallTimer != null)
                {
                    wallTimer.StopTimer();
                    Debug.Log("Timer stopped.");
                }

                if (successSound != null)
                {
                    successSound.Play();
                }

                if (successMessage != null)
                {
                    successMessage.SetActive(true);
                    Debug.Log("Success message shown.");
                }

                if (wallTimer != null)
                {
                    float elapsedTime = wallTimer.ElapsedTime;
                    int minutes = Mathf.FloorToInt(elapsedTime / 60);
                    int seconds = Mathf.FloorToInt(elapsedTime % 60);

                    if (successText != null)
                    {
                        successText.text = $"You Escaped!\nTime: {minutes:00}:{seconds:00}";
                        Debug.Log("Success text updated.");
                    }
                }

                return;
            }

            current = current.parent;
        }
    }
}