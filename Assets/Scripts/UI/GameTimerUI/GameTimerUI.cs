using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimerUI : MonoBehaviour
{
    [SerializeField] TMP_Text dateText = null;
    int monthValue = 0;
    void UpdateUI()
    {
        if (!dateText || !GameTime.Instance) return;

        float _part = GameTime.Instance.timeElapsed / GameTime.Instance.TimeForYear;
        monthValue = (int)(_part * 12) + 1;

        dateText.text = $"mois: {monthValue} / an {GameTime.Instance.Year}";
    }
    private void Update()
    {
        UpdateUI(); 
    }
}
