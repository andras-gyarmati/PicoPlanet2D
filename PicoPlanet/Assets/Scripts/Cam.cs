using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform target;
    public float dist = 3f;

    void LateUpdate()
    {
        Vector2 delta = target.position - transform.position;

        if (delta.magnitude > dist)
        {
            var diff = delta.magnitude - dist;
            delta = (delta / delta.magnitude) * diff;
            transform.position = transform.position + (Vector3)delta;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, 0.05f);
    }
}
