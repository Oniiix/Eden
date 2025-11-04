using UnityEngine;

[CreateAssetMenu(fileName = "AnimalSpawnerCondition", menuName = "AnimalSpawner/Condition")]
public class AnimalSpawnerCondition : ScriptableObject
{
    [field: SerializeField]
    public GameObject ToSpawn { get; private set; } = null;

    [field: SerializeField]
    public HabitatCondition HabitatCondition { get; private set; } = null;
}
