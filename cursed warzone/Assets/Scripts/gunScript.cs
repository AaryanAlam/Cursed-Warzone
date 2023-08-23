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
    public GameObject bullet;
    private GameObject bulletHolder;
    private RaycastHit hit;
    public GameObject impactEff;
    public float bulletSpeed = 1400f;
    private Animator animator;
    private Vector3 originalLocalPosition;
    private Quaternion originalLocalRotation;
    private Ray ray;

    void Start()
    {
        originalLocalPosition = transform.localPosition;
        originalLocalRotation = transform.localRotation;
        bulletHolder = GameObject.FindGameObjectWithTag("BulletHolder");
        animator = GetComponent<Animator>();
        ray = new Ray(tip.transform.position, -tip.transform.forward);


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
            shotAnim();

            if (shootDelay >= 0.1f)
            {
                ShootEffect();
                shootDelay = 0f;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            resetShotAnim();
        }
        Debug.DrawRay(ray.origin, ray.direction);

    }

    void HandleAiming()
    {
        // Calculate the offssset based on your requirements
        Vector3 offset = new Vector3(0f, -0.15f, 0.7f);

        // Set the local position of the gun relative to the player's transform
        transform.localPosition = offset;

        Camera.main.fieldOfView = 26.5f;
    }

    void ShootEffect()
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
    public void Shot()
    {
        Vector3 rayOrigin = tip.transform.position;
        Vector3 rayDirection = -tip.transform.forward;

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, Mathf.Infinity))
        {
           GameObject ImpactEffGO = Instantiate(impactEff, hit.point, Quaternion.LookRotation(Vector3.up, hit.normal)) as GameObject;
            Destroy(ImpactEffGO, 5);
        }

    }


    void shotAnim()
    {
        animator.SetBool("IsShot", true);
    }

    void resetShotAnim()
    {
        animator.SetBool("IsShot", false);

    }


}
