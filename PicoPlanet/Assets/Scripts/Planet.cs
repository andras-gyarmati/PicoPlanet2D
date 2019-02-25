﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float gravity = -10f;

    public void Attract(Transform body)
    {
        Vector2 gravityUp = (body.position - transform.position).normalized;
        Vector2 bodyUp = body.up;
        body.GetComponent<Rigidbody2D>().AddForce(gravityUp * gravity);
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
