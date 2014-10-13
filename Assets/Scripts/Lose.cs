using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {

    public bool failure;
    private bool first;

    // Use this for initialization
    void Start()
    {
        failure = false;
        first = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Selectable>() != null)
        {
            failure = true;
            Destroy(other.gameObject);
        }
    }

    void OnGUI()
    {
        if (failure)
        {
            GUI.TextField(new Rect(50, 50, 200, 50), "Yo Lose!");
            if(first) 
                Application.LoadLevel(Application.loadedLevel);
        }
    }

}
