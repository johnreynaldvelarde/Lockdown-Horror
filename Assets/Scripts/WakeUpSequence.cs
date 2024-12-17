using UnityEngine;

public class WakeUpSequence : MonoBehaviour
{
    public Camera wakingUpCamera;  // Reference to the waking-up camera
    public Camera playerCamera;    // Reference to the player's camera
    public float wakeUpDuration = 3f;  // Duration of the wake-up animation
    private float elapsedTime = 0f;

    public Vector3 wakeUpPositionOffset = new Vector3(0, 0.5f, 0); // Move up
    public Vector3 wakeUpRotationOffset = new Vector3(-10, 0, 0); // Initial rotation

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        // Initialize waking-up camera state
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        // Ensure waking-up camera is active, player camera inactive
        wakingUpCamera.enabled = true;
        playerCamera.enabled = false;

        // Tilt the waking-up camera
        transform.rotation = initialRotation * Quaternion.Euler(wakeUpRotationOffset);
    }

    void Update()
    {
        if (elapsedTime < wakeUpDuration)
        {
            // Animate the camera smoothly
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / wakeUpDuration;

            Vector3 targetPosition = initialPosition + wakeUpPositionOffset;
            Quaternion targetRotation = Quaternion.Euler(0, 0, 0);

            transform.position = Vector3.Lerp(initialPosition, targetPosition, progress);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, progress);
        }
        else
        {
            // Transition to player camera after the animation
            wakingUpCamera.enabled = false;
            playerCamera.enabled = true;

            // Destroy this script or GameObject to clean up
            Destroy(this);
        }
    }
}
