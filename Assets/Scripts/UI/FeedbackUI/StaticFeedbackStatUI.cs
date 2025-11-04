using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StaticFeedbackStatUI : MonoBehaviour
{
    [SerializeField] TMP_Text maxAgeText = null;
    [SerializeField] TMP_Text habitatListText = null;
    [SerializeField] TMP_Text elementTypeText = null;
    [SerializeField] TMP_Text dietTypeText = null;

    Characteristic charac = null;

    #region stats
    List<EHabitatType> habitats;
    int maxAge;
    TTypeEnum elementType;
    TDietTypeEnum dietType;
    #endregion
    public void SetCurrentStats(Element _element)
    {
        charac = _element.CharacteristicComponent.Characteristic;
        
        maxAge = charac.Age.MaxValue;
        habitats = charac.Habitats;
        if (charac as FaunaCharacteristic)
        {
            FaunaCharacteristic _fauna = (FaunaCharacteristic)charac;
            elementType = _fauna.ElementType;
            dietType = _fauna.DietType;
        }
        else if(charac as FloraCharacteristic) 
        {
            //CACA
            return;
        }

    }
    void Initialize()
    {
        //max age
        maxAgeText.text  = maxAge.ToString();
   
        if (habitats == null)
        {

            return;
        }
        //habitats
        string _habitListString = "";
       for (int i = 0; i < habitats.Count; i++)
        {
            _habitListString += habitats[i].ToString() + '\n';
        }
         habitatListText.text = _habitListString;
        //fauna
        FaunaCharacteristic _fauna = (FaunaCharacteristic)charac;
        if (_fauna)
        {
            elementTypeText.text = elementType.ToString();
            dietTypeText.text = dietType.ToString();
        }
  


    }
    public void ShowUI()
    {
        Initialize();
        gameObject.SetActive(true);
    }
    public void HideUI()
    {
        gameObject.SetActive(false);

    }

}
