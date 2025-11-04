using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUtilities 
{
    public static void ShowUI(GameObject _gameObject)
    {
        _gameObject.SetActive(true);
    }
    public static void HideUI(GameObject _gameObject)
    {
        _gameObject.SetActive(false);
    }
}
