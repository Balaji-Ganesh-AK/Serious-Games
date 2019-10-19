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
        private SteamVR_LaserPointer laserPointer;
        private bool enablePointer;

        void Awake()
        {
            hand = this.GetComponent<Hand>();
            laserPointer = GetComponent<SteamVR_LaserPointer>();
            enablePointer = false;
            laserPointer.PointerIn += PointerInside;
            laserPointer.PointerOut += PointerOutside;
            laserPointer.PointerClick += PointerClick;
            //laserPointer.active = false;
            laserPointer.enabled = false;
        }

        private void Update()
        {
            if (enablePointer)
            {
                laserPointer.enabled = true;
                if (SteamVR_Input.GetState("Teleport", hand.handType))
                {
                    Debug.Log("Release color ball");
                }
            }
            else
                laserPointer.enabled = false;
            
        }

        public void OnPickUpColorBall()
        {
            //laserPointer.enabled = true;
            enablePointer = true;
            Debug.Log("You picked up a ball");
        }

        public void OnReleaseColorBall()
        {
            Debug.Log("You releasd a ball");
            enablePointer = false;
        }

        public void PointerClick(object sender, PointerEventArgs e)
        {
            if (e.target.name == "Cube")
            {
                Debug.Log("Cube was clicked");
            }
            else if (e.target.name == "Button")
            {
                Debug.Log("Button was clicked");
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
