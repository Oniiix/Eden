using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class SpawnerTool : MonoBehaviour
{
    //[SerializeField, Min(.1f), HideInInspector]
    //float spawnerRadius = 1;

    //[SerializeField, HideInInspector]
    //ESpawnerToolDensity densityType = ESpawnerToolDensity.Single;

    //[SerializeField, HideInInspector]
    //int density = 10;

    [field: SerializeField] public SpawnerData data { get; set; } = null;

    //[SerializeField, HideInInspector]
    //bool useSingleItem = true;
    
    //[SerializeField, HideInInspector]
    //Element item = null;
    
    //[SerializeField, HideInInspector]
    //List<Element> items = new();

    [SerializeField]
    List<Element> tempItemsForDestroy = new();

    [SerializeField]
    LayerMask eraseLayer;
    [SerializeField] Vector3 canSpawnRange = Vector3.zero;

    private void OnDrawGizmos()
    {
        float _part, _x, _y;

        List<Vector3> _points = new();

        if (!data)
            return;
        //remplacer le transform.position par la position en world de la souris
        for (int i = 0; i < 360 + 1; i++)
        {
            _part = ((float)i / 360) * 360 * Mathf.Deg2Rad;
            _x = Mathf.Cos(_part) * data.SpawnerRadius;
            _y = Mathf.Sin(_part) * data.SpawnerRadius;
            Vector3 _point = transform.position + new Vector3(_x, 0, _y);
            _points.Add(_point);
        }

        Gizmos.DrawLineStrip(_points.ToArray(), false);
    }

    public void EraseTest()
    {
        Erase(typeof(Rock), transform.position);
    }

    public void Spawn(Vector3 _pos, Vector3 _rotate, float _size)
    {
        Element _item = GetItem();

        if (!_item)
            return;
        switch (data.DensityType)
        {
            case ESpawnerToolDensity.Single:
                {
                    SpawnSingle(_item, _pos, _rotate, _size);
                    break;
                }
            case ESpawnerToolDensity.Multiple:
                {
                    SpawnMultiple(_item, _pos, _rotate, _size);
                    break;
                }
        }
    }
    public void Clear()
    {
        for (int i = 0; i < tempItemsForDestroy.Count; i++)
        {
            if (!tempItemsForDestroy[i])
                continue;

            DestroyImmediate(tempItemsForDestroy[i]);
        }

        tempItemsForDestroy.Clear();
    }
    public void Erase(Type _type, Vector3 _origin)
    { 
        RaycastHit[] _hits = Physics.SphereCastAll(_origin, data.SpawnerRadius, -Vector3.up, 100, eraseLayer);
        int _size = _hits.Length;

        for (int i = 0; i < _size; i++)
        {
            if (_hits[i].collider.gameObject.GetComponent(_type))
                DestroyImmediate(_hits[i].collider.gameObject);
        }
    }

    void SpawnSingle(Element _item, Vector3 _origin, Vector3 _rotate, float _size)
    {
        bool _hit = Physics.Raycast(_origin + Vector3.up, -Vector3.up, out RaycastHit _hitInfo, 100);
        if (_hit)
        {
            Collider[] colliders = Physics.OverlapBox(_hitInfo.point, new Vector3(_size, _size, _size), Quaternion.identity, LayerMask.GetMask("Elements", "Ressources"));
            if (colliders.Length != 0)
            {
                foreach(Collider collider in colliders)
                {
                    if (!collider.GetComponent<Element>().can_spawn_on)
                        return;
                    else if (_item.can_spawn_on)
                        Destroy(collider.gameObject);
                }
            }
            Element _go = Instantiate(_item, _hitInfo.point, Quaternion.identity);
            _go.transform.eulerAngles = _rotate + new Vector3(0, Random.Range(0, 360), 0);
            tempItemsForDestroy.Add(_go);
        }
    }
    void SpawnMultiple(Element _item, Vector3 _origin, Vector3 _rotate, float _size)
    {
        bool _hit = Physics.Raycast(_origin + Vector3.up, -Vector3.up, out RaycastHit _hitInfo, 100);
        float _part, _x, _y;

        for (int i = 0; i < data.Density * data.SpawnerRadius; i++)
        {
            _part = (float)(i / (data.Density * data.SpawnerRadius)) * 360 * Mathf.Deg2Rad;
            _x = Mathf.Cos(_part) * Random.Range(data.SpawnerRadius / 4.0f, data.SpawnerRadius);
            _y = Mathf.Sin(_part) * Random.Range(0, data.SpawnerRadius);
            Vector3 _point = _hitInfo.point + new Vector3(_x, 0, _y);
            bool canSpawn = true;
            Collider[] colliders = Physics.OverlapBox(_point, new Vector3(_size, _size, _size), Quaternion.identity, LayerMask.GetMask("Elements", "Ressources"));
            foreach(Collider collider in colliders)
            {
                if (!collider.GetComponent<Element>().can_spawn_on)
                {
                    canSpawn = false;
                    continue;
                }
                else if (_item.can_spawn_on)
                    Destroy(collider.gameObject);
            }
            if (!canSpawn) continue;
            Element _go = Instantiate(_item, _point, Quaternion.identity);
            _go.transform.eulerAngles = _rotate + new Vector3(0, Random.Range(0, 360), 0);
            tempItemsForDestroy.Add(_go);
        }
    }
    Element GetItem()
    {
        return data.UseSingleItem ? data.Item : data.Items[Random.Range(0, data.Items.Count)];
    }

    public void SetSpawnSettings(SpawnerData _data)
    {
        data = _data;
    }
}









/*
 * 
 * public class SpawnerTool : MonoBehaviour
{
    [SerializeField, Min(.1f), HideInInspector]
    float spawnerRadius = 1;

    [SerializeField, HideInInspector]
    ESpawnerToolDensity densityType = ESpawnerToolDensity.Single;

    [SerializeField, HideInInspector]
    int density = 10;

    [SerializeField, HideInInspector]
    SpawnerData data = null;

    [SerializeField, HideInInspector]
    bool useSingleItem = true;

    [SerializeField, HideInInspector]
    GameObject item = null;

    [SerializeField, HideInInspector]
    List<GameObject> items = new();

    [SerializeField]
    List<GameObject> tempItemsForDestroy = new();

    [SerializeField]
    LayerMask eraseLayer;

    private void OnDrawGizmos()
    {
        float _part, _x, _y;

        List<Vector3> _points = new();

        //remplacer le transform.position par la position en world de la souris
        for (int i = 0; i < 360 + 1; i++)
        {
            _part = ((float)i / 360) * 360 * Mathf.Deg2Rad;
            _x = Mathf.Cos(_part) * spawnerRadius;
            _y = Mathf.Sin(_part) * spawnerRadius;
            Vector3 _point = transform.position + new Vector3(_x, 0, _y);
            _points.Add(_point);
        }

        Gizmos.DrawLineStrip(_points.ToArray(), false);
    }

    public void EraseTest()
    {
        Erase(typeof(Rock), transform.position);
    }

    public void Spawn()
    {
        GameObject _item = GetItem();

        if (!_item)
            return;

        //remplacer le transform.position par la position en world de la souris
        switch (densityType)
        {
            case ESpawnerToolDensity.Single:
                {
                    SpawnSingle(_item, transform.position);
                    break;
                }
            case ESpawnerToolDensity.Multiple:
                {
                    SpawnMultiple(_item, transform.position); 
                    break;
                }
        }
    }
    public void Clear()
    {
        for (int i = 0; i < tempItemsForDestroy.Count; i++)
        {
            if (!tempItemsForDestroy[i])
                continue;

            DestroyImmediate(tempItemsForDestroy[i]);
        }

        tempItemsForDestroy.Clear();
    }
    public void Erase(Type _type, Vector3 _origin)
    { 
        RaycastHit[] _hits = Physics.SphereCastAll(_origin, spawnerRadius, -Vector3.up, 100, eraseLayer);
        int _size = _hits.Length;

        for (int i = 0; i < _size; i++)
        {
            if (_hits[i].collider.gameObject.GetComponent(_type))
                DestroyImmediate(_hits[i].collider.gameObject);
        }
    }

    void SpawnSingle(GameObject _item, Vector3 _origin)
    {
        bool _hit = Physics.Raycast(_origin, -Vector3.up, out RaycastHit _hitInfo, 100);

        if (_hit)
        {
            GameObject _go = Instantiate(_item, _hitInfo.point, Quaternion.identity);
            tempItemsForDestroy.Add(_go);
        }
    }
    void SpawnMultiple(GameObject _item, Vector3 _origin)
    {
        bool _hit = Physics.Raycast(_origin, -Vector3.up, out RaycastHit _hitInfo, 100);

        if (_hit)
        {
            float _part, _x, _y;

            for (int i = 0; i < density * spawnerRadius; i++)
            {
                _part = (float)(i / (density * spawnerRadius)) * 360 * Mathf.Deg2Rad;
                _x = Mathf.Cos(_part) * Random.Range(spawnerRadius / 4.0f, spawnerRadius);
                _y = Mathf.Sin(_part) * Random.Range(0, spawnerRadius);
                Vector3 _point = _hitInfo.point + new Vector3(_x, 0, _y);

                GameObject _go = Instantiate(_item, _point, Quaternion.identity);
                tempItemsForDestroy.Add(_go);
            }
        }
    }
    GameObject GetItem()
    {
        return useSingleItem ? item : items[Random.Range(0, items.Count)];
    }
}public class SpawnerTool : MonoBehaviour
{
    [SerializeField, Min(.1f), HideInInspector]
    float spawnerRadius = 1;

    [SerializeField, HideInInspector]
    ESpawnerToolDensity densityType = ESpawnerToolDensity.Single;

    [SerializeField, HideInInspector]
    int density = 10;

    [SerializeField, HideInInspector]
    SpawnerData data = null;

    [SerializeField, HideInInspector]
    bool useSingleItem = true;

    [SerializeField, HideInInspector]
    GameObject item = null;

    [SerializeField, HideInInspector]
    List<GameObject> items = new();

    [SerializeField]
    List<GameObject> tempItemsForDestroy = new();

    [SerializeField]
    LayerMask eraseLayer;

    private void OnDrawGizmos()
    {
        float _part, _x, _y;

        List<Vector3> _points = new();

        //remplacer le transform.position par la position en world de la souris
        for (int i = 0; i < 360 + 1; i++)
        {
            _part = ((float)i / 360) * 360 * Mathf.Deg2Rad;
            _x = Mathf.Cos(_part) * spawnerRadius;
            _y = Mathf.Sin(_part) * spawnerRadius;
            Vector3 _point = transform.position + new Vector3(_x, 0, _y);
            _points.Add(_point);
        }

        Gizmos.DrawLineStrip(_points.ToArray(), false);
    }

    public void EraseTest()
    {
        Erase(typeof(Rock), transform.position);
    }

    public void Spawn()
    {
        GameObject _item = GetItem();

        if (!_item)
            return;

        //remplacer le transform.position par la position en world de la souris
        switch (densityType)
        {
            case ESpawnerToolDensity.Single:
                {
                    SpawnSingle(_item, transform.position);
                    break;
                }
            case ESpawnerToolDensity.Multiple:
                {
                    SpawnMultiple(_item, transform.position); 
                    break;
                }
        }
    }
    public void Clear()
    {
        for (int i = 0; i < tempItemsForDestroy.Count; i++)
        {
            if (!tempItemsForDestroy[i])
                continue;

            DestroyImmediate(tempItemsForDestroy[i]);
        }

        tempItemsForDestroy.Clear();
    }
    public void Erase(Type _type, Vector3 _origin)
    { 
        RaycastHit[] _hits = Physics.SphereCastAll(_origin, spawnerRadius, -Vector3.up, 100, eraseLayer);
        int _size = _hits.Length;

        for (int i = 0; i < _size; i++)
        {
            if (_hits[i].collider.gameObject.GetComponent(_type))
                DestroyImmediate(_hits[i].collider.gameObject);
        }
    }

    void SpawnSingle(GameObject _item, Vector3 _origin)
    {
        bool _hit = Physics.Raycast(_origin, -Vector3.up, out RaycastHit _hitInfo, 100);

        if (_hit)
        {
            GameObject _go = Instantiate(_item, _hitInfo.point, Quaternion.identity);
            tempItemsForDestroy.Add(_go);
        }
    }
    void SpawnMultiple(GameObject _item, Vector3 _origin)
    {
        bool _hit = Physics.Raycast(_origin, -Vector3.up, out RaycastHit _hitInfo, 100);

        if (_hit)
        {
            float _part, _x, _y;

            for (int i = 0; i < density * spawnerRadius; i++)
            {
                _part = (float)(i / (density * spawnerRadius)) * 360 * Mathf.Deg2Rad;
                _x = Mathf.Cos(_part) * Random.Range(spawnerRadius / 4.0f, spawnerRadius);
                _y = Mathf.Sin(_part) * Random.Range(0, spawnerRadius);
                Vector3 _point = _hitInfo.point + new Vector3(_x, 0, _y);

                GameObject _go = Instantiate(_item, _point, Quaternion.identity);
                tempItemsForDestroy.Add(_go);
            }
        }
    }
    GameObject GetItem()
    {
        return useSingleItem ? item : items[Random.Range(0, items.Count)];
    }
}
*/