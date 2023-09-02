using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "M4sprite", menuName = "M4")]
public class M4SO : ScriptableObject
{
    public string name;
    public string description;

    public Sprite sprite;
    public Vector3 scopePos;
    public Vector3 extra1Pos;
    public Vector3 extra2Pos;

    public float Damage;
    public float fireRate;
    public float accuracy;
    public string weight;
    public string magazineSize;
}
