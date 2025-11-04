using UnityEngine;

public class DetectionComponent : MonoBehaviour
{
    [field: SerializeField] public int Radius { get; private set; } = 5;
    [SerializeField] public LayerMask detectionLayer;
    //[field:SerializeField] public List<Habitat> Habitats { get; set; }
    [field: SerializeField] public CustomDictionary<Habitat, float> Habitats { get; set; } = new();


    private void Start()
    {
        InvokeRepeating(nameof(DetectHabitat), 0, 3);
    }

    private void DetectHabitat()
    {
        Habitats.Clear();
        Collider[] _colliders = Physics.OverlapSphere(transform.position, Radius, detectionLayer);
        for (int i = 0; i < _colliders.Length; i++)
        {
            
            Habitat _habitat = _colliders[i].GetComponent<Habitat>();
            if (!Habitats.ContainsKey(_habitat))
            {
                Habitats.Set(_habitat, 1000);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
