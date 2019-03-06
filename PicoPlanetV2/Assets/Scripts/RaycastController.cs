using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RaycastController : MonoBehaviour
{

    public LayerMask collisionMask;

    public const float skinWidth = .015f;
    private const float dstBetweenRays = .25f;
    [HideInInspector]
    public int horizontalRayCount;
    [HideInInspector]
    public int verticalRayCount;

    [HideInInspector]
    public float horizontalRaySpacing;
    [HideInInspector]
    public float verticalRaySpacing;

    [HideInInspector]
    public new BoxCollider2D collider;
    public RaycastOrigins raycastOrigins;

    public virtual void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    public virtual void Start()
    {
        CalculateRaySpacing();
    }

    public void UpdateRaycastOrigins()
    {
        // TODO apply skinwidth

        var pos = collider.transform.position;
        var size = collider.size;

        raycastOrigins.bottomLeft = new Vector2(pos.x - size.x / 2, pos.y - size.y / 2);
        raycastOrigins.bottomRight = new Vector2(pos.x + size.x / 2, pos.y - size.y / 2);
        raycastOrigins.topLeft = new Vector2(pos.x - size.x / 2, pos.y + size.y / 2);
        raycastOrigins.topRight = new Vector2(pos.x + size.x / 2, pos.y + size.y / 2);
    }

    public void CalculateRaySpacing()
    {

        float boundsWidth = collider.size.x;
        float boundsHeight = collider.size.y;

        horizontalRayCount = Mathf.RoundToInt(boundsHeight / dstBetweenRays);
        verticalRayCount = Mathf.RoundToInt(boundsWidth / dstBetweenRays);

        horizontalRaySpacing = collider.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = collider.size.x / (verticalRayCount - 1);
    }

    public struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
}
