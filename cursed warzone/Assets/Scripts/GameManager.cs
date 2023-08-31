using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject p;
    public Image backImg;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        p.GetComponent<playerMovement>().lookSensitivity = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        if (Input.GetKeyDown(KeyCode.Space) && mainMenu.active)
        {
            mainMenu.SetActive(false);
            p.GetComponent<playerMovement>().lookSensitivity = 2;
        }

        if (!mainMenu.active && Input.GetKeyDown(KeyCode.Alpha0))
        {
            mainMenu.SetActive(true);
            p.GetComponent<playerMovement>().lookSensitivity = 0;
        }

        if (mainMenu.active)
        {
            Time.timeScale = 0.0000001f;
            p.GetComponent<playerMovement>().lookSensitivity = 0;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            p.GetComponent<playerMovement>().lookSensitivity = 2;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        p.GetComponent<playerMovement>().lookSensitivity = 2;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        
    }

    public void Options()
    {

    }

    public void Credits()
    {

    }

    public void Back()
    {
        mainMenu.SetActive(true);
        p.GetComponent<playerMovement>().lookSensitivity = 0;
    }
}