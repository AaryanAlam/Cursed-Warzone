using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject attachmentMenu;
    public GameObject p;
    public Image backImg;

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
            StartGame();
            mainMenu.SetActive(false);
            p.GetComponent<playerMovement>().lookSensitivity = 2;
        }

        if (Input.GetKeyDown(KeyCode.Minus)) 
        {
            attachmentMenu.active = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        if (!mainMenu.active && Input.GetKeyDown(KeyCode.Alpha0))
        {
            p.GetComponent<playerMovement>().lookSensitivity = 0;
            Options();
        }

        if (mainMenu.active)
        {
            Time.timeScale = 0.0000001f;
            p.GetComponent<playerMovement>().lookSensitivity = 0;
        }
        else
        {
            Time.timeScale = 1;
            if (!p.GetComponent<playerMovement>().isGogglesActive)
            {
                p.GetComponent<playerMovement>().lookSensitivity = 2f;
            }
        }
    }

    public void StartGame()
    {
        
        
    }

    public void Options()
    {

    }

    public void Credits()
    {

    }

    public void Back()
    {
        
    }
}