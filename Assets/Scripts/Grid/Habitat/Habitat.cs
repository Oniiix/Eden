using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum EHabitatType
{
    None,
    Forest,
    Desert,
    Mountain,
    Plain,
    Ocean,
    DeepOcean,
    Beach,
    Savanah,
}

[RequireComponent(typeof(HabitatSystem))]
public class Habitat : MonoBehaviour
{
    [SerializeField]
    BoxCollider myCollider = null;

    [field: SerializeField]
    public float nodeSize = 1;

    [field:SerializeField]
    public EHabitatType Type { get; set; } = EHabitatType.None;

    [field: SerializeField] 
    public CustomDictionary<EGround, int> Grounds { get; set; } = new();

    [field: SerializeField] 
    public List<Element> Elements { get; set; } = new();
     List<Fauna> meatElements = new();
     List<Flora> plantElements = new();

    [field: SerializeField, Min(2)]
    public int Length { get; private set; } = 3;

    [field: SerializeField, Min(2)]
    public int Width { get; private set; } = 4;

    [field: SerializeField]
    public List<Node> Nodes { get; private set; } = new();

    [SerializeField]
    Node nodePreset = null;

    [field: SerializeField]
    public List<Habitat> Successors { get; private set; } = new();

    //public int Cost { get; set; } = 1000;

    public bool NodesIsEmpty => Nodes.Count == 0; 

    public void DestroyHabitat()
    {
        if (!NodesIsEmpty)
        {
            int _size = Nodes.Count;

            for (int i = 0; i < _size; i++)
                Nodes[i].DestroyNode();

            Nodes.Clear();
        }

        DestroyImmediate(gameObject);
    }
    public void GenerateHabitat()
    {
        if (!nodePreset)
        {
            Debug.Log("[Habitat] nodePreset is null");
            return;
        }

        ClearHabitat(); 
        Vector3 _position = Vector3.zero;
        Node _node = null;
        int _index = 1;

        for (int l = 0; l < Length; l++)
        {
            for (int w = 0; w < Width; w++)
            {
                _position = transform.position + new Vector3(-Width * (nodeSize/2), 0, -Length * (nodeSize/2)) + new Vector3( nodeSize/2 + l * nodeSize,0, nodeSize / 2 + w * nodeSize);
                _node = Instantiate(nodePreset);
                _node.transform.position = _position;
                _node.transform.SetParent(transform);
                _node.name = $"{name}_Node{_index}";
                _node.GenerateNode(nodeSize);
                //_node.OnGroundChange += NodeGroundChange;
                _node.Habitat = this;
                NodeGroundChange(EGround.None, _node.GroundType);
                Nodes.Add(_node);
                _index += 1;
            }
        }

        UpdateCollider(nodeSize);
    }

    void ClearHabitat()
    {
        if (!NodesIsEmpty)
            return;

        int _size = Nodes.Count;

        for (int i = 0; i < _size; i++)
            Nodes[i].DestroyNode();

        Nodes.Clear();
    }

    //public void ResetCost()
    //{
    //    Cost = 1000;
    //}
    void UpdateCollider(float _nodeSize)
    {
        myCollider.size = new Vector3((Width * _nodeSize), 1, (Length *_nodeSize));
    }


    public void NodeGroundChange(EGround _prev, EGround _new)
    {
        Debug.Log("fdhgchfh");
        if (Grounds.ContainsKey(_prev))
            Grounds.Set(_prev, Grounds[_prev] - 1);
        if (Grounds.ContainsKey(_new))
            Grounds.Set(_new, Grounds[_new] + 1);
        else
            Grounds.Set(_new, 1);
    }


    private void OnTriggerEnter(Collider other)
    {
        Element _element = other.GetComponent<Element>();
        if (_element)
            Elements.Add(_element);
    }
    private void OnTriggerExit(Collider other)
    { 
        Element _element = other.GetComponent<Element>();
        if (_element && Elements.Contains(_element))
            Elements.Remove(_element);
    }

    public List<Fauna> GetMeatElement()
    {
        meatElements.Clear();
        foreach (Fauna _element in Elements)
        {
            if (!_element) continue;
            FaunaCharacteristic _chara = (FaunaCharacteristic)_element.CharacteristicComponent.Characteristic;
            if (_chara.ElementType == TTypeEnum.Meat)
            {
                meatElements.Add(_element);
            }
        }
        return meatElements;
    }
    public List<Flora> GetPlantElement()
    {
        plantElements.Clear();
        foreach (Flora _element in Elements)
        {
            if (!_element) continue;
            FloraCharacteristic _chara = (FloraCharacteristic)_element.CharacteristicComponent.Characteristic;
            if (_chara.ElementType == TTypeEnum.Plant)
            {
                plantElements.Add(_element);
            }
        }
        return plantElements;
    }
    public void AddSuccessor(Habitat _habitat)
    {
        Successors.Add(_habitat);
    }
}
