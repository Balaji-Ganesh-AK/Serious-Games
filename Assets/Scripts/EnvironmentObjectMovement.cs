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
        transform.position = new Vector3(
            originalPosition.x + (CirclingRadius > 0 ? Mathf.Cos(Time.realtimeSinceStartup / CirclingRadius) * CirclingRadius : originalPosition.x),
            originalPosition.y + Mathf.Sin(Time.realtimeSinceStartup) * BobbingStrength,
            originalPosition.z + (CirclingRadius > 0 ? Mathf.Sin(Time.realtimeSinceStartup / CirclingRadius) * CirclingRadius : originalPosition.z)
        );

        //float angle = Mathf.Acos(Vector3.Dot(originalPosition, transform.position)/(originalPosition.magnitude * transform.position.magnitude));
        //float angle = Mathf.Asin(transform.position.z);
        Vector2 perp = new Vector2(originalPosition.z, -originalPosition.x);
        //float angle = 
        //transform.rotation = new Quaternion(transform.rotation.x, angle, transform.rotation.z, transform.rotation.w);
        //transform.Rotate(Vector3.up, Mathf.A(originalPosition.z, originalPosition.x));
    }
}
