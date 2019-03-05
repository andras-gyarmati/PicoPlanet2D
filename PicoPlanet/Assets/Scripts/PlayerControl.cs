using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Vector2 direction;
    private Vector2 jumpDir;
    private Rigidbody2D rb;
    private bool facingRight;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        direction = new Vector2();
        jumpDir = new Vector2(0, 1);
    }

    private void Update()
    {
        direction.Set(0, 0);
        direction.Set(Input.GetAxis("Horizontal"), 0);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        direction = transform.TransformDirection(direction);
        Debug.Log("direction: " + direction);
        if (direction.x != 0 || direction.y != 0)
        {
            rb.velocity = direction * speed * Time.deltaTime;
        }
        if ((!facingRight && direction.x > 0) || (facingRight && direction.x < 0))
        {
            Flip();
        }
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")))
        {
            jumpDir = transform.TransformDirection(jumpDir);
            rb.velocity = jumpDir * jumpForce * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
