using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
	[SerializeField] PlayerSettings settings = null;
	[SerializeField, Header("GameObject"), Space(10)] GameObject PauseUI_GO = null;
	[SerializeField] GameObject SettingsUI_GO = null, RebindUI_GO = null, AccessibilityUI_GO = null;
	[SerializeField, Header("Button"), Space(10)] Button Rebind = null;
	[SerializeField] Button Accessiblity = null, Return = null;
	[SerializeField, Header("Slider"), Space(10)] Slider SpeedCameraMovementSlider = null;
	[SerializeField] Slider SpeedZoomSlider = null, SpeedRotationSlider = null;
	[SerializeField, Header("text"), Space(10)] TMP_Text SpeedCameraMovementText = null;
	[SerializeField] TMP_Text SpeedZoomText = null, SpeedRotationText = null;

	private void Start()
	{
		InitSlider();
		Rebind.onClick.AddListener(() => RebindButtonClick());
		Accessiblity.onClick.AddListener(() => AccessibilityButtonClick());
		Return.onClick.AddListener(() => ReturnButtonClick());
	}
	private void Update()
	{
		UpdateText();
		UpdateSlider();
	}
	void InitSlider()
	{
		SpeedCameraMovementSlider.value = settings.Speed;
		SpeedZoomSlider.value = settings.ZoomSpeed;
		SpeedRotationSlider.value = settings.RotateSpeed;
	}
	void UpdateSlider()
	{
		settings.Speed = SpeedCameraMovementSlider.value;
		settings.RotateSpeed = SpeedRotationSlider.value;
		settings.ZoomSpeed = SpeedZoomSlider.value;
	}
	void UpdateText()
	{
		SpeedCameraMovementText.text = $"{Math.Round(settings.Speed, 2)}";
		SpeedZoomText.text = $"{Math.Round(settings.ZoomSpeed, 2)}";
		SpeedRotationText.text = $"{Math.Round(settings.RotateSpeed, 2)}";
	}
	void RebindButtonClick()
	{
		UIUtilities.ShowUI(RebindUI_GO);
		UIUtilities.HideUI(SettingsUI_GO);
	}
	void AccessibilityButtonClick()
	{
		UIUtilities.ShowUI(AccessibilityUI_GO);
		UIUtilities.HideUI(SettingsUI_GO);
	}
	void ReturnButtonClick()
	{
		UIUtilities.ShowUI(PauseUI_GO);
		UIUtilities.HideUI(SettingsUI_GO);
	}
}