using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnAction", menuName = "CreationWheel/Action/Create Spawn action")]
public class SpawnAction : CreationAction
{
    [field: SerializeField, Header("Spawn")] public Element SpawnElement { get; private set; } = null;
    [SerializeField] List<Mesh> meshList = new();
    [SerializeField] float offset = 0;
    [SerializeField] float rotateOffset = 0;
    [SerializeField] float size = 0;


    public override void Use()
    {
        if (!SpawnElement || !RayDeProjectMouse(layer, out RaycastHit _hitInfo)) return;

        if (meshList.Count != 0)
            SpawnElement.GetComponent<MeshFilter>().mesh = meshList[Random.Range(0, meshList.Count)];
                
        GameLogic.Instance.Spawner.Spawn(_hitInfo.point + new Vector3(0, offset, 0), new Vector3(rotateOffset, 0, 0), size);
    }


    public override void Init()
    {
        SpawnerData _data = Instantiate(data);
        _data.Item = SpawnElement;
        GameLogic.Instance.Spawner.SetSpawnSettings(_data);
    }
}
