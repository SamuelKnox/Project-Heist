using UnityEngine;using System.Collections;[RequireComponent(typeof(Collider2D))]public class Win : MonoBehaviour {    public bool victory;    private bool first;	// Use this for initialization	void Start () {        victory = false;
        first = true;	}    void OnTriggerEnter2D(Collider2D other)    {
        if (other.gameObject.GetComponent<Selectable>() != null)
        {
            victory = true;
            Destroy(GameObject.Find("Guard"));
        }    }    void OnGUI()    {        if (victory)        {
            GUI.TextField(new Rect(50, 50, 200, 50), "You're Winner!");
            if (first)
            {
                Application.LoadLevel(Application.loadedLevel);
                //StartCoroutine("Wait");
                //first = false;
            }        }    }

    IEnumerable Wait()
    {
        yield return new WaitForSeconds(5.0f);
        Application.LoadLevel(Application.loadedLevel);
    }
}