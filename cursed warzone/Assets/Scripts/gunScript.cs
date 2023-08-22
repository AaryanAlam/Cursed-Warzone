using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public GameObject shotPS;
    public GameObject tip;
    public GameObject supTip;
    public GameObject player;
    private float shootDelay;
    public bool isSup;
    public bool isMouse2Down;

    private Vector3 originalLocalPosition;
    private Quaternion originalLocalRotation;

    void Start()
    {
        originalLocalPosition = transform.localPosition;
        originalLocalRotation = transform.localRotation;
    }

    void Update()
    {
        shootDelay += Time.deltaTime;

        if (Input.GetMouseButtonDown(1))
        {
            isMouse2Down = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isMouse2Down = false;
        }

        if (isMouse2Down)
        {
            HandleAiming();
        }
        else
        {
            transform.localPosition = originalLocalPosition;
            transform.localRotation = originalLocalRotation;
            Camera.main.fieldOfView = 90f;

        }

        if (Input.GetMouseButton(0))
        {
            if (shootDelay >= 0.1f)
            {
                Shoot();
                shootDelay = 0f;
            }
        }

    }

    void HandleAiming()
    {
        // Calculate the offset based on your requirements
        Vector3 offset = new Vector3(0f, -0.15f, 0.7f);

        // Set the local position of the gun relative to the player's transform
        transform.localPosition = offset;

        Camera.main.fieldOfView = 26.5f;
    }

    void Shoot()
    {
        if (!isSup)
        {
            Instantiate(shotPS, tip.transform.position, Quaternion.identity);
        }
        else if (isSup)
        {
            Instantiate(shotPS, supTip.transform.position, Quaternion.identity);
        }

        
    }

    
}
