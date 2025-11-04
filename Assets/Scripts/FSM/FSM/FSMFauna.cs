using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="FSMFauna",menuName ="FSM/Create FSMFauna")]
public class FSMFauna : ScriptableObject
{
    [field: SerializeField] public float testLife = 0;
    [field: SerializeField] public FSMComponent Owner { get; private set; }
    [field: SerializeField] public State StartingState { get; private set; } = null;
    [field: SerializeField] public State CurrentState { get; private set; } = null;
    [SerializeField] public Fauna FaunaOwner => Owner.GetComponent<Fauna>();


    public void InitFSM(FSMComponent _owner)
    {
        Owner = _owner;
        //Debug.Log("Enter : " + name);
        if (!StartingState)
            new NullReferenceException("No StartingState : " + name);
        SetNextState(StartingState);
    }

    public void UpdateFSM()
    {
        testLife -= Time.deltaTime;
        //Debug.Log("Update : " + name);
        CurrentState?.UpdateState();
    }

    public void ExitFSM()
    {
        //Debug.Log("Exit : " + name);
        CurrentState?.ExitState();
    }

    public void SetNextState(State _state)
    {
        CurrentState = Instantiate(_state);
        CurrentState.InitState(this);
    }

}
