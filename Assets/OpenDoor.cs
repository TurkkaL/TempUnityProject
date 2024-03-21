using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public KeyHolder keyHolder; // replace with Singleton?
    public List<Key> neededKeys;

    private void OnTriggerEnter(Collider other)
    {
        // Is the "other" the player?
        if (other.gameObject.tag == "Player")
        {
            // Does the player hold all the keys?
            if (keyHolder.HasKeys(neededKeys))
            {
                // open door
            }
        }
    }
}

public class CollectableKey : MonoBehaviour
{
    public KeyHolder keyHolder; // replace with Singleton?
    public Key key;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            keyHolder.AddKey(key);
        }
    }
}
