using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && mainMenu.active)
        {
            mainMenu.SetActive(false);
        }

        if (!mainMenu.active && Input.GetKeyDown(KeyCode.Alpha0) || !mainMenu.active && Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.SetActive(true);
        }

        if (mainMenu.active)
        {
            Time.timeScale = 0.0000001f;
        } else
        {
            Time.timeScale = 1;
        }
    }
}
