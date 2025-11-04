using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccebilityUI : MonoBehaviour
{
	[SerializeField] ColorblindSimulationImageEffect colorblindSimulationImageEffect = null;
	[SerializeField, Header("GameObject"), Space(10)] GameObject SettingsUI_GO = null;
	[SerializeField] GameObject AccessibilityUI_GO = null;
	[SerializeField, Header("Button"), Space(10)] Button Return = null;
	[SerializeField, Header("Dropdown"), Space(10)] TMP_Dropdown colorBlind = null;

	private void Start()
	{
		Return.onClick.AddListener(() => ReturnButtonClick());
		string[] _e = Enum.GetNames(typeof(ColorDeficiencyType));
		for (int i = 0; i < _e.Length; i++)
		{
			colorBlind.options.Add(new TMP_Dropdown.OptionData(_e[i]));
		}
		colorBlind.value = 0;
	}
	private void Update() => SetColorBlind();
	void SetColorBlind()
	{
		switch (colorBlind.value)
		{
			case 0:
				colorblindSimulationImageEffect.SelectedDeficiency = ColorDeficiencyType.None;
				break;
			case 1:
				colorblindSimulationImageEffect.SelectedDeficiency = ColorDeficiencyType.Protanopia;
				break;
			case 2:
				colorblindSimulationImageEffect.SelectedDeficiency = ColorDeficiencyType.Deuteranopia;
				break;
			case 3:
				colorblindSimulationImageEffect.SelectedDeficiency = ColorDeficiencyType.Tritanopia;
				break;
			default:
				break;
		}
	}
	void ReturnButtonClick()
	{
		UIUtilities.ShowUI(SettingsUI_GO);
		UIUtilities.HideUI(AccessibilityUI_GO);
	}
}
