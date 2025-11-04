using UnityEngine;

public class MathUtils : MonoBehaviour
{
    public static bool IsAtLocation(Vector3 _a, Vector3 _b, float _range)
    {
        return Vector3.Distance(_a, _b) <= _range;
    }

    public static bool IsInRange(float _a, float _b, float _range)
    {
        return Mathf.Abs(_b - _a) <= _range;
    }
}
