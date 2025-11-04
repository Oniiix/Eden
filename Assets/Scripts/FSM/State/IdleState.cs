using UnityEngine;

[CreateAssetMenu(fileName ="IdleState" ,menuName ="FSM/State/Create IdleState")]
public class IdleState : State
{
    MovingComponent movingComponent;
    public override void InitState(FSMFauna _fsm)
    {
        base.InitState(_fsm);
        movingComponent = _fsm.Owner.GetComponent<MovingComponent>();
        movingComponent.ArrivedToDestination = false;
        movingComponent.IsMoving = false;
    }
}
