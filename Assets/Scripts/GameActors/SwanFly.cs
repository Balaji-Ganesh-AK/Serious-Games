using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwanFly : MonoBehaviour
{
    //public Movement movement;
    public float speed = 1f;
    public float rotationAngle = 1f;
    private float UTurn_progress = 0f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = this.transform.forward * speed;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        this.transform.Rotate(this.transform.up, rotationAngle);
            
        rb.velocity = this.transform.forward * speed;
        
    }
    void Update()
    {
        //
    }

    //IEnumerator UTurn()
    //{
    //    bool isTurning = true;
    //    while(isTurning)
    //    {
    //        UTurn_progress += rotationAngle;
    //        this.transform.Rotate(Vector3.up, rotationAngle);
    //        if (UTurn_progress >= 180f)
    //            isTurning = false;
    //    }
    //    yield return new WaitUntil();
    //}

}
