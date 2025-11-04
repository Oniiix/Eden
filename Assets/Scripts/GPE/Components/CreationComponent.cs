using System.Collections.Generic;
using UnityEngine;

public class CreationComponent : MonoBehaviour
{
    [field: SerializeField] public List<CreationModule> Modules { get; private set; } = new();
    [SerializeField] CreationAction currentAction = null;
    public CreationAction CurrentAction
    {
        get => currentAction;
        set
        {
            currentAction = value;
            if (currentAction)
                currentAction.Init();
        }
    }

    public void Create()
    {
        if (!CurrentAction) return;
        CurrentAction.Use();
    }
    #region UI
    void BindToUI()
    {

        GetComponent<InputComponent>().Wheel.performed += (e) =>
            {
                GameUI.Instance.ToolsOfCreationPanel.OpenUI(Modules);
            };
        GetComponent<InputComponent>().Wheel_2.performed += (e) =>
            {
                GameUI.Instance.ToolsOfCreationPanel.OpenUI(Modules);
            };
    }
    #endregion
    private void Start()
    {
        BindToUI();
        InvokeRepeating("DrawAction", .1f, .1f);
    }

    void DrawAction()
    {
        if (!CurrentAction)
            return;
        CurrentAction.DrawAction();
    }
}
