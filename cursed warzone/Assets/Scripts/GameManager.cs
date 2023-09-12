using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    //public GameObject mainMenu;
    //public GameObject attachmentMenu;
    public GameObject p;
    public Image backImg;
    public CanvasGroup mm2;
    public CanvasGroup attachments;


    // Start is called before the first frame update
    void Start()
    {
        mm2.alpha = 1;
        mm2.blocksRaycasts = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && mm2.alpha == 1 && mm2.blocksRaycasts == true)
        {
            StartGame();
            mm2.alpha = 0;
            mm2.blocksRaycasts = false;
            p.GetComponent<playerMovement>().lookSensitivity = 2;
        }

        if (Input.GetKeyDown(KeyCode.Minus)) 
        {
            attachments.alpha = 1;
            attachments.blocksRaycasts = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        if (mm2.alpha == 0 && Input.GetKeyDown(KeyCode.Alpha0))
        {
            p.GetComponent<playerMovement>().lookSensitivity = 0;
            Options();
        }

        if (mm2.alpha == 1 && mm2.blocksRaycasts == true)
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