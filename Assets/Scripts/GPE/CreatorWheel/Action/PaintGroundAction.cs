using UnityEngine;

[CreateAssetMenu(fileName = "PaintGroundAction", menuName = "CreationWheel/Action/Create PaintGround action")]
public class PaintGroundAction : CreationAction
{
    [field: SerializeField, Header("Paint")] EGround GroundType = EGround.None;

    public override void Use()
    {
        if (GroundType == EGround.None || !SphereDeProjectMouse(layer, data.SpawnerRadius ,out RaycastHit[] _hitInfo)) return;

        int _size = _hitInfo.Length;
        for (int i = 0; i < _size; i++)
        {
            Node _node = _hitInfo[i].collider.GetComponent<Node>();
            _node.GroundType = GroundType;
        }
    }
}
