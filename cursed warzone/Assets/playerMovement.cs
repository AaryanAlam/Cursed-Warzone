using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public float gravity = -9.81f;
    public Transform playerCamera;
    private CharacterController controller;
    private Vector3 velocity;
    public Camera mainCam;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        HandleMovement();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 12.5f;
        }
        else
        {
            moveSpeed = 5f;
        }
    }

    private void HandleMovement()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        mainCam.transform.position = pos;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;

        velocity.y += gravity * Time.deltaTime;

        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        controller.Move(movement + velocity * Time.deltaTime);

        float rotationX = Input.GetAxis("Mouse X") * playerCamera.GetComponent<lookScript>().sensitivityY;
        transform.Rotate(Vector3.up * rotationX);
    }
}
