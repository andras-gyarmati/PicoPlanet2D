using UnityEngine;

public class Planet : MonoBehaviour
{
    public float GravitationalConstant;

    public void Attract(Transform other)
    {
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();
        Rigidbody2D rb = transform.GetComponent<Rigidbody2D>();
        Vector2 gravityUp = (other.position - transform.position).normalized;
        Vector2 bodyUp = other.up;
        float gravity = ((GravitationalConstant * rb.mass * otherRb.mass) / Vector2.Distance(other.position, transform.position));
        otherRb.AddForce(gravityUp * -gravity);
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * other.rotation;
        other.rotation = Quaternion.Slerp(other.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
