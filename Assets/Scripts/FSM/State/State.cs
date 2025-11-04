using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    [field: SerializeField] public FSMFauna fsm { get; protected set; }  = null;
    [field: SerializeField] public List<Transition> Transitions { get; protected set; } = new List<Transition>(); 
    [field: SerializeField] public List<Transition> RunningTransitions { get; protected set; } = new List<Transition>(); 
    
    public virtual void InitState(FSMFauna _fsm)
    {
        //Debug.Log("Enter : " + name);
        fsm = _fsm;
        for (int i = 0; i < Transitions.Count; i++)
        {
            Transition _transition = Instantiate(Transitions[i]);
            RunningTransitions.Add(_transition);
            _transition.InitTransition(_fsm);
        }
    }

    public virtual void UpdateState()
    {
          //Debug.Log("Update : " + name);
        foreach(Transition _transition in RunningTransitions)
        {
          //Debug.Log("[UpdateState] _transition : " + name);
            if (_transition.CheckTransition())
                TransitionCompleted(_transition);
        }
    }

    public virtual void ExitState()
    {
        //Debug.Log("Exit : " + name);
        foreach(Transition _transition in RunningTransitions)
        {
            _transition?.ExitTransition();
        }
    }

    public virtual void TransitionCompleted(Transition _transition)
    {
        //Debug.Log("Transition Completed : " + _transition.name);
        fsm.SetNextState(_transition.NextState);
        ExitState();
    }


}
