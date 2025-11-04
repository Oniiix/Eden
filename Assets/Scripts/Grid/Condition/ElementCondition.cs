using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ElementCondition : Condition
{
    [SerializeField] Element element = null;
    [SerializeField] int minNumber = 0;

    public override bool IsConditionValid(Habitat _habitat)
    {
        int _n = 0;
        int _size = _habitat.Elements.Count;
        for (int i = 0; i < _size; i++)
        {
            if (!_habitat.Elements[i] || _habitat.Elements[i].GetType() != element.GetType())
                continue;
            _n++;
        }
        return _n >= minNumber;
    }
}
