using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : Singleton<AnimalSpawner>
{
    [SerializeField]
    MyGrid grid = null;

    [SerializeField]
    List<AnimalSpawnerCondition> conditions = new();

    [SerializeField]
    int checkConditionsRepeatTime = 5;

    public bool ConditionsIsEmpty => conditions.Count == 0;

    private void Start()
    {
        InvokeRepeating(nameof(CheckConditions), 0, checkConditionsRepeatTime);
    }

    void CheckConditions()
    {
        if (!grid || ConditionsIsEmpty)
            return;

        int _size = conditions.Count;
        List<Habitat> _habitats = grid.Habitats;
        int _habitatsSize = _habitats.Count;
        
        for (int h = 0; h < _habitatsSize; h++)
        {
            for (int c = 0; c < _size; c++)
            {
                if (!_habitats[h]) Debug.Log(h);
                if (conditions[c].HabitatCondition.IsConditionValid(_habitats[h]))
                    Instantiate(conditions[c].ToSpawn.gameObject, _habitats[h].transform.position, Quaternion.identity);
            }
        }
    }
}
