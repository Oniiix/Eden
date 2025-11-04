using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComp : MonoBehaviour
{
    public static int MOVING_PARAM = Animator.StringToHash("IsMoving");
    public static int DEAD_PARAM = Animator.StringToHash("IsDead");

    [SerializeField] Animator animator = null;
    [SerializeField] FSMComponent fsmComp = null;
    [SerializeField] Fauna fauna = null;
    bool FSMValid = false;


    private void Update()
    {
        if (!fsmComp)
            return;

        UpdateMoving();
        WashingUpdate();

    }

    void UpdateMoving()
    {
        if (fauna.MovingComponent.IsMoving)
            animator.SetBool(MOVING_PARAM, true);
        else
            animator.SetBool(MOVING_PARAM, false);
    }

    private void WashingUpdate()
    {
        if (fauna.IsDead)
            animator.SetBool(DEAD_PARAM, true);
        else
            animator.SetBool(DEAD_PARAM, false);
    }
}
