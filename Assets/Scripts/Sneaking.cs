using UnityEngine;
using System.Collections;

public class Sneaking : MonoBehaviour
{
    [Tooltip("If sneaking, Guards can hear at a reduced distance")]
    public bool Sneak = false;
    [Tooltip("This is the percent reduction of the radius a guard can hear")]
    public float Visibility = 0.5F;

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

    private void ToggleSneaking()
    {
        Sneak = !Sneak;
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