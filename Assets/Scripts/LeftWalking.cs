using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PolyNavAgent))]
public class LeftWalking : MonoBehaviour
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
        agent.SetDestination(new Vector2(-9, -1));
    }

    void OnApplicationQuit()
    {
        applicationClosing = true;
    }
    void OnDestinationReached()
    {
        Destroy(gameObject.GetComponent<LeftWalking>());
    }
    void OnDestroy()
    {
        if (applicationClosing)
        {
            return;
        }

        gameObject.AddComponent<RightWalking>();
    }
}
