using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class GroundCondition : Condition
{
    [SerializeField] EGround ground = EGround.None;
    [SerializeField, Range(0, 100)] float minPercentage = 0;


    public override bool IsConditionValid(Habitat _habitat)
    {
        if (!_habitat.Grounds.ContainsKey(ground)) 
            return false;

        return (_habitat.Grounds[ground] * 100 / _habitat.Nodes.Count) >= minPercentage;
    }
}
