using UnityEngine;

public class EnvironmentObjectMovement : MonoBehaviour
{
    

    private Vector3 originalPosition;

    public float BobbingStrength = 1f;

    public float CirclingRadius = 1f;

    public float CirclingSpeed = 10f;

    const float RadToDegConversion = 180f / Mathf.PI;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        transform.Rotate(Vector3.up, Mathf.PI / 2);
    }

    // Update is called once per frame
    void Update()
    {
        var startPos = transform.position;
        
        transform.position = new Vector3(
            originalPosition.x + (CirclingRadius > 0 ? Mathf.Cos(Time.realtimeSinceStartup / CirclingRadius) * CirclingRadius * CirclingSpeed : originalPosition.x),
            originalPosition.y + Mathf.Sin(Time.realtimeSinceStartup) * BobbingStrength,
            originalPosition.z + (CirclingRadius > 0 ? Mathf.Sin(Time.realtimeSinceStartup / CirclingRadius) * CirclingRadius * CirclingSpeed: originalPosition.z)
        );

        if (CirclingRadius < .001f) return;

        // Get the change in distance
        var _dD = transform.position - startPos;
        // We only care about two dimensions here, so let's work with this
        var dD = new Vector2(_dD.x, _dD.z).magnitude;
        // Dividing the delta distance by the radius will give us our dTheta
        // (the units work out). We also need to convert to degrees
        var theta = dD / CirclingRadius * RadToDegConversion;
        Debug.Log($"Delta distance: {dD}; Theta: {dD}");
        transform.Rotate(Vector3.up, -theta);//*/
    }
}
