using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 3f; // Distance for interaction with doors
    private Camera _playerCamera;

    void Start()
    {
        _playerCamera = Camera.main; // Assuming the main camera is used
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Press 'F' to interact
        {
            InteractWithDoor();
        }
    }

    void InteractWithDoor()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            // Check if the object has a DoorController script
            DoorController door = hit.collider.GetComponent<DoorController>();
            if (door != null)
            {
                door.ToggleDoor();
            }
        }
    }
}
