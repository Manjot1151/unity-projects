using System;
using UnityEngine;

public class LoopAround : MonoBehaviour
{
    private float cameraXLimit = 19.0f;
    private float cameraYLimit = 11.25f;
    void FixedUpdate()
    {
        if (Math.Abs(transform.position.x) > cameraXLimit)
        {
            transform.position = new Vector2(-Math.Sign(transform.position.x) * cameraXLimit, transform.position.y);
        }
        if (Math.Abs(transform.position.y) > cameraYLimit)
        {
            transform.position = new Vector2(transform.position.x, -Math.Sign(transform.position.y) * cameraYLimit);
        }
    }
}
