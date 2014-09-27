using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveBasic : MonoBehaviour
{

    [Tooltip("This will adjust the X/Y velocity of the movement.")]
    public Vector2 VelocityMultipler = new Vector2(1F, 1F);
    public float velocity = 3.0f;
    private Rigidbody2D mBody;

    // Use this for initialization
    void Start()
    {
        mBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        mBody.velocity = new Vector2(h * velocity * VelocityMultipler.x, v * velocity * VelocityMultipler.y);
    }
}
