using System.Collections.Generic;
using UnityEngine;

public class Waypoint
{
    public Vector3 Pos;
    public bool Sneak;

    public Waypoint(Vector3 pos_, bool sneak_)
    {
        Pos = pos_;
        Sneak = sneak_;
    }
}

[RequireComponent(typeof(PolyNavAgent))]
[RequireComponent(typeof(Selectable))]
[RequireComponent(typeof(Sneaking))]
public class ClickableMovement : MonoBehaviour
{
    [Tooltip("Ability to Shift-Right-Click to set Waypoints enabled")]
    public bool Waypoints = true;

    private Waypoint pointToAdd;

    public void AddPoint(Waypoint vec)
    {
        pointToAdd = vec;
    }

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

    private Queue<Waypoint> waypoints = new Queue<Waypoint>();

    void Update()
    {
        UpdateDestinations();
    }

    private void UpdateDestinations()
    {
        bool shouldAddDestination = Selectable.Selected && pointToAdd != null;//Input.GetMouseButtonDown(1);
        if (shouldAddDestination)
        {
            bool shouldClearWaypoints = !Input.GetKey(KeyCode.LeftShift) || !Waypoints;
            if (shouldClearWaypoints)
            {
                waypoints.Clear();
            }
            pointToAdd.Pos = Camera.main.ScreenToWorldPoint(pointToAdd.Pos);//Input.mousePosition);

            waypoints.Enqueue(pointToAdd);
            if (waypoints.Count == 1)
            {
                Sneaking sneak = GetComponent<Sneaking>();
                Waypoint next = waypoints.Peek();
                sneak.SetSneaking(next.Sneak);
                agent.SetDestination(next.Pos);
            }

            pointToAdd = null;
        }
    }

    void OnDestinationReached()
    {
        if (waypoints.Count > 0)
        {
            Sneaking sneak = GetComponent<Sneaking>();
            Waypoint next = waypoints.Dequeue();
            sneak.SetSneaking(next.Sneak);
            agent.SetDestination(next.Pos);
        }
    }
}