using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    public GameObject spherePrefab;
    public GameObject objectToIgnore1;
    public GameObject objectToIgnore2;

    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;

        if (objectToIgnore1 != null && objectToIgnore2 != null)
        {
            int layerMask = 1 << objectToIgnore1.layer | 1 << objectToIgnore2.layer;

            if (Physics.Raycast(ray, out hit, distance, ~layerMask))
            {
                GameObject sphere = Instantiate(spherePrefab, hit.point, Quaternion.identity);
                StartCoroutine(PauseCoroutine(sphere));
            }
            else
            {
            }
        }
        else
        {
            Debug.LogError("Object to Ignore null");
        }

        Debug.DrawRay(ray.origin, ray.direction, Color.red);
    }

    IEnumerator PauseCoroutine(GameObject sphere)
    {
        yield return new WaitForSeconds(0.001f);

        Destroy(sphere);
    }
}
