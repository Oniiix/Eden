using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : Singleton<GameUI>
{
    [field: SerializeField] public CameraController controller { get; private set; } = null;
    [field: SerializeField] public ToolOfCreationPanelUI ToolsOfCreationPanel { get; private set; } = null;
    [field : SerializeField] public FeedBackDataPanelUI FeedBackDataPanelUI {get; private set;} = null;
    private void Start()
    {
        BindEvents();
    }
    void BindEvents()
    {
        if (!controller)
            return;
        controller.OnSelectElement += FeedBackDataPanelUI.ShowUI;
        controller.OnUnSelectElement += FeedBackDataPanelUI.HideListFromTransform;
        controller.OnUnSelectElement += FeedBackDataPanelUI.HideUI;
    }
}
