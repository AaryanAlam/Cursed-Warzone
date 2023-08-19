using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public float gravity = -9.81f;
    public float top;
    public bool inLook = false;
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

        if (Input.GetKey(KeyCode.E))
        {
            top = 1;
        } else
        {
            top = 0;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            top = -1;
        }
        else
        {
            top = 0;
        }
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        if (Input.GetKey(KeyCode.E))
        {
            inLook = true;
            Debug.Log(inLook);
            pos += transform.right * 1f;
            mainCam.transform.rotation = Quaternion.Euler(mainCam.transform.rotation.x, mainCam.transform.rotation.y, mainCam.transform.rotation.z + -45f);
        } else { inLook = false; }
        if (Input.GetKey(KeyCode.Q))
        {
            inLook = true;
            Debug.Log(inLook);
            pos -= transform.right * 1f;
            mainCam.transform.rotation = Quaternion.Euler(mainCam.transform.rotation.x, mainCam.transform.rotation.y, mainCam.transform.rotation.z + 45f);
        } else { inLook = false; }
        mainCam.transform.position = pos;
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;

        velocity.y += gravity * Time.deltaTime;

        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        controller.Move(movement + velocity * Time.deltaTime);

        if (!inLook)
        {
            float rotationX = Input.GetAxis("Mouse X") * playerCamera.GetComponent<lookScript>().sensitivityY;
            transform.Rotate(Vector3.up * rotationX);

            Debug.Log("Searching 88");
        }

    }
}
