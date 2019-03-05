using UnityEngine;

public class BodyOnPlanet : MonoBehaviour
{
    public Planet planet;
    private Transform body;

    private void Start()
    {
        body = transform;
    }

    private void Update()
    {
        planet.Attract(body);
    }
}
