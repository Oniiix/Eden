using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class StatusWindow : MonoBehaviour
{
    [SerializeField]    Characteristic data= null;
                     //the target we follow
    [SerializeField] Transform owner = null;

                     //the target we add the data to
    [SerializeField] RectTransform targetTransform = null;
    [SerializeField] FeedBackVarDataUI dataType = null;

    [SerializeField] List<FeedBackVarDataUI> statusList = new();
    [SerializeField] Camera targetCamera = null;
    [SerializeField] Vector2 offset ;
    
    public void InitializeStatus(Transform _owner,  Camera _targetCamera)
    {
        owner = _owner;
        targetCamera = _targetCamera;
        GetData();
    }
    private void Start()
    {
        ShowUI();
        InvokeRepeating(nameof(UpdateUI), 1, 1);
    }
    public void ShowUI()
    {
        GenerateList();
        gameObject.SetActive(true);
    }
    void GetData()
    {
        Element _element = owner.GetComponent<Element>();
        if (!_element)
            return;
        
        
        if (_element as Fauna)
        {
            Fauna _fauna = (Fauna)_element;
            data = _fauna.faunaChara;
        }
        else if( _element as Flora)
        {
            Flora _flora = (Flora)_element;
            data = _flora.floraChara;
        }
    }
    void UpdateUI()
    {  

        GenerateList();
    }
    void GenerateList()
    {
        ClearList();
        if (!data) return;
        RectTransform _rectTransform = (RectTransform)dataType.transform;
       
        Vector3 _dataOffset = new Vector3(0, _rectTransform.rect.height, 0   );
        List<CharacteristicData> charList = data.AllDatas(); 

        for (int i = 0; i < charList.Count; i++) 
        {
            FeedBackVarDataUI _dataUI = Instantiate(dataType, targetTransform);
            //Debug.Log($"var name :{charList[i].VarName}, value: {charList[i].CurrentValue}");
            _dataUI.Initialize(charList[i]);
            _dataUI.transform.position = transform.position + statusList.Count * _dataOffset;
            statusList.Add(_dataUI);
        }
    }

    void ClearList()
    {   
        for (int i = 0; i < targetTransform.childCount; i++)
        {
            Destroy(targetTransform.GetChild(i).gameObject);
        }
       statusList.Clear();
    }
    public void HideUI()
    {
        gameObject.SetActive(false);
        ClearList();
    }
    
    
    
    
    /*leaving this here, i will remove when i find something that would do what i want it to do
    */
    private void Update()
    {
        UpdateLocation();
    }
    void UpdateLocation()
    {
        if (!owner || !targetCamera) return;
        Vector3 _newPos = targetCamera.WorldToScreenPoint(owner.position ) + new Vector3(offset.x, offset.y, 0);
        
        transform.position = _newPos;
    }
}
