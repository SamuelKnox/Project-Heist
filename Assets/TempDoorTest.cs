using UnityEngine;
using System.Collections;

public class TempDoorTest : MonoBehaviour
{

    public Vector3 DoorRotation;

    // Use this for initialization
    void Start()
    {

        Invoke("RotateOverTimeCall", 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void RotateOverTimeCall()
    {
        transform.RotateOverTime(DoorRotation, 2);
    }
}
