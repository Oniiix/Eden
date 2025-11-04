using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacteristicComponent))]
public class Element : MonoBehaviour
{
    [field: SerializeField] public CharacteristicComponent CharacteristicComponent { get; protected set; } = null;
    [field: SerializeField] public DetectionComponent DetectionComponent { get; private set; } = null;
    [field: SerializeField] public Texture2D elementIcon { get; private set; }
    [field: SerializeField] public bool can_spawn_on { get; private set; } = false;


    protected virtual void Init()
    {
        
    }
    void Start()
    {
        Init();
    }
}
















//public enum EAgeState
//{
//    Young,
//    Adult,
//    Old
//}

//public event Action OnDie = null;
//[SerializeField, Range(1, 100)] protected int deathAge = 10;
//[SerializeField] protected int currentAge = 0;
//[field:SerializeField] public EGround[] FavoriteGround { get; private set; } = new();

//public int CurrentAge
//{
//    get => currentAge;
//    set
//    {
//        if (currentAge >= deathAge)
//            Debug.Log(name + " => dead");
//        else currentAge = value;
//    }
//}

//public EAgeState state => currentAge > (deathAge / 3) * 2 ? EAgeState.Old : currentAge > deathAge / 3 ? EAgeState.Adult : EAgeState.Young;