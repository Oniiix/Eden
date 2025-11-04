
public abstract class MoveToState : State
{
    protected MovingComponent movingComponent = null;

    public override void InitState(FSMFauna _owner)
    {
        base.InitState(_owner);
        movingComponent = fsm.Owner.GetComponent<MovingComponent>();
        movingComponent.IsMoving = true;
    }

}
