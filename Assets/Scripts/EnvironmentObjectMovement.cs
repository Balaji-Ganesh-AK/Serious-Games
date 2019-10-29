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
            originalPosition.x + Mathf.Cos(Time.realtimeSinceStartup / CirclingRadius) * CirclingRadius,
            originalPosition.y + Mathf.Sin(Time.realtimeSinceStartup) * BobbingStrength,
            originalPosition.z + Mathf.Sin(Time.realtimeSinceStartup / CirclingRadius) * CirclingRadius
        );
    }
}
