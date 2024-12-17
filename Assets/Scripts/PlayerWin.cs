using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    public GameObject winUI; // The "You Win" UI panel to be activated

    private void OnTriggerEnter(Collider other)
    {
        // Log the collider's tag for debugging purposes
        Debug.Log("Collider entered: " + other.tag);

        // Check if the player collided with the "WinFloor" (make sure the floor has this tag)
        if (other.CompareTag("WinFloor"))
        {
            Debug.Log("Player has collided with the Win Floor!");
            WinGame();
        }
    }

    private void WinGame()
    {
        Debug.Log("Player has won! You Win.");

        // Activate the "You Win" UI
        winUI.SetActive(true);

        // Pause the game (optional)
        Time.timeScale = 0f;

        // Show the cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
