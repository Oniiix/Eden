using UnityEngine;

[CreateAssetMenu(fileName = "GroundColorList")]
public class GroundColorList : ScriptableObject
{
    [field: SerializeField]
    public CustomDictionary<EGround, Color> Colors { get; private set; } = new();
}
