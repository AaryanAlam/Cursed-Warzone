using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attachmentDisplay : MonoBehaviour
{
    [SerializeField] private Image scope;
    [SerializeField] private Image extra1;
    [SerializeField] private Image extra2;

    public void displayGun(attachment at)
    {
        if (at.type == "scope")
        {
            Debug.Log("scope");
            scope.sprite = at.img;
            scope.name = at.name;
        }
        if (at.type == "extra1")
        {
            extra1.sprite = at.img;
            extra1.name = at.name;
        }
        if (at.type == "extra2")
        {
            extra2.sprite = at.img;
            extra2.name = at.name;
        }
    }
}
