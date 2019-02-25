using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;

    private void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), 0);
    }

    private void FixedUpdate() {
        var rb = GetComponent<Rigidbody2D>();
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }
}
