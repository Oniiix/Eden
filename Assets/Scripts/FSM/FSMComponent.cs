using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMComponent : MonoBehaviour
{
    [field: SerializeField] public FSMFauna fsm = null;

    [field: SerializeField] FSMFauna currentFSM = null;

    void Start()
    {
        currentFSM = Instantiate<FSMFauna>(fsm);
        currentFSM.InitFSM(this);
    }

    void Update()
    {
        currentFSM?.UpdateFSM();
    }

    private void OnDestroy()
    {
        currentFSM.ExitFSM();
    }
}
