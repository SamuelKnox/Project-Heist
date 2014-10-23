using UnityEngine;
using System.Collections;

public enum GameItem
{
	BathroomKeys = 0,
	Bombs,
}

/// <summary>
/// Contains an with a slot for each item type, the value in the 
/// slot indicates the quantity held of that item
/// </summary>
public class Inventory2 : MonoBehaviour {

	public static int NUM_ITEMS =
		System.Enum.GetNames(typeof(GameItem)).Length;

	public int[] items = new int[NUM_ITEMS];

	public bool hasItem(GameItem type)
	{
		return numItem(type) > 0;
	}

	public int numItem(GameItem type)
	{
		return items[(int)type];
	}

	public void addItem(GameItem type)
	{
		shiftItemCount(type, 1);
	}

	public void shiftItemCount(GameItem type, int num)
	{
		items[(int)type] += num;
		if (items[(int)type] < 0)
			items[(int)type] = 0;
	}

	public void setItemCount(GameItem type, int num)
	{
		if (num >= 0)
			items[(int)type] = num;
	}

	//load, save
}
