using UnityEngine;

public class CreationAction : ScriptableObject
{
    [SerializeField] protected LayerMask layer;
    [field: SerializeField, Header("UI")] public string ActionName { get; set; } = "action";

    [SerializeField, Header("Spawn Settings")] protected SpawnerData data = null;

    public virtual void Use() { }

    public virtual void Init() { }
    public virtual void DrawAction() { }

    protected bool RayDeProjectMouse(LayerMask _layer ,out RaycastHit _hitInfo)
    {
        Camera _camera = Camera.main;
        Ray _r = _camera.ScreenPointToRay(Input.mousePosition);
        bool _hit = Physics.Raycast(_r, out _hitInfo, 10000, _layer);
        return _hit;
    }

    protected bool SphereDeProjectMouse(LayerMask _layer, float _sphereRadius, out RaycastHit[] _hitInfo)
    {
        Camera _camera = Camera.main;
        Ray _r = _camera.ScreenPointToRay(Input.mousePosition);
        _hitInfo = Physics.SphereCastAll(_r, _sphereRadius, 1000, _layer);
        return _hitInfo.Length > 0;
    }
}
