using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the character moves left/right
    public float swipeSensitivity = 0.5f; // Sensitivity of swipe detection
    public float xLimit = 3f; // Horizontal movement limit

    private Vector3 initialPosition; // Initial position of the character
    private bool isDragging = false; // Whether the player is dragging the mouse
    private float dragStartX; // Starting x position of the mouse drag

    void Start()
    {
        initialPosition = transform.position; // Store the initial position
    }

    void Update()
    {
        HandleMouseInput();
        MoveCharacter();
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            dragStartX = Input.mousePosition.x;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            float mouseX = Input.mousePosition.x;
            float deltaX = mouseX - dragStartX;
            float moveAmount = deltaX * swipeSensitivity * Time.deltaTime;

            // Calculate new position based on local coordinates
            Vector3 moveDirection = transform.right * moveAmount;

            // Calculate new position
            Vector3 newPosition = transform.position + moveDirection;

            // Clamp the position to within bounds
            newPosition.x = Mathf.Clamp(newPosition.x, initialPosition.x - xLimit, initialPosition.x + xLimit);

            // Set new position
            transform.position = newPosition;
        }
    }

    void MoveCharacter()
    {
        // Optional: Add smooth movement if needed
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}