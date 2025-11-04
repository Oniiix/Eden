using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackDataPanelUI : MonoBehaviour
{
    [SerializeField] GameUI gameUI = null;
    [SerializeField] StatusWindow statusWindowType = null;
    [SerializeField, HideInInspector] Fauna currentElement= null;
    [SerializeField] List<StatusWindow> statusWindowList = new();
    [SerializeField] FeedBackStaticData staticData = null;

    #region status windows
    public StatusWindow MakeNewStatusWindow(Transform _owner,  StatusWindow _type = null)
    {
        if (!_type)
        {
            _type = statusWindowType;
        }
        StatusWindow _window = Instantiate(_type, transform);
        _window.InitializeStatus(_owner,  gameUI.controller.PlayerCamera);
        UIUtilities.HideUI(_window.gameObject);
        statusWindowList.Add(_window);
        return _window;
    }
    public void ShowListFromTransform(Transform _transform)
    {
        Fauna _target = _transform.GetComponent<Fauna>();
        if (!_target) return;
        currentElement = _target;
        currentElement.SetUIVisible();
        gameObject.SetActive(true);
    }
    public void HideListFromTransform(Transform _transform)
    {
        Fauna _target = _transform.GetComponent<Fauna>();
        if (!_target) return;
        
        _target.SetUIInVisible();
        currentElement = null;
    }
    #endregion

    #region profilePicture
    public void ShowProfilePictureFromTransform(Transform _transform)
    {
        Fauna _target = _transform.GetComponent<Fauna>();
        if (!_target) return;
        staticData.SetProfileIconImage(_target.elementIcon);
        
    }

    #endregion

    #region stats
    void ActivateStatsFromTransform(Transform _transform)
    {
        Fauna _target = _transform.GetComponent<Fauna>();
        if (!_target) return;
        staticData.InitializeStats(_target);
    }

    #endregion
    public void ShowUI(Transform _t)
    {
        ShowProfilePictureFromTransform(_t);
        ActivateStatsFromTransform(_t);
        ShowListFromTransform(_t);
        staticData.ShowUI(); 
    }
    public void HideUI(Transform _t)
    {
        staticData.HideUI();
        
    }
}
