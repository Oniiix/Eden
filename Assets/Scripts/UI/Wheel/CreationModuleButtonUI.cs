using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreationModuleButtonUI : MonoBehaviour
{
    [field: SerializeField] public TMP_Text Text { get; private set; } = null;
    [field: SerializeField] public Button TargetButton { get; private set; } = null;
}
