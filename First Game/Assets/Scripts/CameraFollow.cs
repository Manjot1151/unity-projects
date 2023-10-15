using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z) + offset;
    }
}
