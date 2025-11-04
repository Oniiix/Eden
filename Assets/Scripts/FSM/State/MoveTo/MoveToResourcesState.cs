using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

[CreateAssetMenu(fileName = "MoveToResourceState", menuName = "FSM/State/MoveToState/Create MoveToResourceState")]
public class MoveToResourcesState : MoveToState
{
    public override void InitState(FSMFauna _owner)
    {
        base.InitState(_owner);
        movingComponent.SetDestination(GetBestHabitatLocation());
    }

    Vector3 GetBestHabitatLocation()
    {
        FindRessourceComponent _comp = fsm.Owner.transform.GetComponent<FindRessourceComponent>();
        return _comp.GetBestHabitat().transform.position; 
    }

    public override void TransitionCompleted(Transition _transition)
    {
        fsm.FaunaOwner.IsInGoodHabitat = false;
        fsm.FaunaOwner.faunaChara.hunger.CurrentValue += 50;
        fsm.FaunaOwner.faunaChara.thirst.CurrentValue += 50;
        fsm.FaunaOwner.IsHungry = false;
        fsm.FaunaOwner.IsThirsty = false;
        // _transition = _transition as ReachedDestinationTransition;
        //if (_transition)
        //    fsm.FaunaOwner.IsInGoodHabitat = true;
        base.TransitionCompleted(_transition);
    }
}
