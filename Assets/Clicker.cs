using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public float clickDistance = 5f;

    // Update is called once per frame
    void Update()
    {
        // Every update, see if mouse was clicked (left click = 0)
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, clickDistance))
            {
                //Debug.Log("You clicked the " + hit.transform.name);

                if (hit.transform.gameObject.TryGetComponent<Clickable>(out Clickable clickable))
                {
                    //Debug.Log("--> It's a clickable target!");

                    clickable.Click();
                }
            }
        }
    }
}
