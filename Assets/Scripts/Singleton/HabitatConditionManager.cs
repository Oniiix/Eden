using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitatConditionManager : Singleton<HabitatConditionManager>
{
    [SerializeField] CustomDictionary<EHabitatType, HabitatCondition> habitatConditions = new();


    bool VerifyHabitat(Habitat _habitat)
    {
        if (_habitat.Type == EHabitatType.None)
            return false;

        if (habitatConditions[_habitat.Type].IsConditionValid(_habitat))
            return true;

        _habitat.Type = EHabitatType.None;
        return false;
    }

    public void UpdateHabitat(Habitat _habitat)
    {
        if (VerifyHabitat(_habitat))
            return;

        for (int i = 0; i < habitatConditions.Count; i++)
        {
            if (!_habitat) Debug.Log("habitat null");
            if (habitatConditions[i].Value.IsConditionValid(_habitat))
            {
                _habitat.Type = habitatConditions[i].Key;
                return;
            }
        }
    }
}
