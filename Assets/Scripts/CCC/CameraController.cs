using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum EGameMode
{
    Game,
    Tool,
    Map
}

public class CameraController : MonoBehaviour
{
    public event Action OnPauseUI;
    public event Action<Transform> OnSelectElement;
    public event Action<Transform> OnUnSelectElement;

    [SerializeField] InputComponent inputs = null;
    [SerializeField] CreationComponent createComponent = null;
    [SerializeField] PauseUI pauseUI = null;

    public InputComponent InputComponent { get { return inputs; } }

    [field:SerializeField] public CameraComponent AttachedCamera { get; private set; }
    [field: SerializeField] public Camera PlayerCamera { get; private set; }
    [SerializeField] PlayerSettings settings = null;
    [SerializeField] LayerMask layer;
    [SerializeField] float cameraMaxRange = 100;
    [SerializeField] float cameraMapRange = 200;

    [SerializeField] Transform target = null;

    EGameMode currentGameMode = EGameMode.Game;

    public EGameMode CurrentGameMode { get => currentGameMode; set { currentGameMode = value; } }

    bool hasInteract = false;
    bool canSelect = true;
    bool canCameraMoveToTarget = false;
    bool canCameraMoveToPlayer = false;
    bool canCameraMoveToMap = false;


    void Start()
    {
        Init();
        AttachedCamera.Target = transform;
        AttachedCamera.transform.position = transform.position + new Vector3(0, cameraMaxRange, -cameraMaxRange);

    }

    void Update()
    {
        Move();
        Rotate();
        UpdateZoom();
        Interact();
        UpdateCameraPositionToTarget();
        UpdateCameraPositionToPlayer();
        UpdateCameraPositionToMap();
    }

    void Init()
    {
        inputs = GetComponent<InputComponent>();
        if (!inputs) return;
        inputs.Interact.performed += UpdateInteraction;
        inputs.Interact_2.performed += UpdateInteraction;
        inputs.Select.performed += Select;
        inputs.Select_2.performed += Select;
        inputs.Map.performed += OpenMap;
        inputs.Map_2.performed += OpenMap;
        inputs.Pause.performed += Pause;
        inputs.Pause_2.performed += Pause;
        inputs.Pause.performed += (c) => Time.timeScale = 0;
        pauseUI.OnGame += Play;
        pauseUI.OnGame += () => Time.timeScale = 1;
        inputs.Wheel.performed += (a) => ClearTarget();
        inputs.Wheel_2.performed += (a) => ClearTarget();
    }

    void Move()
    {
        if (!inputs) return;
        if (transform.position.z < 790)
        {
            float _moveDirForward = inputs.MoveForward.ReadValue<float>();
            transform.position += transform.forward * settings.Speed * Time.deltaTime * _moveDirForward;
        }
        if (transform.position.z > -790)
        {
            float _moveDirBackward = inputs.MoveBackward.ReadValue<float>();
            transform.position += transform.forward * settings.Speed * Time.deltaTime * -_moveDirBackward;
        }
        if (transform.position.x < 790)
        {
            float _moveDirRight = inputs.MoveRight.ReadValue<float>();
            transform.position += transform.right * settings.Speed * Time.deltaTime * _moveDirRight;
        }
        if (transform.position.x > -790)
        {
            float _moveDirLeft = inputs.MoveLeft.ReadValue<float>();
            transform.position += transform.right * settings.Speed * Time.deltaTime * -_moveDirLeft;
        }


        float _moveDirForwardArrow = inputs.MoveForwardArrow.ReadValue<float>();
        transform.position += transform.forward * settings.Speed * Time.deltaTime * _moveDirForwardArrow;
        float _moveDirBackwardArrow = inputs.MoveBackwardArrow.ReadValue<float>();
        transform.position += transform.forward * settings.Speed * Time.deltaTime * -_moveDirBackwardArrow;
        float _moveDirRightArrow = inputs.MoveRightArrow.ReadValue<float>();
        transform.position += transform.right * settings.Speed * Time.deltaTime * _moveDirRightArrow;
        float _moveDirLeftArrow = inputs.MoveLeftArrow.ReadValue<float>();
        transform.position += transform.right * settings.Speed * Time.deltaTime * -_moveDirLeftArrow;
    }

    void Rotate()
    {
        float _rotValueRight = inputs.RotateRight.ReadValue<float>();
        transform.eulerAngles += transform.up * settings.RotateSpeed * Time.deltaTime * -_rotValueRight;
        float _rotValueLeft = inputs.RotateLeft.ReadValue<float>();
        transform.eulerAngles += transform.up * settings.RotateSpeed * Time.deltaTime * _rotValueLeft;

        float _rotValueRight_2 = inputs.RotateRight_2.ReadValue<float>();
        transform.eulerAngles += transform.up * settings.RotateSpeed * Time.deltaTime * -_rotValueRight_2;
        float _rotValueLeft_2 = inputs.RotateLeft_2.ReadValue<float>();
        transform.eulerAngles += transform.up * settings.RotateSpeed * Time.deltaTime * _rotValueLeft_2;
    }

    void UpdateZoom()
    {
        if(!inputs) return;
        float _axis = inputs.Zoom.ReadValue<float>();
        if (Vector3.Distance(AttachedCamera.transform.position, transform.position) <= settings.MinRange && _axis > 0 || Vector3.Distance(AttachedCamera.transform.position, transform.position) >= settings.MaxRange && _axis < 0) return;
            AttachedCamera.transform.position += AttachedCamera.transform.forward * settings.ZoomSpeed * Time.deltaTime * _axis;
    }

    void UpdateCameraPositionToTarget()
    {
        if(!canCameraMoveToTarget) return;
        GetTypeComponent _type = target.GetComponent<GetTypeComponent>();
        CharacteristicComponent _chara = null;
        if (_type) _chara = _type.Element.GetComponent<CharacteristicComponent>();
        else _chara = target.GetComponent<CharacteristicComponent>();
        if (!_chara) return;
        Vector3 _from = AttachedCamera.transform.position;
        Vector3 _to = target.transform.position + new Vector3(_chara.Characteristic.Distance, _chara.Characteristic.Distance, 0);
        AttachedCamera.transform.position = Vector3.Lerp(_from, _to, Time.deltaTime);
        if (MathUtils.IsAtLocation(AttachedCamera.transform.position, target.transform.position + new Vector3(_chara.Characteristic.Distance, _chara.Characteristic.Distance, 0), 0.5f))
            canCameraMoveToTarget = false;
    }
    void UpdateCameraPositionToPlayer()
    {
        if (!canCameraMoveToPlayer)return;
        Vector3 _from = AttachedCamera.transform.position;
        Vector3 _to = (transform.position + transform.forward) + new Vector3(0, cameraMaxRange, -cameraMaxRange);
        AttachedCamera.transform.position = Vector3.Lerp(_from, _to, Time.deltaTime);
        transform.forward = Vector3.forward;
        if (MathUtils.IsAtLocation(_from, _to, 1f))
            canCameraMoveToPlayer = false;
    }

    void UpdateCameraPositionToMap()
    {
        if (!canCameraMoveToMap) return;
        Vector3 _from = AttachedCamera.transform.position;
        Vector3 _to = transform.position + new Vector3(0, cameraMapRange, 0);
        AttachedCamera.transform.position = Vector3.Lerp(_from, _to, Time.deltaTime);
        transform.forward = Vector3.forward;
        if (MathUtils.IsAtLocation(_from, _to, 1f))
            canCameraMoveToMap = false;
    }

    void Interact()
    {
        if (currentGameMode == EGameMode.Game)
        {
            Vector3 _input = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Ray _r = PlayerCamera.ScreenPointToRay(_input);
            bool _hit = Physics.Raycast(_r.origin, _r.direction, out RaycastHit _result, settings.MaxRange, layer);
            if (_hit && hasInteract)
            {
                if (target)
                    ClearTarget();
                GetTypeComponent _type = _result.transform.GetComponent<GetTypeComponent>();
                target = _type.Element.transform;
                OnSelectElement?.Invoke(target);    

            }
            else if (!_hit && hasInteract && target)
            {
                ClearTarget();
            }
        }
        else if(currentGameMode == EGameMode.Tool && hasInteract)
        {
            createComponent.Create();
        }
    }

    private void ClearTarget()
    {
        if (!target) return;
        OnUnSelectElement?.Invoke(target);
        ResetCamera();
        target = null;
    }

    void UpdateInteraction(InputAction.CallbackContext _context)
    {
        hasInteract = _context.ReadValueAsButton();
    }

    void Select(InputAction.CallbackContext _context)
    {
        if (!target) return;
        if (canSelect)
        {
            transform.position = target.transform.position;
            transform.SetParent(target);
            canSelect = false;
            canCameraMoveToTarget = true;
            canCameraMoveToPlayer = false;
            inputs.DisableMovementControl();
            return;
        }
        else
        {
            ResetCamera();
            return;
        }
    }

    void OpenMap(InputAction.CallbackContext _context)
    {
        Debug.Log("test");
        canCameraMoveToMap = _context.ReadValueAsButton();
    }

    void Pause(InputAction.CallbackContext _context)
    {
        OnPauseUI?.Invoke();
        inputs.ManageInputsActivation(false);
    }

    void Play()
    {
        inputs.ManageInputsActivation(true);
    }

    private void ResetCamera()
    {
        transform.SetParent(null);
        canSelect = true;
        canCameraMoveToTarget = false;
        canCameraMoveToPlayer = true;
        inputs.EnableMovementControl();
    }
}
