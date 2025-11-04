using System;
using System.Collections.Generic;
using UnityEngine;

public class NavNode
{
    [field: SerializeField]
    public Vector3 Position { get; set; }

    [field: SerializeField]
    public List<NavNode> Successors { get; private set; } = new();

    [field: SerializeField]
    public bool IsSelected { get; set; } = false;

    [field: SerializeField]
    public bool IsOpen { get; private set; } = true;


    #region NAV
    [field: SerializeField]
    public float G { get; set; } = float.MaxValue;

    [field: SerializeField]
    public float H { get; set; } = float.MaxValue;

    public float F => G + H;

    [field: SerializeField]
    public NavNode Parent { get; set; }
    #endregion NAV

    public void DrawGizmos()
    {
        for (int i = 0; IsSelected && i < Successors.Count; i++)
            Gizmos.DrawLine(Position, Successors[i].Position);
    }
    public void AddSuccessor(NavNode _node)
    {
        Successors.Add(_node);
    }
    public void CheckForObstacle(LayerMask _obstacleLayer)
    {
        IsOpen = Physics.OverlapSphere(Position, .5f, _obstacleLayer).Length == 0;
    }
}
