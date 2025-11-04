using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RebindUI : MonoBehaviour
{
	[SerializeField, Space(10)] InputComponent inputs = null;
	[SerializeField, Header("GameObject"), Space(10)] GameObject RebindUI_GO = null;
	[SerializeField] GameObject SettingsUI_GO = null;
	[SerializeField, Header("Button"), Space(10)]
	Button Return = null;
	[SerializeField]
	Button Forward1 = null, Forward2 = null, Backward1 = null, Backward2 = null, Left1 = null, Left2 = null, Right1 = null, Right2 = null, RotateLeft1 = null,
		RotateLeft2 = null, RotateRight1 = null, RotateRight2 = null, Refocused1 = null, Refocused2 = null, Interact1 = null, Interact2 = null, Pause1 = null, Pause2 = null,
		ToolWheel1 = null, ToolWheel2 = null;
	[SerializeField, Header("Text"), Space(10)]
	TMP_Text Forward1Text = null;
	[SerializeField]
	TMP_Text Forward2Text = null, Backward1Text = null, Backward2Text = null, Left1Text = null, Left2Text = null, Right1Text = null, Right2Text = null, RotateLeft1Text = null,
		RotateLeft2Text = null, RotateRight1Text = null, RotateRight2Text = null, Refocused1Text = null, Refocused2Text = null, Interact1Text = null, Interact2Text = null,
		Pause1Text = null, Pause2Text = null, ToolWheel1Text = null, ToolWheel2Text = null;

	private void Start()
	{
		Return.onClick.AddListener(() => ReturnButtonClick());
		Init();
	}
	private void Update()
	{
		UpdateTextInput();
	}
	void Init()
	{
		Forward1.onClick.AddListener(() => inputs.RebindInput(inputs.MoveForward));
		Forward2.onClick.AddListener(() => inputs.RebindInput(inputs.MoveForwardArrow));
		Backward1.onClick.AddListener(() => inputs.RebindInput(inputs.MoveBackward));
		Backward2.onClick.AddListener(() => inputs.RebindInput(inputs.MoveBackwardArrow));
		Left1.onClick.AddListener(() => inputs.RebindInput(inputs.MoveLeft));
		Left2.onClick.AddListener(() => inputs.RebindInput(inputs.MoveLeftArrow));
		Right1.onClick.AddListener(() => inputs.RebindInput(inputs.MoveRight));
		Right2.onClick.AddListener(() => inputs.RebindInput(inputs.MoveRightArrow));
		RotateLeft1.onClick.AddListener(() => inputs.RebindInput(inputs.RotateLeft));
		RotateLeft2.onClick.AddListener(() => inputs.RebindInput(inputs.RotateLeft_2));
		RotateRight1.onClick.AddListener(() => inputs.RebindInput(inputs.RotateRight));
		RotateRight2.onClick.AddListener(() => inputs.RebindInput(inputs.RotateRight_2));
		Refocused1.onClick.AddListener(() => inputs.RebindInput(inputs.Select));
		Refocused2.onClick.AddListener(() => inputs.RebindInput(inputs.Select_2));
		Interact1.onClick.AddListener(() => inputs.RebindInput(inputs.Interact));
		Interact2.onClick.AddListener(() => inputs.RebindInput(inputs.Interact_2));
		Pause1.onClick.AddListener(() => inputs.RebindInput(inputs.Pause));
		Pause2.onClick.AddListener(() => inputs.RebindInput(inputs.Pause_2));
		ToolWheel1.onClick.AddListener(() => inputs.RebindInput(inputs.Wheel));
		ToolWheel2.onClick.AddListener(() => inputs.RebindInput(inputs.Wheel_2));
	}
	void UpdateTextInput()
	{
		Forward1Text.text = UpdateText(inputs.MoveForward , Forward1Text.text);
		Forward2Text.text = UpdateText(inputs.MoveForwardArrow, Forward2Text.text);
		Backward1Text.text = UpdateText(inputs.MoveBackward , Backward1Text.text);
		Backward2Text.text = UpdateText(inputs.MoveBackwardArrow , Backward2Text.text);
		Left1Text.text = UpdateText(inputs.MoveLeft , Left1Text.text);
		Left2Text.text = UpdateText(inputs.MoveLeftArrow , Left2Text.text);
		Right1Text.text = UpdateText(inputs.MoveRight , Right1Text.text);
		Right2Text.text = UpdateText(inputs.MoveRightArrow , Right2Text.text);
		RotateLeft1Text.text = UpdateText(inputs.RotateLeft , RotateLeft1Text.text);
		RotateLeft2Text.text = UpdateText(inputs.RotateLeft_2 , RotateLeft2Text.text);
		RotateRight1Text.text = UpdateText(inputs.RotateRight , RotateRight1Text.text);
		RotateRight2Text.text = UpdateText(inputs.RotateRight_2 , RotateRight2Text.text);
		Refocused1Text.text = UpdateText(inputs.Select, Refocused1Text.text);
		Refocused2Text.text = UpdateText(inputs.Select_2, Refocused2Text.text);
		Interact1Text.text = UpdateText(inputs.Interact, Interact1Text.text);
		Interact2Text.text = UpdateText(inputs.Interact_2, Interact2Text.text);
		Pause1Text.text = UpdateText(inputs.Pause, Pause1Text.text);
		Pause2Text.text = UpdateText(inputs.Pause_2, Pause2Text.text);
		ToolWheel1Text.text = UpdateText(inputs.Wheel, ToolWheel1Text.text);
		ToolWheel2Text.text = UpdateText(inputs.Wheel_2, ToolWheel2Text.text);
	}
	string UpdateText(InputAction _input, string _text)
	{
		List<InputBinding> _list = _input.bindings.ToList();
		foreach (var _item in _list)
		{
			if (_item.path.Contains("<Keyboard>/"))
				_text = $"{_item.path.Replace("<Keyboard>/", "")}";
			if (_item.path.Contains("<Mouse>/"))
				_text = $"{_item.path.Replace("<Mouse>/", "")}";
		}
		return _text;
	}
	void ReturnButtonClick()
	{
		UIUtilities.ShowUI(SettingsUI_GO);
		UIUtilities.HideUI(RebindUI_GO);
	}
}
