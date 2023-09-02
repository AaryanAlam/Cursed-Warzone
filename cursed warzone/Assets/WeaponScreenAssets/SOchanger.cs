using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOchanger : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] serilizableObjects;
    [SerializeField] private weaponDisplay wD;

    private void Awake()
    {
        wD.displayGun((M4SO)serilizableObjects[0]);
    }
}
