using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FiniteState))]
public class FiniteStateMachine : MonoBehaviour
{
    [Tooltip("The current state of the FSM")]
    public FiniteState FiniteState;

    // Use this for initialization
    void Start()
    {
        if (FiniteState != null)
        {
            FiniteState.transform.parent = transform;
        }
    }

    private void ChangeState(FiniteState finiteState)
    {
        if (finiteState == null)
        {
            return;
        }
        FiniteState = finiteState;
        FiniteState.transform.parent = transform;
    }
}
