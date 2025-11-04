using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class HabitatCondition : Condition
{
    [SerializeField] ElementCondition[] elementConditions = null;
    [SerializeField] GroundCondition[] GroundConditions = null;


    public override bool IsConditionValid(Habitat _habitat)
    {
        foreach (Condition _condition in GroundConditions)
        {
            if (!_condition.IsConditionValid(_habitat))
                return false;
        }
        foreach (Condition _condition in elementConditions)
        {
            if (!_condition.IsConditionValid(_habitat))
                return false;
        }
        return true;
    }
}
