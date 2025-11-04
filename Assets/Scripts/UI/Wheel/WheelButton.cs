using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
if module actions list size over one show creation modules options UI 
    if not go directly to SelectAction
 * */

public class WheelButton : MonoBehaviour
{
    [SerializeField]   ToolWheel owner = null;
    [SerializeField] RawImage toolImage = null;
    [SerializeField] Button button= null;
    [SerializeField, HideInInspector] CreationModule module = null;
    public void InitializeButton(CreationModule  _tool, ToolWheel _owner)
    {
        module = _tool; 
        owner = _owner;
        SetToolImage(module.Icon);
        button.onClick.AddListener(SelectTool);
    }
    public void SetToolImage(Texture2D _texture)
    {
        toolImage.texture = _texture;
    }
    void SelectTool()
    {
        if (module.Actions.Count<=0 )
        {
            return;
        }
        owner.Owner.CloseToolWheel();
        //there is more than one option, so we give the choice
        if (module.Actions.Count>1 )
        {

            owner.Owner.OpenCreationModuleOptions(module);
            return;
        }
        owner.Owner.OpenCreationActionSelection(module.Actions[0]);
    }

}
