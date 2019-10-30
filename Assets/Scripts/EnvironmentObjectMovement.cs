using UnityEngine;

public class EnvironmentObjectMovement : MonoBehaviour
{
    

    private Vector3 originalPosition;

    public float BobbingStrength = 1f;

    public float CirclingRadius = 1f;

    public float CirclingSpeed = 10f;

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
            originalPosition.x + (CirclingRadius > 0 ? Mathf.Cos(Time.realtimeSinceStartup / CirclingRadius) * CirclingRadius : originalPosition.x),
            originalPosition.y + Mathf.Sin(Time.realtimeSinceStartup) * BobbingStrength,
            originalPosition.z + (CirclingRadius > 0 ? Mathf.Sin(Time.realtimeSinceStartup / CirclingRadius) * CirclingRadius : originalPosition.z)
        );

        if (CirclingRadius < .001f) return;

        //var _dD = transform.position - startPos;
        //var dD = new Vector2(_dD.x, _dD.z);

        //var theta = Vector2.Angle(new Vector2(1, 0), dD);
        //transform.rotation = new Quaternion(transform.rotation.x, theta, transform.rotation.z, transform.rotation.w);
        //transform.Rotate(Vector3.up, theta);
        //*
        // It should be facing the direction it's going in... but how?
        // Get the deltaDistance
        var _dD = transform.position - startPos;
        // We only care about two dimensions here, so let's work with this
        var dD = new Vector2(_dD.x, _dD.z).magnitude;
        // Dividing the delta distance by the radius will give us our dTheta
        // (the units work out)
        var theta = dD / CirclingRadius * Mathf.PI;
        Debug.Log($"Delta distance: {dD}; Theta: {dD}");
        transform.Rotate(Vector3.up, -theta * CirclingSpeed);//*/
    }
}
