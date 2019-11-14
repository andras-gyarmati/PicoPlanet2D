using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject other;
    private Rigidbody2D otherRb;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        otherRb = other.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var diff = other.transform.position - transform.position;
        var dir = -diff / diff.magnitude;
        var g = otherRb.mass * rb.mass / diff.sqrMagnitude;
        var f = dir * g;
        otherRb.AddForce(f);
    }
}
