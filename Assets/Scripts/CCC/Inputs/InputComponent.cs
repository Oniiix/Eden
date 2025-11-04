using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System.IO;

public class InputComponent : MonoBehaviour
{
    [SerializeField] CameraInputs controls = null;
    [SerializeField] InputAction moveForward = null;
    [SerializeField] InputAction moveForwardArrow = null;
    [SerializeField] InputAction moveBackward = null;
    [SerializeField] InputAction moveBackwardArrow = null;
    [SerializeField] InputAction moveLeft = null;
    [SerializeField] InputAction moveLeftArrow = null;
    [SerializeField] InputAction moveRight = null;
    [SerializeField] InputAction moveRightArrow = null;
    [SerializeField] InputAction rotateRight = null;
    [SerializeField] InputAction rotateRight_2 = null;
    [SerializeField] InputAction rotateLeft = null;
    [SerializeField] InputAction rotateLeft_2 = null;
    [SerializeField] InputAction zoom = null;
    [SerializeField] InputAction interact = null;
    [SerializeField] InputAction interact_2 = null;
    [SerializeField] InputAction select = null;
    [SerializeField] InputAction select_2 = null;
    [SerializeField] InputAction pause = null;
    [SerializeField] InputAction pause_2 = null;
    [SerializeField] InputAction wheel = null;
    [SerializeField] InputAction wheel_2 = null;
    [SerializeField] InputAction map = null;
    [SerializeField] InputAction map_2 = null;

    [SerializeField] List<InputAction> allInputs = null;
	const string fileName = "Binding.txt";
	string overridingInput = "";

	public InputAction MoveForward { get { return moveForward; } }
	public InputAction MoveForwardArrow { get { return moveForwardArrow; } }
	public InputAction MoveBackward { get { return moveBackward; } }
	public InputAction MoveBackwardArrow { get { return moveBackwardArrow; } }
	public InputAction MoveRight { get { return moveRight; } }
	public InputAction MoveRightArrow { get { return moveRightArrow; } }
	public InputAction MoveLeft { get { return moveLeft; } }
	public InputAction MoveLeftArrow { get { return moveLeftArrow; } }
    public InputAction RotateRight { get { return rotateRight; } }
    public InputAction RotateRight_2 { get { return rotateRight_2; } }
    public InputAction RotateLeft { get { return rotateLeft; } }
    public InputAction RotateLeft_2 { get { return rotateLeft_2; } }
    public InputAction Zoom { get { return zoom; } }
    public InputAction Interact { get { return interact; } }
    public InputAction Interact_2 { get { return interact_2; } }
    public InputAction Select { get { return select; } }
    public InputAction Select_2 { get { return select_2; } }
    public InputAction Pause { get { return pause; } }
    public InputAction Pause_2 { get { return pause_2; } }
    public InputAction Wheel { get { return wheel; } }
    public InputAction Wheel_2 { get { return wheel_2; } }
    public InputAction Map { get { return map; } }
    public InputAction Map_2 { get { return map_2; } }

    private void Awake()
    {
        controls = new CameraInputs();
    }


    void Start()
    {
        LoadInput();
    }

    private void OnEnable()
    {
        moveForward = controls.Player.Forward;
        moveForwardArrow = controls.Player.ForwardArrow;
        moveBackward = controls.Player.Backward;
        moveBackwardArrow = controls.Player.BackwardArrow;
        moveLeft = controls.Player.Left;
        moveLeftArrow = controls.Player.LeftArrow;
        moveRight = controls.Player.Right;
        moveRightArrow = controls.Player.RightArrow;
        rotateRight = controls.Player.RotateRight;
        rotateRight_2 = controls.Player.RotateRight_2;
        rotateLeft = controls.Player.RotateLeft;
        rotateLeft_2 = controls.Player.RotateLeft_2;
        zoom = controls.Player.Zoom;
        interact = controls.Player.Interact;
        interact_2 = controls.Player.Interact_2;
        select = controls.Player.Select;
        select_2 = controls.Player.Select_2;
        pause = controls.Player.Pause;
        pause_2 = controls.Player.Pause_2;
        wheel = controls.Player.Wheel;
        wheel_2 = controls.Player.Wheel_2;
        map = controls.Player.Map;
        map_2 = controls.Player.Map_2;

        allInputs.AddRange(new List<InputAction> {
            moveForward,
            moveForwardArrow,
            moveBackward,
            moveBackwardArrow,
            moveRight,
            moveRightArrow,
            moveLeft,
            moveLeftArrow,
            rotateRight,
            rotateRight_2,
            rotateLeft,
            rotateLeft_2,
            zoom,
            interact,
            interact_2,
            select,
            select_2,
            pause,
            pause_2,
            wheel,
            wheel_2,
            map,
            map_2
        });
        ManageInputsActivation(true);
    }

    private void OnDisable()
    {
        ManageInputsActivation(false);
    }

    public void DisableMovementControl()
    {
        moveForward.Disable();
        moveForwardArrow.Disable();
        moveBackward.Disable();
        moveBackwardArrow.Disable();
        moveRight.Disable();
        moveRightArrow.Disable();
        moveLeft.Disable();
        moveLeftArrow.Disable();
    }

    public void DisableInteract()
    {
        interact.Disable();
        interact_2.Disable();
    }

    public void EnableInteract()
    {
        interact.Enable();
        interact_2.Enable();
    }

    public void EnableMovementControl()
    {
        moveForward.Enable();
        moveForwardArrow.Enable();
        moveBackward.Enable();
        moveBackwardArrow.Enable();
        moveRight.Enable();
        moveRightArrow.Enable();
        moveLeft.Enable();
        moveLeftArrow.Enable();
    }

    public void ManageInputsActivation(bool _value)
    {
        foreach (InputAction input in allInputs)
        {
            if (_value)
                input.Enable();
            else input.Disable();
        }
    }
    public void RebindInput(InputAction _input)
    {
        _input.Disable();
        InputActionRebindingExtensions.RebindingOperation _rebind = _input.PerformInteractiveRebinding();
        _rebind.WithControlsExcluding("Mouse");
        _rebind.OnComplete((_callback) =>
        {
            _callback.Dispose();
            _input.Enable();
            SaveInputs();
        });
        _rebind.Start();
    }
    void SaveInputs()
    {
		overridingInput = controls.SaveBindingOverridesAsJson();
        File.WriteAllText(fileName, overridingInput);
	}
	void LoadInput()
    {
        if (!File.Exists(fileName))
            return;
        string _json = File.ReadAllText(fileName);
        controls.LoadBindingOverridesFromJson(_json);
    }
}
