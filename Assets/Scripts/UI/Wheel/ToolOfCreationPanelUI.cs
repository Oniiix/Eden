using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//in gameUI , owns the wheel, the option selection panel and the action selection panel
public class ToolOfCreationPanelUI : MonoBehaviour
{
    [field: SerializeField] public CreationActionUI creationActionSelection { get; private set; } = null;
    [field : SerializeField] public ToolWheel toolWheel {get; private set;} = null;
    [field : SerializeField] public CreationModuleOptionsPanelUI creationModuleOption {get; private set;} = null;
    bool isOpen = false;
    public void OpenUI(List<CreationModule> _moduleList)
    {
        if (!isOpen)
        {
            CreationComponent _component = GameUI.Instance.controller.GetComponent<CreationComponent>();
            _component.CurrentAction = null;
            OpenToolWheel(_moduleList);
            GameUI.Instance.controller.CurrentGameMode = EGameMode.Tool;
            isOpen = true;
        }
        else
        {
            CloseUI();
        }
    }
    public void CloseUI()
    {
        CloseToolWheel();
        CloseCreationModuleOptions();
        CloseCreationActionSelection();
        isOpen = false;
        GameUI.Instance.controller.CurrentGameMode = EGameMode.Game;

    }
    #region toolWheel
    public void OpenToolWheel(List<CreationModule> _moduleList)
    {
        toolWheel.Open(_moduleList);
        CloseCreationModuleOptions();
        CloseCreationActionSelection();
    }
  public  void CloseToolWheel()
    {
        toolWheel.Close();
    }
    #endregion
    #region creation module selection
    public void OpenCreationModuleOptions(CreationModule _module)
    {
        creationModuleOption.Open(_module);
        CloseToolWheel();
        CloseCreationActionSelection();
    }
    public void CloseCreationModuleOptions()
    {
        creationModuleOption.Close();
    }
    #endregion
    #region creation action selection
    public void OpenCreationActionSelection(KeyValue<string, CreationAction[]>  _actionsToSet)
    {
        creationActionSelection.Open(_actionsToSet);
        CloseToolWheel();
        CloseCreationModuleOptions();
    }

   public void CloseCreationActionSelection()
    {
        creationActionSelection.Close();
    }
    #endregion
}
