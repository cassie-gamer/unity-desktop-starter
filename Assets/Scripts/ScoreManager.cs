using UnityEngine;
using UnityEngine.UI;

// Add this to an empty GameObject called "GameManager"
// Drag your Score Text UI into the scoreText slot in the Inspector
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public Text scoreText;
    private int score = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddPoint()
    {
        score++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
