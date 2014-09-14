using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Selectable : MonoBehaviour
{
    [Tooltip("Whether or not the gameObject is currently under user control")]
    public bool Selected = false;

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
        }
        else
        {
            gameObject.renderer.material.color = Color.white;
        }
    }
}
