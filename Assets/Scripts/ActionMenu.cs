using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Selectable))]
public class ActionMenu : MonoBehaviour
{

    public Selectable Selectable
    {
        get
        {
            return GetComponent<Selectable>();
        }
    }

    // Prevents stacking of multiple menus
    private bool created;
    private float x, y;
    private List<Object> liveButtons;
	private List<Interaction> liveInteractions;

    // Every possible command goes here. The relevant ones will be selected on menu creation.
    public GameObject moveHere;

    // Use this for initialization
    void Start()
    {
        liveButtons = new List<Object>();
		liveInteractions = new List<Interaction>();
        created = false;
    }


    void OnGUI()
    {
        if (created && Input.GetMouseButtonDown(1) || !Selectable.Selected)
        {
            DestroyMenu();
        }

        if (Selectable.Selected && Input.GetMouseButtonDown(1))
        {
            CreateMenu();
        }

        if (created)
        {
            ShowMenu();
        }
    }

    private void CreateMenu()
    {
        Vector3 center = Input.mousePosition;
        x = center.x;
        y = Screen.height - center.y;

		liveInteractions.Clear();
		Vector3 point = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D[] hits = Physics2D.LinecastAll (point, point);
		if (hits.Length > 0)
		{
			//Debug.Log ("HIT " + hits[0].transform.gameObject.name);
			//we will take the first object in the array
			//TODO: handle multiple objects being detected
			Transform obj = hits[0].transform;
			Interaction[] interactables = obj.GetComponents<Interaction>();
			foreach(Interaction inter in interactables)
			{
				if (inter.Visible(Selectable.transform))
				{
					liveInteractions.Add(inter);
				}
			}
		}
        //moveHere.layer = LayerMask.NameToLayer("UI");
        //liveButtons.Add(Instantiate(moveHere, center + new Vector3(0, .1f, 10), Quaternion.identity));
        created = true;
    }

    private void DestroyMenu()
    {
        foreach (Object o in liveButtons)
        {
            Destroy(o);
        }
        liveButtons.Clear();
		liveInteractions.Clear();
        created = false;
    }

    private void ShowMenu()
    {
        GUIStyle style = GUI.skin.GetStyle("button");
        float width = 50;
        float height = 20;
        float radius = 40;
        style.fontSize = 8;

		bool[] optionsSelected = new bool[liveInteractions.Count];
		int i = 0;
		foreach (Interaction inter in liveInteractions)
		{
			float angle = (Mathf.PI * 2 / optionsSelected.Length) * i;
			optionsSelected[i] = GUI.Button (new Rect(x - width / 2 + radius * Mathf.Cos (angle),
			                                          y - height / 2 + radius * Mathf.Sin (angle),
			                                          width, height), inter.MenuName());
			i++;
		}
        bool moveHere = GUI.Button(new Rect(x - width / 2, y - height / 2 - radius * 2, width, height), "Move Here");
        bool sneakHere = GUI.Button(new Rect(x - width / 2, y - height / 2 + radius * 2, width, height), "Sneak Here");

		
		for (i = 0; i < optionsSelected.Length; i++)
		{
			if (optionsSelected[i])
			{
				liveInteractions[i].Interact(Selectable.transform);
				break;
			}
		}

        bool movement = moveHere || sneakHere;
        if (movement)
        {
			created = false;

            ClickableMovement mov = GetComponent<ClickableMovement>();
            mov.AddPoint(new Waypoint(new Vector3(x, Screen.height - y, 0), sneakHere));
        }

    }
}
