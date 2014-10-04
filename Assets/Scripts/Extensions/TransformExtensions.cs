using UnityEngine;
using System.Collections;
using System;

public static class TransformExtensions
{
    /// <summary>
    /// Rotates a game object by a specified number of degrees over a set number of seconds
    /// </summary>
    public static void RotateOverTime(this Transform transform, Vector3 degrees, float seconds)
    {
        RotateOverTime rotateOverTimeComponent = transform.gameObject.AddComponent<RotateOverTime>();
        rotateOverTimeComponent.Degrees = degrees;
        rotateOverTimeComponent.Seconds = seconds;
    }
}

class RotateOverTime : MonoBehaviour
{
    [Tooltip("Degrees by which to rotate the game object.  Game object will be rotated locally.")]
    public Vector3 Degrees;
    [Tooltip("Time (in seconds) it takes until rotation is complete.")]
    public float Seconds = 1.0F;

    private Vector3 rotationCompleted = Vector3.zero;
    private Vector3 speed;
    private Vector3 startRotation;

    void Start()
    {
        speed = GetBalancedRotationSpeeds(Degrees, Seconds);
        startRotation = transform.eulerAngles;
    }

    void FixedUpdate()
    {
        UpdateRotation();
        if (IsRotationComplete())
        {
            Destroy(this);
        }
    }

    private Vector3 GetBalancedRotationSpeeds(Vector3 degrees, float seconds)
    {
        float degreesWeight = (Degrees.x + Degrees.y + Degrees.z) / 3;
        float speedModifier = degreesWeight / seconds;
        float totalChangeInDegrees = Math.Abs(degrees.x) + Math.Abs(degrees.y) + Math.Abs(degrees.z);
        float xWeight = Math.Abs(degrees.x) / totalChangeInDegrees;
        float yWeight = Math.Abs(degrees.y) / totalChangeInDegrees;
        float zWeight = Math.Abs(degrees.z) / totalChangeInDegrees;
        float xSpeed = xWeight * speedModifier * 3;
        float ySpeed = yWeight * speedModifier * 3;
        float zSpeed = zWeight * speedModifier * 3;
        return new Vector3(xSpeed, ySpeed, zSpeed);
    }

    private void UpdateRotation()
    {
        rotationCompleted += Time.deltaTime * speed;
        transform.eulerAngles = Quaternion.Euler(rotationCompleted + startRotation).eulerAngles;
    }

    private bool IsRotationComplete()
    {
        bool xRotationIsComplete = Math.Abs(rotationCompleted.x) >= Math.Abs(Degrees.x);
        bool yRotationIsComplete = Math.Abs(rotationCompleted.y) >= Math.Abs(Degrees.y);
        bool zRotationIsComplete = Math.Abs(rotationCompleted.z) >= Math.Abs(Degrees.z);
        return xRotationIsComplete && yRotationIsComplete && zRotationIsComplete;
    }
}