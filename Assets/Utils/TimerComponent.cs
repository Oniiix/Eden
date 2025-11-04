using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerComponent : MonoBehaviour
{
    public event Action OnTimerEnd = null;
    [SerializeField] float currentTime = 0;
    [SerializeField] float maxTime = 5;
    [SerializeField] float timePassSpeed = 1;
    [SerializeField] bool loop = true;
    [field:SerializeField] public bool CanTick { get; set; } = false;




    void Update() => UpdateTimer();
    void UpdateTimer()
    {
        if (!CanTick) return;

        currentTime += Time.deltaTime * timePassSpeed;
        if (currentTime >= maxTime)
        {
            OnTimerEnd?.Invoke();
            currentTime = 0;
            CanTick = loop ? true : false;
        }
    }
}
