using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachmentChanger : MonoBehaviour
{
    [SerializeField] public ScriptableObject[] scopes;
    [SerializeField] public ScriptableObject[] extra1;
    [SerializeField] public ScriptableObject[] extra2;
    [SerializeField] private attachmentDisplay AD;
    public GameObject mainMenu;
    int currentIndex;
    int currentIndex1;
    int currentIndex2;
    bool i = true;
    private void Awake()
    {
        ChangeScope(0);
        ChangeExtra1(0);
        ChangeExtra2(0);
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
    private void Update()
    {
        if (i)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

    }

}
