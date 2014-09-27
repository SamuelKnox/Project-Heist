using UnityEngine;
using System.Collections;

public class ChasedByGuards : MonoBehaviour
{
    void Start()
    {
        Light2D.RegisterEventListener(LightEventListenerType.OnStay, OnLightStay);
    }

    void OnDestroy()
    {
        Light2D.UnregisterEventListener(LightEventListenerType.OnStay, OnLightStay);
    }

    void OnLightStay(Light2D _lightObject, GameObject _gameObject)
    {
        if (_gameObject.GetInstanceID() == gameObject.GetInstanceID())
        {
            Transform lightSource = _lightObject.transform.parent;
            if (lightSource.tag == "Guard")
            {
                BeChasedByGuard(lightSource);
            }
        }
    }

    private void BeChasedByGuard(Transform guard)
    {
        PolyNavAgent agent = guard.GetComponent<PolyNavAgent>();
        if (agent != null)
        {
            agent.SetDestination(gameObject.transform.position);
        }
    }
}