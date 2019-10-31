using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionFollow : MonoBehaviour
{
    public ReflectionProbe probe;
    public Camera cam;
    // Start is called before the first frame update
    void Awake()
    {
        probe = GetComponent<ReflectionProbe>();
    }

    // Update is called once per frame
    void Update()
    {
        probe.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        probe.RenderProbe();
    }
}
