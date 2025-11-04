using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : ScriptableObject
{
    [field: SerializeField,HideInInspector] public FSMFauna fsm = null;

    [field: SerializeField] public State NextState = null;
    protected bool IsTransitionValid => isDone;

    protected bool isDone = false; 
    public virtual void InitTransition(FSMFauna _fsm)
    {
        fsm = _fsm;
        //Debug.Log("Enter : " + name);
    }

    public virtual bool CheckTransition()
    {       
        //Debug.Log("CheckTransition : " + name);
        return IsTransitionValid;
    }

    public virtual void ExitTransition()
    {       
        //Debug.Log("Exit : " + name);
    }

}
