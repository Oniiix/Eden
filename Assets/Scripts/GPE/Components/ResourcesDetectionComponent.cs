using System.Collections.Generic;
using UnityEngine;

public class ResourcesDetectionComponent : MonoBehaviour
{
    [SerializeField] float radius = 40;
    [SerializeField] LayerMask elementMask;
    [SerializeField] LayerMask waterMask;
    public List<Element> elements = new List<Element>();
    public List<Node> water = new List<Node>();

    public List<Element> Elements => elements;
    public List<Node> Water => water;
    public bool DetectElements()
    {
        elements.Clear();
        Collider[] _colliders = Physics.OverlapSphere(transform.position, radius, elementMask);
        for (int i = 0; i < _colliders.Length; i++)
        {
            Element _element = _colliders[i].GetComponent<Element>();
            if (!elements.Contains(_element) && _colliders[i].name != name)
            {
                Debug.Log(_element);
                elements.Add(_element);
            }
        }
        if(elements.Count > 0)return true;
        else return false;
    }

    public bool DetectWater()
    {
        water.Clear();
        Collider[] _colliders = Physics.OverlapSphere(transform.position, radius, waterMask);
        for (int i = 0; i < _colliders.Length; i++)
        {
            Node _water = _colliders[i].GetComponent<Node>();
            if (!water.Contains(_water))
            {
                water.Add(_water);
            }
        }
        if (water.Count > 0) return true;
        else return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
