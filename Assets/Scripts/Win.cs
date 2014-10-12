using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Win : MonoBehaviour {

    public bool victory;

	// Use this for initialization
	void Start () {
        victory = false;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //if(other.gameObject.GetComponent<Selectable>() != null)
            victory = true;
    }

    void OnGUI()
    {
        if (victory)
        {
            GUI.TextField(new Rect(50,50,200,50), "You're Winner!");
        }
    }

	// Update is called once per frame
	void Update () {
	}
}
