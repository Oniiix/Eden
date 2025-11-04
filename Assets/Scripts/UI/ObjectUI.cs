using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectUI : MonoBehaviour
{
   [SerializeField] Image hoveredIcon = null;

    private void OnMouseEnter()
    {
        OnMouseStartHover();
    }
    private void OnMouseExit()
    {
        OnMouseEndHover();
    }

    virtual protected void OnMouseStartHover()
    {
       hoveredIcon.gameObject.SetActive(true);
    }
    virtual protected void OnMouseEndHover()
    {
       hoveredIcon.gameObject.SetActive(false);
    }

}
