using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedBackStaticData : MonoBehaviour
{
    #region selectedIcon
    [SerializeField] RawImage profileIconImage = null;
    [SerializeField] StaticFeedbackStatUI stats = null;
    #endregion
    public void ShowUI()
    {
        profileIconImage.gameObject.SetActive(true);
        stats.ShowUI();
        gameObject.SetActive(true);
    }
    public void HideUI()
    {
        profileIconImage.gameObject.SetActive(false);
        stats.HideUI();
        gameObject.SetActive(false);
    }
    public void SetProfileIconImage(Texture2D _texture)
    {
        profileIconImage.texture = _texture;
    }
    public void InitializeStats(Element _element)
    {
        stats.SetCurrentStats(_element);
    }
}