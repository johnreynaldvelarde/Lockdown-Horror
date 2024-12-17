// using UnityEngine;

// public class DoorController : MonoBehaviour
// {
//     public bool isOpen = false;  // Tracks if the door is open
//     public float openAngle = 90f; // The angle to rotate when opened
//     public float openSpeed = 2f; // Speed of door rotation

//     public AudioClip openSound;  // Sound for opening the door
//     public AudioClip closeSound; // Sound for closing the door
//     private AudioSource audioSource;

//     private Quaternion _closedRotation;
//     private Quaternion _openRotation;

//     void Start()
//     {
//         // Set initial door rotation
//         _closedRotation = transform.rotation;
//         _openRotation = _closedRotation * Quaternion.Euler(0, 0, openAngle);

//         // Get the AudioSource component
//         audioSource = GetComponent<AudioSource>();
//     }

//     public void ToggleDoor()
//     {
//         // Toggle the door state
//         isOpen = !isOpen;

//         // Log door status
//         Debug.Log(isOpen ? "Door opened." : "Door closed.");

//         // Play the appropriate sound effect
//         if (audioSource != null)
//         {
//             audioSource.clip = isOpen ? openSound : closeSound;
//             audioSource.Play();
//         }
//     }

//     void Update()
//     {
//         // Smoothly rotate the door
//         Quaternion targetRotation = isOpen ? _openRotation : _closedRotation;
//         transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         // Check if the object entering the collider has the "Enemy" tag
//         if (other.CompareTag("Enemy") && !isOpen)
//         {
//             Debug.Log("Enemy entered the trigger area. Opening door...");
//             ToggleDoor(); // Open the door
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         // Close the door when the enemy leaves the trigger
//         if (other.CompareTag("Enemy") && isOpen)
//         {
//             Debug.Log("Enemy exited the trigger area. Closing door...");
//             ToggleDoor(); // Close the door
//         }
//     }
// }

using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;  // Tracks if the door is open
    public float openAngle = 90f; // The angle to rotate when opened
    public float openSpeed = 2f; // Speed of door rotation

    public AudioClip openSound;  // Sound for opening the door
    public AudioClip closeSound; // Sound for closing the door
    private AudioSource audioSource;

    private Quaternion _closedRotation;
    private Quaternion _openRotation;

    private Collider solidCollider; // The solid collider that blocks the enemy

    void Start()
    {
        // Set initial door rotation
        _closedRotation = transform.rotation;
        _openRotation = _closedRotation * Quaternion.Euler(0, 0, openAngle);

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Find the solid collider (non-trigger collider)
        solidCollider = GetComponent<Collider>();
    }

    public void ToggleDoor()
    {
        // Toggle the door state
        isOpen = !isOpen;

        // Log door status
        Debug.Log(isOpen ? "Door opened." : "Door closed.");

        // Enable or disable the solid collider
        if (solidCollider != null)
        {
            solidCollider.enabled = !isOpen; // Disable collider when door is open
        }

        // Play the appropriate sound effect
        if (audioSource != null)
        {
            audioSource.clip = isOpen ? openSound : closeSound;
            audioSource.Play();
        }
    }

    void Update()
    {
        // Smoothly rotate the door
        Quaternion targetRotation = isOpen ? _openRotation : _closedRotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the collider has the "Enemy" tag
        if (other.CompareTag("Enemy") && !isOpen)
        {
            Debug.Log("Enemy entered the trigger area. Opening door...");
            ToggleDoor(); // Open the door
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Close the door when the enemy leaves the trigger
        if (other.CompareTag("Enemy") && isOpen)
        {
            Debug.Log("Enemy exited the trigger area. Closing door...");
            ToggleDoor(); // Close the door
        }
    }
}
