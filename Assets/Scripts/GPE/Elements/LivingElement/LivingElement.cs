using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;

public class LivingElement : Element
{
    [field: SerializeField, HideInInspector] public bool IsThirsty { get; set; } = false;
    public bool GetThirst()
    {
        LivingElementCharacteristic _livingElement = (LivingElementCharacteristic)CharacteristicComponent.Characteristic;
        bool _thirst = _livingElement.thirst.CurrentValue <= _livingElement.ThirstLimit;
        if (_thirst)
            IsThirsty = true;
        return IsThirsty;
    }

    public bool GetGreatThirst()
    {
        LivingElementCharacteristic _livingElement = (LivingElementCharacteristic)CharacteristicComponent.Characteristic;
        return _livingElement.thirst.CurrentValue <= _livingElement.ThirstLimit/2;
    }
}

