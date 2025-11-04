using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//we select what tool to use, first thing shown
public class ToolWheel : MonoBehaviour
{
    [field : SerializeField] public ToolOfCreationPanelUI Owner{get ; private set; } = null;
    [SerializeField] WheelButton wheelButtonType = null;
    [SerializeField] RectTransform targetToSpawnIn;
    [SerializeField] float distanceToCenter = 100;
    [SerializeField] float startingAngle = 90f;
    [SerializeField, HideInInspector] List<CreationModule> modulesList = null;

    public void Open(List<CreationModule> _moduleList)
    {
        modulesList = _moduleList;
        GenerateWheel();
        UIUtilities.ShowUI(gameObject);
    }
    void GenerateWheel()
    {   ClearWheel();
        if (!wheelButtonType) return;
        for (int i = 0; i< modulesList.Count; i++)
        {
            CreationModule _module = modulesList[i];
            if (!_module) continue;
            WheelButton _toolButton = Instantiate(wheelButtonType, targetToSpawnIn) ;
            InitializeButton(_toolButton, _module, i);
        }
    }
    void InitializeButton(WheelButton _button, CreationModule _module, int _index)
    {
        _button.InitializeButton(_module, this);
        float _degRad = startingAngle + ((float)_index / (float)modulesList.Count) * 360f;
        Vector3 _newLoc = _button.transform.position;
        _newLoc.x += Mathf.Sin(_degRad * Mathf.Deg2Rad) * distanceToCenter;
        _newLoc.y += Mathf.Cos(_degRad * Mathf.Deg2Rad) * distanceToCenter;
        _button.transform.position = _newLoc;
        _button.transform.Rotate(Vector3.forward,- _degRad);
    }
    void ClearWheel()
    {
        for (int i = 0;i < targetToSpawnIn.childCount;i++)
        {
            Destroy(targetToSpawnIn.GetChild(i  ).gameObject);
        }
    }
    public void Close()
    {
        ClearWheel();
        UIUtilities.HideUI(gameObject);
    }
}
