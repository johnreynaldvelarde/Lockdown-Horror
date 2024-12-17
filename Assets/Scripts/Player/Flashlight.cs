using UnityEngine;
using UnityEngine.UI; // For UI elements like battery display (optional)

public class Flashlight : MonoBehaviour
{
    public Light flashlightLight; // Reference to the flashlight's Light component (WhiteSpotLight)
    public AudioSource flashlightSoundOn; // AudioSource for the flashlight turn-on sound
    public AudioSource flashlightSoundOff; // AudioSource for the flashlight turn-off sound
    public float batteryLife = 100f; // Max battery life in percentage (0 to 100)
    public float batteryDrainRate = 1f; // How fast the battery drains per second when flashlight is on
    private bool isFlashlightOn = false; // Track if the flashlight is on or off

    // Optional: A reference to a UI Text element to display battery percentage
    public Text batteryPercentageText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Detect if the player presses the 'E' key
        {
            ToggleFlashlight();
        }

        // If the flashlight is on, drain the battery over time
        if (isFlashlightOn)
        {
            DrainBattery();
        }

        // Update the battery percentage UI
        if (batteryPercentageText != null)
        {
            batteryPercentageText.text = "Battery: " + Mathf.Ceil(batteryLife) + "%";
        }
    }

    // Toggle the flashlight on or off
    void ToggleFlashlight()
    {
        if (batteryLife > 0f) // Only allow toggling if there's battery life left
        {
            isFlashlightOn = !isFlashlightOn; // Toggle the flashlight's state
            flashlightLight.enabled = isFlashlightOn; // Toggle the Light component's enabled state

            // Play the corresponding sound based on the flashlight's state
            if (isFlashlightOn)
            {
                flashlightSoundOn.Play(); // Play sound when flashlight is turned on
            }
            else
            {
                flashlightSoundOff.Play(); // Play sound when flashlight is turned off
            }
        }
        else if (!isFlashlightOn) // If the flashlight is off and battery is drained, play sound off
        {
            flashlightSoundOff.Play();
        }
    }

    // Drain the battery while the flashlight is on
    void DrainBattery()
    {
        batteryLife -= batteryDrainRate * Time.deltaTime; // Reduce battery life over time
        batteryLife = Mathf.Clamp(batteryLife, 0f, 100f); // Ensure battery doesn't go below 0

        // If the battery is empty, turn off the flashlight
        if (batteryLife <= 0f && isFlashlightOn)
        {
            flashlightLight.enabled = false; // Ensure the light is off
            isFlashlightOn = false; // Ensure the flashlight state is off
            flashlightSoundOff.Play(); // Play turn-off sound
        }
    }

    // Optional: Method to refill the battery (e.g., if the player can recharge it)
  public void RefillBattery(float amount)
  {
    batteryLife += amount;
    batteryLife = Mathf.Clamp(batteryLife, 0f, 100f); // Ensure battery doesn't exceed 100
  }

}
