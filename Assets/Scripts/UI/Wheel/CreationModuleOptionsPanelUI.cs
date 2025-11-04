using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//shows the possible types of data to generate(ex : Fauna, Flora, etc) after wheel
public class CreationModuleOptionsPanelUI : MonoBehaviour
{
    [SerializeField] ToolOfCreationPanelUI owner = null;
    [SerializeField] CreationModuleButtonUI buttonType = null;
    [SerializeField] RectTransform targetToSpawnIn = null;
    [SerializeField, HideInInspector] CreationModule currentModule= null;
    public void Open(CreationModule _module)
    {
        currentModule  = _module;
        Generate(currentModule);
        UIUtilities.ShowUI(gameObject);
    }
    public void Close()
    {
        UIUtilities.HideUI(gameObject);
        Clear();
    }

    void Generate(CreationModule _module)
    {
        Clear();
        if (!_module)
        {
            Debug.LogError("[CreationModuleOptionsPanelUI::Generate] _module is null");
            return;
        }
        for (int i = 0; i <_module.Actions.Count;i++)
        {
            string _actionName = _module.Actions[i].Key;
            int _index = i;
            CreationModuleButtonUI _newButton = Instantiate(buttonType, targetToSpawnIn);
            if (!_newButton) continue;
            _newButton.Text.text = _actionName;
            _newButton.TargetButton.onClick.AddListener(() =>
            {
                owner.OpenCreationActionSelection(_module.Actions[_index]);
            });
        }
    }
    void Clear()
    {
        for (int i = 0; i < targetToSpawnIn.childCount;i++)
        {
            Destroy(targetToSpawnIn.GetChild(i).gameObject);
        }
    }

}
