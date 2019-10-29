using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShadows : MonoBehaviour
{
    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.receiveShadows = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
