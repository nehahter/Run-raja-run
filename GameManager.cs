using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    public Text gameOverText;
    public Button restartButton;

    public float obstacleSpawnInterval = 2f; // Adjust the obstacle spawn interval as needed
    private bool isGameOver = false;

    void Start()
    {
        UpdateScoreText();
        StartCoroutine(SpawnObstacles());
    }

    void Update()
    {
        if (isGameOver && Input.GetButtonDown("Jump"))
        {
            RestartGame();
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (!isGameOver)
        {
            // Logic to spawn obstacles
            // Instantiate new obstacles based on your game requirements

            yield return new WaitForSeconds(obstacleSpawnInterval);
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameOver = true;

        // Display game over text and restart button
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        // Reset game state
        isGameOver = false;
        score = 0;

        // Hide game over text and restart button
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        // Reset player position, obstacles, or any other necessary game elements

        // Restart obstacle spawning
        StartCoroutine(SpawnObstacles());

        // Update the score text
        UpdateScoreText();
    }
}
