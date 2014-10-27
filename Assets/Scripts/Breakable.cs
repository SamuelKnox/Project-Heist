﻿using UnityEngine;
using System.Collections;

/*
 * Attach to objects which can be removed by bombs
 */
public class Breakable : Interaction {
	public float strengthFactor = 1.0f;

	public override void Interact (params Transform[] lst)
	{
		//verify player has dynamite
		//queue move to here
		//queue drop dynamite
		//queue move away (?)
	}

	public override bool Visible (params Transform[] lst)
	{
		//we assume the first element is the selected player
		if (lst.Length > 0)
		{
			Transform player = lst[0];
			Inventory inv = player.GetComponentInChildren<Inventory>();
			if (inv != null)
			{
				//if player has dynamite
				//	return true
			}
		}
		return false;
	}

	public override string MenuName ()
	{
		return "Explode";
	}
}
