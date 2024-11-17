using UnityEngine;
using TMPro;

public class WallTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0f;
    private bool isRunning = true;
    private AudioSource tickAudio;

    public float ElapsedTime => elapsedTime;

    void Start()
    {
        tickAudio = GetComponent<AudioSource>();

        if (tickAudio != null)
        {
            tickAudio.loop = true;
            tickAudio.playOnAwake = false;
        }
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (tickAudio != null && !tickAudio.isPlaying)
            {
                tickAudio.Play();
            }
        }
    }

    public void StopTimer()
    {
        isRunning = false;

        if (tickAudio != null && tickAudio.isPlaying)
        {
            tickAudio.Stop();
        }
    }
}