using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Condition
{
    public abstract bool IsConditionValid(Habitat _habitat);
}
