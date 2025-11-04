using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GameTime : Singleton<GameTime>
{
    public event Action OnYearPass = null;
    [field:SerializeField] public float timeElapsed { get; private set; } = 0;
    [SerializeField] float timePassSpeed = 1;


    [SerializeField] bool InMinute = true;

    [SerializeField] int timeForYear = 20;
    [SerializeField] int year = 0;

    public int Year => year;
    public int TimeForYear
    {
        get => InMinute ? timeForYear * 60 : timeForYear;
    }

    private void Update()
    {
        UpdateTimer();
    }
    void UpdateTimer()
    {
        timeElapsed += Time.deltaTime * timePassSpeed;
        if (timeElapsed > TimeForYear)
        {
            year++;
            timeElapsed = 0;
            OnYearPass?.Invoke();
        }
    }
}
