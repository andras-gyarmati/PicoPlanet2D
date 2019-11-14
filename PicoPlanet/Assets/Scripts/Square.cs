using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public GameObject other;
    private Rigidbody2D rb;
    private float a;
    public int speed;
    public int jumpForce;
    public float airDrag;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        a = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        var v = transform.position - other.transform.position;
        a = Vector3.SignedAngle(Vector3.up, v, Vector3.back);
        rb.SetRotation(Quaternion.AngleAxis(a, Vector3.back));

        var f = Vector3.zero; 

        if (Input.GetKey(KeyCode.RightArrow))
        {
            f += transform.right * speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            f += -transform.right * speed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            f += transform.up * jumpForce;
        }

        rb.AddForce(f);

        rb.velocity *= airDrag;
    }
}
