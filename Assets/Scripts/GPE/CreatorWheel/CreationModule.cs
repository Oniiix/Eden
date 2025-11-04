using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CreationModule", menuName="CreationWheel/Create module")]
public class CreationModule : ScriptableObject
{
    [field:SerializeField, Header("System")] public CustomDictionary<string, CreationAction[]> Actions { get; private set; } = null;
    [field: SerializeField, Header("UI")] public Texture2D Icon { get; set; } = null;
}
