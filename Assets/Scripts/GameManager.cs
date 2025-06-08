using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public int lives = 3;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        else
            Debug.LogWarning("GameOverPanel is not assigned in the inspector!");
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void LoseLife()
    {
        lives--;

        // اعلام به HealthManager که یکی از قلب‌ها کم بشه
        HealthManager healthManager = FindObjectOfType<HealthManager>();
        if (healthManager != null)
        {
            healthManager.TakeDamage();
        }

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        else
            Debug.LogWarning("gameOverPanel is not assigned!");

        Time.timeScale = 0f; // بازی رو متوقف می‌کنه
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
