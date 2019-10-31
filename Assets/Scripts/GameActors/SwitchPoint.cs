using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nextpoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<SwanSwim>())
        {
            Debug.Log("reach!");
            other.GetComponent<SwanSwim>().current_point = nextpoint;
        }
    }
}
