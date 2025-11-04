using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class CustomDictionary<TKey, TValue>
{
    [SerializeField] List<KeyValue<TKey, TValue>> pairs = new();

    public int Count => pairs.Count;


    public KeyValue<TKey, TValue> this[int _index] => pairs[_index];
    public TValue this[TKey _key] => Get(_key);

    public TValue Get(TKey _key)
    {
        for (int i = 0; i < pairs.Count; i++)
        {
            if (pairs[i].Key.Equals(_key))
                return pairs[i].Value;
        }
        return default;
    }
    public void Set(TKey _key, TValue _newValue)
    {
        for (int i = 0; i < pairs.Count; i++)
        {
            if (pairs[i].Key.Equals(_key))
            {
                pairs[i].SetValue(_newValue);
                return;
            }
        }
        pairs.Add(new KeyValue<TKey, TValue>(_key, _newValue));
    }

    public bool ContainsKey(TKey _key)
    {
        for (int i = 0; i < pairs.Count; i++)
        {
            if (pairs[i].Key.Equals(_key))
                return true;
        }
        return false;
    }

    public void Clear() => pairs.Clear();

    public List<TKey> GetAllKeys()
    {
        List<TKey> keys = new();
        foreach (KeyValue<TKey, TValue> _item in pairs)
            keys.Add(_item.Key);
        return keys;
    }
}


[Serializable]
public class KeyValue<TKey, TValue>
{
    public KeyValue(TKey _key, TValue _value)
    {
        key = _key;
        myValue = _value;
    }

    [SerializeField] TKey key;
    [SerializeField] TValue myValue;
    public TKey Key { get => key; set => key = value; }
    public TValue Value { get => myValue; set => myValue = value; }


    public void SetValue(TValue _value)
    {
        Debug.Log(_value);
        Value = _value;
    }
}