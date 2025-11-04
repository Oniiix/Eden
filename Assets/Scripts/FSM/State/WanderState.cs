using UnityEngine;

[CreateAssetMenu (fileName = "WanderState",menuName ="FSM/State/Create WanderState")]
public class WanderState : MoveToState
{
    // Il faut faire un manager de faune qui pourra renseigner la grid a tout les mobs.
    // MyGrid navGrid = null;

    public override void InitState(FSMFauna _owner)
    {
        base.InitState(_owner);
        float _x = Random.Range(-15, 15);
        float _y =  Random.Range(-15, 15);
        Vector3 _destination = fsm.FaunaOwner.transform.position + new Vector3(_x, 0,_y);
        movingComponent.SetDestination(_destination);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

}
