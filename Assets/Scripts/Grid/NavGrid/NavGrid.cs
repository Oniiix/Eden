using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class NavGrid : MonoBehaviour
{
    [SerializeField]
    bool useDebug = true;

    [SerializeField]
    MyGrid referenceGrid = null;

    [field: SerializeField]
    public List<NavNode> Nodes { get; private set; } = new();

    [SerializeField]
    LayerMask obstacleLayer;

    int width = 0;
    int length = 0;
    float gap = 0;
    int habitatWidth = 0;
    int habitatLength = 0;
    float nodeSize = 0;

    public bool NodesIsEmpty => Nodes.Count == 0;

    private void OnDrawGizmos()
    {
        if (NodesIsEmpty || !useDebug)
            return;

        int _size = Nodes.Count;

        for (int i = 0; i < _size; i++)
            Gizmos.DrawWireCube(Nodes[i].Position, new Vector3(.2f, .2f, .2f));

        for (int i = 0; i < Nodes.Count; i++)
            Nodes[i].DrawGizmos();
    }

    public void Generate()
    {
        if (!referenceGrid)
        {
            Debug.Log("[NavGrid] referenceGrid is null");
            return;
        }

        width = referenceGrid.Width;
        length = referenceGrid.Length;
        gap = referenceGrid.Gap;
        habitatWidth = referenceGrid.HabitatPreset.Width;
        habitatLength = referenceGrid.HabitatPreset.Length;
        nodeSize = referenceGrid.HabitatPreset.nodeSize;
        Nodes.Clear();

        Vector3 _position = Vector3.zero;
        float _habitatSizeWidth = habitatWidth * nodeSize;
        float _habitatSizeLength = habitatLength * nodeSize;

        for (int l = 0; l < length; l++)
        {
            for (int hl = 0; hl < habitatLength; hl++)
            {
                for (int w = 0; w < width; w++)
                {
                    for (int hw = 0; hw < habitatWidth; hw++)
                    {
                        _position = referenceGrid.transform.position + (new Vector3(_habitatSizeWidth / 2 + w * _habitatSizeWidth, 0, _habitatSizeLength / 2 + l * _habitatSizeLength))
                            + new Vector3(-habitatWidth * (nodeSize / 2), 0, -habitatLength * (nodeSize / 2)) + new Vector3(nodeSize / 2 + hl * nodeSize, 0, nodeSize / 2 + hw * nodeSize); ;
                        NavNode _node = new NavNode() { Position = _position };
                        _node.CheckForObstacle(obstacleLayer);
                        Nodes.Add(_node);
                    }
                }
            }
        }

        SetSuccessors();
    }
    void SetSuccessors()
    {
        if (NodesIsEmpty)
            return;

        int _size = Nodes.Count;
        int _width = width * habitatWidth;
        int _length = length * habitatLength;

        for (int i = 0; i < _size; i++)
        {
            bool _canRight = i % _width != _width - 1,
            _canUp = i >= _width,
            _canDown = i < (_width * _length) - _width,
            _canLeft = i % _width != 0;

            if (_canRight)
                Nodes[i].AddSuccessor(Nodes[i + 1]);

            if (_canUp)
            {
                Nodes[i].AddSuccessor(Nodes[i - _width]);

                if (_canRight)
                    Nodes[i].AddSuccessor(Nodes[i + 1 - _width]);

                if (_canLeft)
                    Nodes[i].AddSuccessor(Nodes[i - 1 - _width]);
            }

            if (_canDown)
            {
                Nodes[i].AddSuccessor(Nodes[i + _width]);

                if (_canRight)
                    Nodes[i].AddSuccessor(Nodes[i + 1 + _width]);

                if (_canLeft)
                    Nodes[i].AddSuccessor(Nodes[i - 1 + _width]);
            }

            if (_canLeft)
                Nodes[i].AddSuccessor(Nodes[i - 1]);
        }
    }
}
