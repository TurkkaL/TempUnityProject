using UnityEngine;
using UnityEngine.Events;

public class Clickable : MonoBehaviour
{
    public UnityEvent OnClick;
    public UnityEvent OnLook;
    public UnityEvent OnUnLook;

    [Space(8)]
    [Header("Material")]
    public Material highlightedMaterial;
    Material normalMaterial;
    MeshRenderer mr;

    void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        normalMaterial = mr.material;
    }


    public void Click()
    {
        //  What happens when this GameObject is looked at AND clicked
        OnClick?.Invoke();
    }

    public void Look()
    {
        // What happens when this GameObject is looked at
        OnLook?.Invoke();
        //Debug.Log(gameObject.name + " is looked at");
        if (highlightedMaterial != null) mr.material = highlightedMaterial;

    }
    public void UnLook()
    {
        // What happens when this GameObject is no longer looked at
        OnUnLook?.Invoke();
        //Debug.Log(gameObject.name + " is NO LONGER looked at");
        if (highlightedMaterial != null) mr.material = normalMaterial;
    }
}
