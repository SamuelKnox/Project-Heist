using UnityEngine;
using System.Collections;
[RequireComponent(typeof (Item))]
public class ItemEffect : MonoBehaviour {
	
//This script allows you to insert code when the Item is used (clicked on in the inventory).
bool deleteOnUse = true;

private Inventory playersInv;
private Item item;



//This is where we find the components we need
void Awake (){
	playersInv = FindObjectOfType(typeof(Inventory)) as Inventory; //finding the players inv.
	if (playersInv == null)
	{
		Debug.LogWarning("No 'Inventory' found in game. The Item " + transform.name + " has been disabled for pickup (canGet = false).");
	}
	item = GetComponent<Item>();
}

//This is called when the object should be used.
public void UseEffect (){
	Debug.LogWarning("<INSERT CUSTOM ACTION HERE>"); //INSERT CUSTOM CODE HERE!
	
	//Play a sound
	playersInv.gameObject.SendMessage("PlayDropItemSound", SendMessageOptions.DontRequireReceiver);
	
	//This will delete the item on use or remove 1 from the stack (if stackable).
	if (deleteOnUse == true)
	{
		DeleteUsedItem();
	}
}

//This takes care of deletion
void DeleteUsedItem (){
	if (item.stack == 1) //Remove item
	{
		playersInv.RemoveItem(this.gameObject.transform);
	}
	else //Remove from stack
	{
		item.stack -= 1;
	}
	Debug.Log(item.name + " has been deleted on use");
}
}