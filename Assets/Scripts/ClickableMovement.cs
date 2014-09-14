using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    private List<Vector2> waypoints = new List<Vector2>();

    void Update()
    {
        UpdateDestinations();
    }

    private void UpdateDestinations()
    {
        bool shouldAddDestination = Selectable.Selected && Input.GetMouseButtonDown(1);
        if (shouldAddDestination)
        {
            bool shouldClearWaypoints = !Input.GetKey(KeyCode.LeftShift);
            if (shouldClearWaypoints)
            {
                waypoints.Clear();
            }
            Vector2 newDestination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            waypoints.Add(newDestination);
            if (waypoints.Count == 1)
            {
                agent.SetDestination(waypoints[0]);
            }
        }
    }

    void OnDestinationReached()
    {
        waypoints.RemoveAt(0);
        if (waypoints.Count > 0)
        {
            agent.SetDestination(waypoints[0]);
        }
    }
}