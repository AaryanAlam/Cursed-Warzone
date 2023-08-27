using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public AudioSource source;
    public AudioClip walking;
    public float speed = 5f;
    public float jumpSpeed = 5f;
    public float gravity = -9.81f;
    public float crouchHeight = 1f;
    public float lookSensitivity = 2f;
    public float superDashCost = 35.0f;
    private float _originalHeight;
    public bool j = true;
    public bool isNightVisionActive;
    public bool isGogglesActive;


    private CharacterController _controller;
    public Transform _camera;
    public GameObject NVGFX;
    public GameObject GogFX;
    public GameObject cam;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _originalHeight = _controller.height;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        NVGFX.SetActive(false);

    }
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNightVision();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ToggleGoggles();
        }


        // Getting x and z axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Making Move Command for Character Controller
        Vector3 move = transform.right * x + transform.forward * z;

        // Assigning to Character Controller
        _controller.Move(move * speed * Time.deltaTime);

        // Jump Command
        if (_controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            _controller.Move(Vector3.up * jumpSpeed * Time.deltaTime);
        }

        // Using Jump in Character Controller
        _controller.Move(Vector3.up * gravity * Time.deltaTime);


        // Crouch
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _controller.height = crouchHeight;
            speed = 2.5f;
        }
        else
        {
            _controller.height = _originalHeight;
            speed = 5;
        }

        // Run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 8f;

        }
        else
        {
            speed = 5;
        }

        // first-person look
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        mouseX = Mathf.Clamp(mouseX, -20f, 70f);
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        transform.Rotate(0f, mouseX, 0f);

        float newXRotation = _camera.localEulerAngles.x - mouseY;
        if (newXRotation > 180f)
        {
            newXRotation -= 360f;
        }

        newXRotation = Mathf.Clamp(newXRotation, -20f, 80f);

        _camera.localEulerAngles = new Vector3(
            newXRotation,
            0f,
            0f
        );
    }

    private void ToggleNightVision()
    {
        isNightVisionActive = !isNightVisionActive;

        if (isNightVisionActive)
        {
            NVGFX.SetActive(true);
        }
        if (!isNightVisionActive)
        {
            NVGFX.SetActive(false);
        }
    }

    private void ToggleGoggles()
    {
        isGogglesActive = !isGogglesActive;

        if (isGogglesActive)
        {
            cam.GetComponent<Camera>().fieldOfView = 10f;
            lookSensitivity = 0.5f;
            GogFX.SetActive(true);
        }
        if (!isGogglesActive)
        {
            cam.GetComponent<Camera>().fieldOfView = 90f;
            lookSensitivity = 2f;
            GogFX.SetActive(false);
        }
    }


}
