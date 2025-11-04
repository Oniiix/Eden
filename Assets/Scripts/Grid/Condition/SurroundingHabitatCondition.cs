using System.Collections.Generic;
using UnityEngine;

public class SurroundingHabitatCondition : Condition
{
    [SerializeField] List<EHabitatType> habitatTypes;
    [SerializeField, Range(1, 9)] int HabitatMin = 1;


    public override bool IsConditionValid(Habitat _habitat)
    {
        return false;
    }
}
