using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PolyNavAgent))]
public class RightWalking : MonoBehaviour
{


    public PolyNavAgent agent
    {
        get
        {
            return GetComponent<PolyNavAgent>();
        }
    }
    private bool applicationClosing;
    // Use this for initialization
    void Start()
    {
        agent.SetDestination(new Vector2(9, -1));
    }
    void OnApplicationQuit()
    {
        applicationClosing = true;
    }

    void OnDestinationReached()
    {
        Destroy(this);
    }
    void OnDestroy()
    {
        if (applicationClosing)
        {
            return;
        }
        gameObject.AddComponent<LeftWalking>();
    }
}
