/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem.Sample
{
    public class SceneHandler : MonoBehaviour
    {
        
        public Hand hand;
        public Transform right_hand;
        private Vector3 direction;
        public float ballSpeed;
        private SteamVR_LaserPointer laserPointer;
        private bool ballInHand;
        //make it private later
    

        void Awake()
        {
            hand = this.GetComponent<Hand>();
            laserPointer = GetComponent<SteamVR_LaserPointer>();
            ballInHand = false;

            Debug.Log("Awake!!");
            //Debug.Log(right_hand.forward);
            //laserPointer.PointerIn += PointerInside;
            //laserPointer.PointerOut += PointerOutside;
            //laserPointer.PointerClick += PointerClick;
            //laserPointer.active = false;
            //laserPointer.enabled = false;
            
        }

        private void Update()
        {


     
             
        
            //if (SteamVR_Input.GetState("Teleport", hand.handType) && ballInHand)
            //{
            //    Debug.Log("Release color ball");
            //    foreach (Transform child in this.transform)
            //    {
            //        if (child.CompareTag("ColorBalls") && child.GetComponent<Rigidbody>())
            //        {
            //            child.GetComponent<Rigidbody>().velocity = ballSpeed * child.forward;
            //            Debug.Log("Detach from hand");
            //            hand.DetachObject(child.gameObject);
            //        }
            //    }
            //}
            //Debug.Log(right_hand.forward);
            if (direction != Vector3.zero)
                direction = right_hand.forward;
            //Debug.Log(direction);
        }

        public void OnPickUpColorBall()
        {
            //laserPointer.enabled = true;
            ballInHand = true;
            //Debug.Log("You picked up a ball");
        }

        public void OnReleaseColorBall(Rigidbody rb)
        {
            Debug.Log("You releasd a ball ");
            
            //Sending the name of the gameobject to the rewarding system
            

            ballInHand = false;
            rb.useGravity = false;
            Debug.Log("Called: "+direction);
            rb.velocity = ballSpeed * hand.transform.forward;
            rb.AddForce(direction * 100f);
           
        }
       

        public void PointerClick(object sender, PointerEventArgs e)
        {
            if (e.target.name == "Cube")
            {
                Debug.Log("Cube was clicked");
            }

        }

        public void PointerInside(object sender, PointerEventArgs e)
        {
            if (e.target.name == "Cube")
            {
                Debug.Log("Cube was entered");
            }
            else if (e.target.name == "Button")
            {
                Debug.Log("Button was entered");
            }
        }

        public void PointerOutside(object sender, PointerEventArgs e)
        {
            if (e.target.name == "Cube")
            {
                Debug.Log("Cube was exited");
            }
            else if (e.target.name == "Button")
            {
                Debug.Log("Button was exited");
            }
        }
    }
    
}
