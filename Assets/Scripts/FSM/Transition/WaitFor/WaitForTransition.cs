using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

[CreateAssetMenu(fileName = "WaitForTransition", menuName = "FSM/Transition/WaitFor/Create WaitForTransition")]
public class WaitForTransition : Transition
{
    //Todo remove et checker les caracteristiques 
    
    [field: SerializeField]public  State SearchResourcesState = null;
    [field: SerializeField]public  State SearchFoodState = null;
    [field: SerializeField]public  State SearchWaterState = null;
    [SerializeField] float timerEnd = 0;

    float timer = 0;
    public override void InitTransition(FSMFauna _fsm)
    {
        base.InitTransition(_fsm);
    }
    public override bool CheckTransition()
    {
        CharacteristicComponent _comp = fsm.Owner.transform.GetComponent<CharacteristicComponent>();
        timer += Time.deltaTime;
        if (timer >= timerEnd)
        {
            isDone = true;
            CheckForNextState();
        }
        return base.CheckTransition();
    }

    void CheckForNextState()
    {
        if (fsm.FaunaOwner.GetHunger() || fsm.FaunaOwner.GetThirst())
            NextState = SearchResourcesState;
        else if (fsm.FaunaOwner.IsInGoodHabitat)
        {
            if (fsm.FaunaOwner.GetHunger())
                NextState = SearchFoodState;
            if (fsm.FaunaOwner.GetThirst())
                NextState = SearchWaterState;
        }
    }
}
