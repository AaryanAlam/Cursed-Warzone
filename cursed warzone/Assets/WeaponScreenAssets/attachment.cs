using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AttachmentSO", menuName = "Attachment")]
public class attachment : ScriptableObject
{
    public Sprite img;
    public string name;
    public string type;
}
