using UnityEngine;
using System.Collections;

public abstract class Interaction : MonoBehaviour
{
    public abstract void Interact(params Transform[] lst);

	//probably could use better design
	/** The string that appears on the action menu when the object is clicked */
	public abstract string MenuName();

	/** Whether this is a valid action, based on the game state */
	public abstract bool Visible(params Transform[] lst);
}
