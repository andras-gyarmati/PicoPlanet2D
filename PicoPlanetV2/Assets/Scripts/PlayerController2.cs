using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public Transform pivot;
    public Transform groundcheck;
    public float RotationSpeed = 100.0f;

    public float radius = 0.1f;
    public LayerMask whatIsGround;

    private bool isGrounded = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, radius, whatIsGround.value);

        //Debug.Log(isGrounded.ToString());
        var direction = Input.GetAxisRaw("Horizontal");

        if (!isGrounded)
            rb.velocity.Set(0.0f, 0.5f);
            //transform.localPosition = new Vector3()
            //{
            //    x = transform.localPosition.x,
            //    y = transform.localPosition.y - 1.0f * Time.fixedDeltaTime,
            //    z = transform.localPosition.z
            //};

        if (direction == 0.0)
            return;

        transform.RotateAround(pivot.position, Vector3.back, direction * RotationSpeed * Time.fixedDeltaTime);
    }
}
