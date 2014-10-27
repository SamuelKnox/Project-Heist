using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Selectable : MonoBehaviour
{
    [Tooltip("Whether or not the gameObject is currently under user control")]
    public bool Selected = false;

	private InventoryDisplay invDisp;
	void Awake()
	{
		invDisp = GetComponentInChildren<InventoryDisplay> ();
		if (invDisp == null)
			Debug.LogError("No inventory component attached to child object");
	}

    void OnMouseDown()
    {
        SetSelected(!Selected);
    }

    private void SetSelected(bool selected)
    {
        Selected = selected;
        if (Selected)
        {
            gameObject.renderer.material.color = Color.green;
			if (invDisp != null)
				invDisp.displayInventory = true;
        }
        else
        {
            gameObject.renderer.material.color = Color.white;
			if (invDisp != null)
				invDisp.displayInventory = false;
        }
    }
}
