using UnityEngine;

public class CameraComponent : MonoBehaviour
{
    [SerializeField] Transform target;
    public Transform Target { get { return target; } set { target = value; } }

    void Update()
    {
        if(!target) return;
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(target.position-transform.position),Time.deltaTime);
    }


}
