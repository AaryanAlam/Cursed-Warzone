using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attachmentChanger : MonoBehaviour
{
    [SerializeField] public ScriptableObject[] scopes;
    [SerializeField] public ScriptableObject[] extra1;
    [SerializeField] public ScriptableObject[] extra2;
    [SerializeField] public Image gunSprite;
    [SerializeField] public Image img;
    [SerializeField] private attachmentDisplay AD;
    public GameObject mainMenu;
    public GameObject attachmentMenu;
    int currentIndex;
    int currentIndex1;
    int currentIndex2;

    int save1;
    int save2;
    int save3;
    bool i = true;
    private void Awake()
    {
        save1 = PlayerPrefs.GetInt("ScopeIndex");
        save2 = PlayerPrefs.GetInt("Extra1Index");
        save3 = PlayerPrefs.GetInt("Extra2Index");

        ChangeScope(save1);
        ChangeExtra1(save2);
        ChangeExtra2(save3);
    }

    public void ChangeScope(int change)
    {
        currentIndex += change;
        if (currentIndex < 0) currentIndex = scopes.Length - 1;
        else if (currentIndex > scopes.Length - 1) currentIndex = 0;
        if (AD != null) AD.displayGun((attachment)scopes[currentIndex]);
    }

    public void ChangeExtra1(int change)
    {
        currentIndex1 += change;
        if (currentIndex1 < 0) currentIndex1 = extra1.Length - 1;
        else if (currentIndex1 > extra1.Length - 1) currentIndex1 = 0;
        if (AD != null) AD.displayGun((attachment)extra1[currentIndex1]);
    }

    public void ChangeExtra2(int change)
    {
        currentIndex2 += change;
        if (currentIndex2 < 0) currentIndex2 = extra2.Length - 1;
        else if (currentIndex2 > extra2.Length - 1) currentIndex2 = 0;
        if (AD != null) AD.displayGun((attachment)extra2[currentIndex2]);
    }

    public void Modify()
    {
        img.sprite = gunSprite.sprite;
        mainMenu.active = false;
        attachmentMenu.active = true;
    }

    public void Back()
    {
        PlayerPrefs.SetInt("ScopeIndex", currentIndex);
        PlayerPrefs.SetInt("Extra1Index", currentIndex1);
        PlayerPrefs.SetInt("Extra2Index", currentIndex2);
        mainMenu.active = true;
        attachmentMenu.active = false;
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
