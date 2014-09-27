using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PolyNavAgent))]
public class Patrol : MonoBehaviour
{
    [Tooltip("These are the positions, in order, where this unit will patrol")]
    public List<Vector2> WayPoints = new List<Vector2>();

    public PolyNavAgent agent
    {
        get
        {
            return GetComponent<PolyNavAgent>();
        }
    }

    private int indexInWaypoints;

    void Start()
    {
        agent.SetDestination(WayPoints[indexInWaypoints]);
    }

    void Update()
    {
        if (Debug.isDebugBuild)
        {
            DrawDebugLinesBetweenWaypoints();
        }
    }

    private void DrawDebugLinesBetweenWaypoints()
    {
        for (int i = 0; i < WayPoints.Count - 1; i++)
        {
            Debug.DrawLine(WayPoints[i], WayPoints[i + 1], Color.red);
        }
        Debug.DrawLine(WayPoints[WayPoints.Count - 1], WayPoints[0], Color.red);
    }

    void OnDestinationReached()
    {
        indexInWaypoints = (indexInWaypoints + 1) % WayPoints.Count;
        agent.SetDestination(WayPoints[indexInWaypoints]);
    }
}
