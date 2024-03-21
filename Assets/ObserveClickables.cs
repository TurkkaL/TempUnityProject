using UnityEngine;

public class ObserveClickables : MonoBehaviour
{
    public float interactDistance = 5f;

    public GameObject uiElement;

    RaycastHit hit;
    Clickable lastClickable;

    private void Awake()
    {
        if (uiElement != null) uiElement.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        // Every update, see if you are looking at a <Clickable>

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactDistance))
        {
            //Debug.Log("You are looking at " + hit.transform.name);

            if (hit.transform.gameObject.TryGetComponent<Clickable>(out Clickable clickable))
            {
                //Debug.Log("You're looking at a clickable target");
                LookingClickables(clickable);

                // Check if clickable was clicked
                if (Input.GetMouseButtonDown(0))
                {
                    clickable.Click();
                }
            }
            else
            {
                // You're not looking at a clickable target
                LookingClickables(null);
            }
        }
        else
        {
            LookingClickables(null);
        }
    }

    void LookingClickables(Clickable newClickable)
    {
        if (lastClickable != newClickable)
        {
            // Toggle uiElement
            if (uiElement != null)
            {
                if (newClickable == null) uiElement.SetActive(false);
                else uiElement.SetActive(true);
            }

            // Look newClickable
            newClickable?.Look();

            // UnLook lastClickable
            lastClickable?.UnLook();

            lastClickable = newClickable;
        }
    }
}
