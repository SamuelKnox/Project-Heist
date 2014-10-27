using UnityEngine;
using System.Collections;

public class DoorSystem : Interaction
{
	public override string MenuName()
	{
		return "Open";
	}

	public override bool Visible (params Transform[] lst)
	{
		return true;
	}

	public override void Interact (params Transform[] lst)
	{
		transform.RotateOverTime(new Vector3(0, 180, 0), 2);
	}
}
