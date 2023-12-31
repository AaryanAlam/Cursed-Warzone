using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class SOchanger : MonoBehaviour
{
    [SerializeField] public ScriptableObject[] scriptableObjects;
    [SerializeField] private weaponDisplay wD;
    //public GameObject mainMenu;
    public CanvasGroup mm2;
    public CanvasGroup attachmentsM;
    int currentIndex;
    bool i = true;

    private void Awake()
    {
        ChangeScriptableObject(0);
        Time.timeScale = 0.001f;
    }

    public void ChangeScriptableObject(int change)
    {
        currentIndex += change;
        if (currentIndex < 0) currentIndex = scriptableObjects.Length - 1;
        else if (currentIndex > scriptableObjects.Length - 1) currentIndex = 0;
        if (wD != null) wD.displayGun((M4SO)scriptableObjects[currentIndex]);
    }

    public void Play()
    {
        mm2.alpha = 0;
        mm2.blocksRaycasts = false;
        attachmentsM.alpha = 0;
        attachmentsM.blocksRaycasts = false;
        i = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (i)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        
    }
}
