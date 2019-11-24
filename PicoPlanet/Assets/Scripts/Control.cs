using UnityEngine;

public class Control : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed;
    public int jumpForce;
    public float airDrag;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
