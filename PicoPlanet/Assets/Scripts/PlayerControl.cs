using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Vector2 direction;
    private Rigidbody2D rb;
    private bool facingRight;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    private void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), 0);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        direction = transform.TransformDirection(direction);
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        if ((!facingRight && direction.x > 0) || (facingRight && direction.x < 0))
        {
            Flip();
        }
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")))
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
