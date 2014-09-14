using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolyNavAgent))]
[RequireComponent(typeof(Selectable))]
public class ClickableMovement : MonoBehaviour
{
    [Tooltip("Ability to Shift-Right-Click to set Waypoints enabled")]
    public bool Waypoints = true;
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

    private Queue<Vector2> waypoints = new Queue<Vector2>();

    void Update()
    {
        UpdateDestinations();
    }

    private void UpdateDestinations()
    {
        bool shouldAddDestination = Selectable.Selected && Input.GetMouseButtonDown(1);
        if (shouldAddDestination)
        {
            bool shouldClearWaypoints = !Input.GetKey(KeyCode.LeftShift) || !Waypoints;
            if (shouldClearWaypoints)
            {
                waypoints.Clear();
            }
            Vector2 destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            waypoints.Enqueue(destination);
            if (waypoints.Count == 1)
            {
                agent.SetDestination(waypoints.Peek());
            }
        }
    }

    void OnDestinationReached()
    {
        if (waypoints.Count > 0)
        {
            agent.SetDestination(waypoints.Dequeue());
        }
    }
}