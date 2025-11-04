using UnityEngine;

[CreateAssetMenu(fileName = "MoveToEatState", menuName = "FSM/State/MoveToState/Create MoveToEatState")]
public class MoveToEatState : MoveToState
{
    public override void InitState(FSMFauna _owner)
    {
        base.InitState(_owner);
        //
         movingComponent.SetDestination(GetClosestFoodLocation());
    }

    Vector3 GetClosestFoodLocation()
    {
        //  fsm.FaunaOwner.currentFoodTarget = FindClosestFood();
        //  return fsm.FaunaOwner.currentFoodTarget.transform.position;
        return new Vector3();
    }
}
