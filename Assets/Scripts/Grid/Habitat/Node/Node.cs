using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum EGround
{
    None,
    Grass,
    Sand,
    Water,
    limestone,
    DeepWater,
    SavanahGround,
}

public class Node : MonoBehaviour
{
    public event Action<EGround, EGround> OnGroundChange = null;
    [SerializeField] 
    EGround groundType = EGround.Grass;

    public EGround GroundType
    {
        get => groundType;
        set
        {
            UpdateGround(value);
            //OnGroundChange.Invoke(groundType, value);
            if (Habitat)
                Debug.Log("il est clean");
            Habitat.NodeGroundChange(groundType, value);
            groundType = value;
        }
    }

    [field:SerializeField] public Habitat Habitat { get; set; } = null;


    [SerializeField]
    BoxCollider myCollider = null;

    [SerializeField]
    List<Node> successors = new();

    [SerializeField]
    GroundColorList groundColorList = null;

    [SerializeField]
    MeshRenderer meshRenderer = null;

    public Vector3 Position => transform.position;

    private void Start() => UpdateGround(GroundType);


    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.cyan;
        //Gizmos.DrawSphere(Position, .2f);

        //if (!Selection.Contains(gameObject))
        //    return;

        //int _size = successors.Count;
        //Gizmos.color = Color.red;

        //for (int i = 0; i < _size; i++)
        //    Gizmos.DrawLine(Position, successors[i].Position);
    }

    public void GenerateNode(float _nodeSize)
    {
        Vector3 _vec = new Vector3(_nodeSize, .5f, _nodeSize);
        myCollider.size = _vec;
        meshRenderer.transform.localScale = _vec;
    }
    public void DestroyNode()
    {
        DestroyImmediate(gameObject);
    }
    public void AddSuccessor(Node _node)
    {
        successors.Add(_node);
    }
    public void UpdateGround(EGround _ground)
    {
        if (!meshRenderer || !groundColorList)
            return;
        CustomDictionary<EGround, Color> _colors = groundColorList.Colors;

        if (!_colors.ContainsKey(_ground))
            return;

        meshRenderer.material.color = _colors[_ground];
    }
}
