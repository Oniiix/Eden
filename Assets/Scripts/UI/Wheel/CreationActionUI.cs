using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//the panel where we select the action to use (after the option selection panel)
public class CreationActionUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField,HideInInspector] CreationAction[] actionsList = null;
    [SerializeField] CreationModuleButtonUI buttonTypeToSpawn = null;
    [SerializeField] RectTransform targetTransform= null;
    [SerializeField] TMP_Text nameText = null;
    public void Open(KeyValue<string, CreationAction[]> _actions)
    {
        actionsList = _actions.Value;
        nameText    .text = _actions.Key;
 
        Generate();
        UIUtilities.ShowUI(gameObject);
    }

    void Generate()
    {
        Clear();
        for (int i = 0; i < actionsList.Length; i++)
        {
            CreationAction _action = actionsList[i];
            if (!_action) return;
            CreationModuleButtonUI _button = Instantiate(buttonTypeToSpawn, targetTransform);
            _button.Text.text = _action.ActionName;
            _button.TargetButton.onClick.AddListener(() =>
            {

                SetCurrentAction(_action);
            });
        }
    }
    void SetCurrentAction(CreationAction _action)
    {
        CreationComponent _component  = GameUI.Instance.controller.GetComponent<CreationComponent>();
        _component.CurrentAction = _action;
    }
    void Clear()
    {
        for (int i = 0; i< targetTransform.childCount; i++)
        {
            Destroy(targetTransform.GetChild(i).gameObject);
        }

    }

    public void Close()
    {
        UIUtilities.HideUI(gameObject);
        Clear();
    }

 

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameUI.Instance.controller.InputComponent.DisableInteract();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameUI.Instance.controller.InputComponent.EnableInteract();
    }
}
