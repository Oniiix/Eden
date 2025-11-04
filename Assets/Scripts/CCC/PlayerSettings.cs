using UnityEngine;

[CreateAssetMenu(fileName ="Player Settings")]
public class PlayerSettings : ScriptableObject
{
    [SerializeField,Range(1,100)] float speed = 50;
    [SerializeField,Range(1,100)] float rotateSpeed = 50;
    [SerializeField, Range(1, 25)] float zoomSpeed = 1;
    [SerializeField] float minRange = 20;
    [SerializeField] float maxRange = 200;

    public float Speed { get => speed; set { speed = value; } }
    public float RotateSpeed {get=>rotateSpeed; set { rotateSpeed = value; } }
    public float MinRange {get=>minRange; set { minRange = value; } }
    public float MaxRange {get=>maxRange; set { maxRange = value; } }
    public float ZoomSpeed { get=>zoomSpeed; set { zoomSpeed = value; } }
}
