using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRelease : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform rightHand;

    public void OnReleased()
    {
        this.GetComponent<Rigidbody>().AddForce(rightHand.forward * 100f);
    }
}
