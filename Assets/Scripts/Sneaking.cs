using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PolyNavAgent))]
[RequireComponent(typeof(Light2D))]
public class Sneaking : MonoBehaviour
{
    [Tooltip("If sneaking, Guards can hear at a reduced distance")]
    public bool Sneak = false;
    [Tooltip("This is the percent reduction of the radius a guard can hear")]
    public float Visibility = 0.5F;

    [Tooltip("This is the percent reduction in speed while sneaking")]
    public float SpeedReduction = 0.5F;

    private GameObject[] guards;

    void Start()
    {
        guards = GameObject.FindGameObjectsWithTag("Guard");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToggleSneaking();
        }
    }

    public void SetSneaking(bool newSneak)
    {
        if (Sneak ^ newSneak)
        {
            ToggleSneaking();
        }
    }

    public void ToggleSneaking()
    {
        Sneak = !Sneak;

        PolyNavAgent mov = gameObject.GetComponent<PolyNavAgent>();
        
        if (Sneak)
        {
            mov.maxSpeed *= SpeedReduction;
        }
        else
        {
            mov.maxSpeed /= SpeedReduction;
        }

        foreach (GameObject guard in guards)
        {
            Transform hearingTransform = guard.transform.Find("Hearing");
            Light2D hearing = hearingTransform.GetComponent<Light2D>();
            if (Sneak)
            {
                hearing.LightRadius *= Visibility;
            }
            else
            {
                hearing.LightRadius /= Visibility;
            }
        }
    }
}