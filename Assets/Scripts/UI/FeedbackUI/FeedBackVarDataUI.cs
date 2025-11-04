using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FeedBackVarDataUI : MonoBehaviour
{
    CharacteristicData data = null;
    
    [SerializeField] TMP_Text varNameText = null;
    [SerializeField] TMP_Text varStatText = null;

    public void Initialize(CharacteristicData _data)
    {
      data = _data;
        ActualizeUI();
    }
    public void ActualizeUI()
    {
        varNameText.text = data.VarName;
        varStatText.text = $"{data.CurrentValue}/{data.MaxValue}";
    }
}
