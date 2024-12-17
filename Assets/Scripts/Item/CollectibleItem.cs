using UnityEngine;
using TMPro;  // Make sure you're using TextMeshPro

public class CollectibleItem : MonoBehaviour
{
    public TMP_Text pressFText;  // Reference to the TextMeshProUGUI Text ("Press F to Pickup")
    public AudioSource pickupSound;  // Sound for when the item is picked up

    private bool isPlayerNearby = false;  // Track if the player is near the item

    private void Start()
    {
        // Initially hide the "Press F to pickup" text
        pressFText.gameObject.SetActive(false);
        Debug.Log("Collectible Item Initialized.");
    }

    private void Update()
    {
        // // Only attempt to pick up the item when the player is nearby and presses the "F" key
        // if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        // {
        //     Debug.Log("Player pressed F to pick up item.");
        //     PickupItem();
        // }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger zone
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;  // Player is nearby
            // pressFText.gameObject.SetActive(true);  // Show the "Press F to Pickup" text
            // Debug.Log("Player entered the trigger zone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player left the trigger zone
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;  // Player is no longer nearby
            pressFText.gameObject.SetActive(false);  // Hide the text when the player leaves the trigger
            Debug.Log("Player exited the trigger zone.");
        }
    }

    // Handle the pickup action
    private void PickupItem()
    {
        // Play the pickup sound if it's assigned
        if (pickupSound != null)
        {
            pickupSound.Play();
            Debug.Log("Played pickup sound.");
        }

        // Perform any other actions needed when the item is picked up (e.g., refill battery)

        // Destroy the collectible item after it's picked up
        Destroy(gameObject);

        // Hide the "Press F to Pickup" text after pickup
        pressFText.gameObject.SetActive(false);

        // Debug to confirm the item was picked up
        Debug.Log("Item picked up.");
    }
}
