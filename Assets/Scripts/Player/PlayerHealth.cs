using UnityEngine;
using UnityEngine.SceneManagement; // For reloading or transitioning scenes
using UnityEngine.UI; // For the Slider UI

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum player health
    public int currentHealth;   // Current health

    public GameObject gameOverUI; // Assign your Game Over UI panel in the inspector
    public Slider healthSlider;   // Reference to the health slider UI

    private void Start()
    {
        currentHealth = maxHealth; // Initialize player health
        Time.timeScale = 1f;       // Ensure the game is running normally

        // Set the initial value of the health slider
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage! Health: " + currentHealth);

        // Update the health slider with the current health
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died! Game Over.");
        GameOver();
    }

    private void GameOver()
    {
        Debug.Log("Game Over - Showing UI.");
        gameOverUI.SetActive(true); // Show the Game Over UI
        Time.timeScale = 0f;        // Pause the game

        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None; 
    }

    // Methods for the Game Over buttons
    public void RestartGame()
    {
        Debug.Log("Restarting the Game.");
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the Game.");
        Application.Quit(); // Quit the application
    }
}
