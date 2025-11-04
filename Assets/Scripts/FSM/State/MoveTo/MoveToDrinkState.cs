using UnityEngine;

[CreateAssetMenu(fileName = " MoveToDrinkState", menuName = "FSM/State/MoveToState/Create MoveToDrinkState")]
public class MoveToDrinkState : MoveToState
{
    public override void InitState(FSMFauna _owner)
    {
        base.InitState(_owner);
        //
        movingComponent.SetDestination(GetClosestWaterLocation());
    }

    Vector3 GetClosestWaterLocation()
    {
        //  fsm.FaunaOwner.currentWaterTarget = FindClosestWater();
        //  return fsm.FaunaOwner.currentWaterTarget.transform.position;
        return new Vector3();
    }
}
