using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public Vector3 pos;
    public Vector3 scopePos;
    public GameObject shotPS;
    public GameObject tip;
    public GameObject supTip;
    public GameObject spherePrefab;
    public GameObject objectToIgnore1;
    public GameObject objectToIgnore2;
    public bool isSup;
    // Start is called before the first frame update
    void Start()
    {
        //normal pos = Vector3(0.236000001,0.25999999,0.481000006)
        pos = new Vector3(0.236000001f, 0.25999999f, 0.481000006f);

        scopePos = new Vector3(0f, 0.380000014f, 0.389999986f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.localPosition = scopePos;
            transform.localRotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z + 5);
        }
        else
        {
            transform.localPosition = pos;
            transform.localRotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z - 5);
        }

        if (Input.GetMouseButton(0))
        {
            if (!isSup)
            {
                Instantiate(shotPS, tip.transform.position, Quaternion.identity);
            }
            else if (isSup)
            {
                Instantiate(shotPS, supTip.transform.position, Quaternion.identity);
            }

            //Laser
            Ray ray = new Ray(transform.position, -transform.forward);
            RaycastHit hit;


            if (objectToIgnore1 != null && objectToIgnore2 != null)
            {
                Debug.Log("hi");
                int layerMask = 1 << objectToIgnore1.layer | 1 << objectToIgnore2.layer;

                if (Physics.Raycast(ray, out hit, 100f, ~layerMask))
                {
                    Debug.Log("hi2");
                    GameObject sphere = Instantiate(spherePrefab, hit.point, Quaternion.identity);
                    Debug.Log("hi");
                }
            }
        }


    }
}
