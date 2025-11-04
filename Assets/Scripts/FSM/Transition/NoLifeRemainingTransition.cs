using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NoLifeRemainingTransition",menuName =("FSM/Transition/Create NoLifeRemainingTransition"))]
public class NoLifeRemainingTransition : Transition
{
    Fauna fauna = null;
    public override void InitTransition(FSMFauna _fsm)
    {
        base.InitTransition(_fsm);
        fauna = fsm.Owner.GetComponent<Fauna>();
        fauna.onDeath += OnDeath;
    }

    public override bool CheckTransition()
    {
        return base.CheckTransition();
    }

    void OnDeath()
    {
            isDone = true;
    }
}
