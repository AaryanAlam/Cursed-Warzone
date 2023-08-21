using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public GameObject shotPS;
    public GameObject tip;
    public GameObject supTip;
    public GameObject spherePrefab;
    public GameObject objectToIgnore1;
    public GameObject objectToIgnore2;
    public GameObject player;
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
            Shoot();
        }
    }

    void HandleAiming()
    {
        // Calculate the offset based on your requirements
        Vector3 offset = new Vector3(-0.1f, 0.1f, 0.7f);

        // Set the local position of the gun relative to the player's transform
        transform.localPosition = offset;

        Camera.main.fieldOfView = 20f;
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

        Ray ray = new Ray(transform.position, -transform.forward);
        RaycastHit hit;

        if (objectToIgnore1 != null && objectToIgnore2 != null)
        {
            int layerMask = 1 << objectToIgnore1.layer | 1 << objectToIgnore2.layer;

            if (Physics.Raycast(ray, out hit, 100f, ~layerMask))
            {
                GameObject sphere = Instantiate(spherePrefab, hit.point, Quaternion.identity);
            }
        }
    }
}
