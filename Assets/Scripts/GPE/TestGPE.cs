using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.UIElements;
#endif
using UnityEngine;

public class TestGPE : MonoBehaviour
{
    [SerializeField] CreationModule module = null;
    CreationAction action = null;

    float currentTime = 0;

    private void Start()
    {
        action = module.Actions["Ground"][1];
        action.Init();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= 1)
        {
            currentTime = 0;
            action.Use();
        }
    }
}
