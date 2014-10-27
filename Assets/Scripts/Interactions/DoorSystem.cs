using UnityEngine;
using System.Collections;

public class DoorSystem : Interaction
{

    public override void Interact()
    {
        transform.RotateOverTime(new Vector3(0, 90, 0), 2);
    }
}
