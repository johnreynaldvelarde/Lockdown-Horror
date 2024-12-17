using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    public float rechargeAmount = 20f; // Amount of battery the flashlight will be recharged
    public AudioClip pickupSound; // Sound to play when the battery is collected

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the player collects the battery
        {
            // Find the Flashlight script attached to the player
            Flashlight flashlight = other.GetComponentInChildren<Flashlight>();
            if (flashlight != null)
            {
                flashlight.RefillBattery(rechargeAmount); // Recharge the flashlight
                if (pickupSound != null)
                {
                    AudioSource.PlayClipAtPoint(pickupSound, transform.position); // Play sound
                }

                Destroy(gameObject); // Destroy the battery after collection
            }
        }
    }
}
