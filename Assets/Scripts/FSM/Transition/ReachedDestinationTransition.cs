using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu (fileName ="ReachedDestinationTransition",menuName ="FSM/Transition/Create ReachedDestinationTransition")]
public class ReachedDestinationTransition : Transition
{
    MovingComponent movingComponent = null;

    public override void InitTransition(FSMFauna _fsm)
    {
        base.InitTransition(_fsm);
        movingComponent = _fsm.Owner.GetComponent<MovingComponent>();
    }

    public override bool CheckTransition()
    {
        if(movingComponent.ArrivedToDestination)
            isDone = true;
        return base.CheckTransition();
    }
}
