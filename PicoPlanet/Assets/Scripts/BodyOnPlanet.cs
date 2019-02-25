using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyOnPlanet : MonoBehaviour
{
    public Planet planet;
    private Transform body;

    void Start()
    {
        body = transform;
    }

    void Update()
    {
        planet.Attract(body);
    }
}
