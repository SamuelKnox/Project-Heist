using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PolyNavAgent))]
[RequireComponent(typeof(Selectable))]
public class ClickableMovement : MonoBehaviour
{
    public PolyNavAgent agent
    {
        get
        {
            return GetComponent<PolyNavAgent>();
        }
    }
    public Selectable Selectable
    {
        get
        {
            return GetComponent<Selectable>();
        }
    }

    void Update()
    {
        UpdateDestination();
    }

    private void UpdateDestination()
    {
        bool shouldChangeDestination = Selectable.Selected && Input.GetMouseButtonDown(1);
        if (shouldChangeDestination)
        {
            Vector2 newDestination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            agent.SetDestination(newDestination);
        }
    }
}