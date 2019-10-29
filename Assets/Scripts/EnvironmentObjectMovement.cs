using UnityEngine;

public class EnvironmentObjectMovement : MonoBehaviour
{
    

    private Vector3 originalPosition;

    public float BobbingStrength = 1f;

    public float CirclingRadius = 1f;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;


        var startPos = transform.position;
        
        transform.position = new Vector3(
            originalPosition.x + (CirclingRadius > 0 ? Mathf.Cos(Time.realtimeSinceStartup / CirclingRadius) * CirclingRadius : originalPosition.x),
            originalPosition.y + Mathf.Sin(Time.realtimeSinceStartup) * BobbingStrength,
            originalPosition.z + (CirclingRadius > 0 ? Mathf.Sin(Time.realtimeSinceStartup / CirclingRadius) * CirclingRadius : originalPosition.z)
        );

        var deltaPos = transform.position - startPos;
        deltaPos /= deltaTime;
        var omega = deltaPos / CirclingRadius;
        var dTheta = omega * deltaTime;
        //float angle = Mathf.Acos(Vector3.Dot(originalPosition, transform.position)/(originalPosition.magnitude * transform.position.magnitude));
        //float angle = Mathf.Asin(transform.position.z);
        Vector2 perp = new Vector2(originalPosition.z, -originalPosition.x);
        //float angle = 
        transform.Rotate(Vector3.up, dTheta.x);
    }
}
