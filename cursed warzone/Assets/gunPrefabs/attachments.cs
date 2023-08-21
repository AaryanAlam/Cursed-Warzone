using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachments : MonoBehaviour
{
    // On Gun
    public bool isOnLight = false;
    public bool isOnLaser = false;
    public bool isOnScope = false;
    public bool isOnSup = false;

    // Attachment Active
    public bool isActiveLight = false;
    public bool isActiveLaser = false;

    // GameObjects
    public GameObject laser;
    public GameObject light;
    public GameObject sup;
    public GameObject scope;
    public GameObject tip;

    // Extra
    public bool lightOn = false;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        laser.SetActive(false);
        sup.SetActive(false);
        scope.SetActive(false);
        light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(tip.transform.position, transform.forward);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit))
        {
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isOnLight = !isOnLight;
            light.SetActive(!light.active);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isOnLaser = !isOnLaser;
            laser.SetActive(!laser.active);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            isOnScope = !isOnScope;
            scope.SetActive(!scope.active);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            isOnSup = !isOnSup;
            sup.SetActive(!sup.active);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            isActiveLight = !isActiveLight;
            light.SetActive(!light.active);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            isActiveLaser = !isActiveLaser;
            laser.GetComponent<laserScript>().enabled = !laser.GetComponent<laserScript>().enabled;
        }

    }
}
