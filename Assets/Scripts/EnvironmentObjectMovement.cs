using UnityEngine;

public class Bobbing : MonoBehaviour
{
    private float originalY;

    //public Transform bobber;

    public float BobbingStrength = 1;

    // Start is called before the first frame update
    void Start()
    {
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            originalY + (float)System.Math.Sin(Time.realtimeSinceStartup) * BobbingStrength,
            transform.position.z
        );
    }
}
