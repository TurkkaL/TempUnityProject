using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Key
{
    Red, Blue, Green
}

public class KeyHolder : MonoBehaviour
{
    List<Key> keys;

    //public bool HasKey(Key key)
    //{
    //    if (keys.Contains(key)) return true;
    //    else return false;
    //}

    public bool HasKeys(List<Key> neededKeys)
    {
        foreach (var key in neededKeys)
        {
            if (keys.Contains(key) == false)
            {
                return false;
            }
        }
        return true;
    }

    public void AddKey(Key newKey)
    {
        if (keys.Contains(newKey) == false)
        {
            // Key is picked up, remove from world?

            keys.Add(newKey);
        }
    }
}
