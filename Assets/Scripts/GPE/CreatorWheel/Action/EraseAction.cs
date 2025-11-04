using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(fileName = "EraseAction", menuName = "CreationWheel/Action/Create Erase action")]
public class EraseAction : CreationAction
{
    [SerializeField] LayerMask nodeLayer;



    public override void Use()
    {
        if (data.DensityType == ESpawnerToolDensity.Single)
        {
            if (!RayDeProjectMouse(layer, out RaycastHit _hitInfo)) return;
            GetTypeComponent _type = _hitInfo.transform.GetComponent<GetTypeComponent>();
            if(!_type) return;
            Destroy(_type.Element.gameObject);
        }
        else
        {
            if (!SphereDeProjectMouse(layer, data.SpawnerRadius, out RaycastHit[] _hitInfo)) return;

            foreach (RaycastHit _hit in _hitInfo)
            {
                GetTypeComponent _type = _hit.transform.GetComponent<GetTypeComponent>();
                if (!_type) return;
                Destroy(_type.Element.gameObject);
            }
        }
    }



    public override void DrawAction()
    {
        if (!RayDeProjectMouse(nodeLayer, out RaycastHit _hitInfo))
            return;

        //Handles.DrawSolidDisc(_hitInfo.point, Vector3.up, data.SpawnerRadius);
        

    }       
}
