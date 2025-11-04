using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    [SerializeField]
    Element item = null;

    [SerializeField]
    int range = 100;

    [SerializeField]
    int spawnNumber = 20;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(range, 1, range));
    }
    private void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        if (!item)
            return;

        bool _hit = Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hitInfo, 100);

        if (_hit)
        {
            Vector3 _position = new Vector3(0, hitInfo.transform.position.y, 0);
           
            for (int i = 0; i < spawnNumber; i++)
                Instantiate(item, _position + new Vector3(Random.Range(0, range), 0, Random.Range(0, range)), Quaternion.identity);
        }
    }
}