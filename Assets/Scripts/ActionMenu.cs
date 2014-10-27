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

    // Every possible command goes here. The relevant ones will be selected on menu creation.
    public GameObject moveHere;

    // Use this for initialization
    void Start()
    {
        liveButtons = new List<Object>();
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
        created = false;
    }

    private void ShowMenu()
    {
        GUIStyle style = GUI.skin.GetStyle("button");
        float width = 50;
        float height = 20;
        float radius = 20;
        style.fontSize = 8;

        bool moveHere = GUI.Button(new Rect(x - width / 2, y - height / 2 - radius, width, height), "Move Here");
        bool sneakHere = GUI.Button(new Rect(x - width / 2, y - height / 2 + radius, width, height), "Sneak Here");

        bool movement = moveHere || sneakHere;

        if (movement)
        {
            //temp code starts
            DoorSystem door = GameObject.FindObjectOfType<DoorSystem>() as DoorSystem;
            door.Interact();
            //temp code ends

            created = false;

            ClickableMovement mov = GetComponent<ClickableMovement>();
            mov.AddPoint(new Waypoint(new Vector3(x, Screen.height - y, 0), sneakHere));
        }

    }
}
