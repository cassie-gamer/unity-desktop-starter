using UnityEngine;
using UnityEngine.UI;

// Add this to the same "GameManager" object
// Drag your Timer Text UI into the timerText slot
public class GameTimer : MonoBehaviour
{
    public Text timerText;
    public float timeLeft = 60f;
    private bool running = true;

    void Update()
    {
        if (!running) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            running = false;
            // Freeze player by disabling movement
            var player = GameObject.FindObjectOfType<PlayerMover>();
            if (player != null) player.enabled = false;
        }

        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);
    }
}
