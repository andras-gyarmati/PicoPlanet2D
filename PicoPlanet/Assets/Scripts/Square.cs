using UnityEngine;

public class Square : MonoBehaviour
{
    public GameObject other;
    private Rigidbody2D rb;
    private float a;

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
    }
}
