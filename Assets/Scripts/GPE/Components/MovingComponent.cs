using UnityEngine;

public class MovingComponent : MonoBehaviour
{
    [SerializeField,Range(1,10)] float speed = 1;
    [SerializeField,Range(1,10)] float rotateSpeed = 5;
    [SerializeField, HideInInspector] Vector3 destination = Vector3.zero;
    MyGrid navigationZone = null;
    public bool IsMoving { get; set; } = false;
    public bool ArrivedToDestination { get; set; } = false;

    void Update()
    {
        if (!IsMoving) return;
        GoToDestination();
    }

    void GoToDestination()
    {
       transform.position =  Vector3.MoveTowards(transform.position,destination, Time.deltaTime * speed * 10);
       transform.rotation =  Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(destination - transform.position), Time.deltaTime * rotateSpeed * 50);
       if(ReachedDestination())
            ArrivedToDestination = true;
    }

    public void SetDestination(Vector3 _destination)
    {
        destination = _destination;
    }

    bool ReachedDestination()
    {
        if(Vector3.Distance(transform.position,destination) > 1)
            return false;
        return true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(destination, 5);
    }
}
