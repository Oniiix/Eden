using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
	public event Action OnGame;
	[field: SerializeField] public CameraController controller { get; private set; } = null;
	[SerializeField, Header("GameObject"), Space(10)] GameObject GameUI_GO = null;
	[SerializeField] GameObject PauseUI_GO = null, SettingsUI_GO = null;
	[SerializeField, Header("Button"), Space(10)] Button Resume = null;
	[SerializeField] Button Settings = null, Quit = null;

	private void Start()
	{
		Resume.onClick.AddListener(() => ResumeButtonClick());
		Settings.onClick.AddListener(() => SettingsButtonClick());
		Quit.onClick.AddListener(() => QuitButtonClick());
		controller.OnPauseUI += PauseMenuUI;
	}
	void PauseMenuUI()
	{
		UIUtilities.ShowUI(PauseUI_GO);
		UIUtilities.HideUI(GameUI_GO);
	}
	void ResumeButtonClick()
	{
		OnGame?.Invoke();
		UIUtilities.ShowUI(GameUI_GO);
		UIUtilities.HideUI(PauseUI_GO);
	}
	void SettingsButtonClick()
	{
		UIUtilities.ShowUI(SettingsUI_GO);
		UIUtilities.HideUI(PauseUI_GO);
	}
	void QuitButtonClick()
	{
		SceneManager.LoadScene(0);
	}
}
