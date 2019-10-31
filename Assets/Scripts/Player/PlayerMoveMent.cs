using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem
{
    public class PlayerMoveMent : MonoBehaviour
    {

        public float speed = 1.0f;
        public SteamVR_Action_Boolean snapForwardAction = SteamVR_Input.GetBooleanAction("MoveForward");
        public SteamVR_Action_Boolean snapBackwardAction = SteamVR_Input.GetBooleanAction("MoveBackward");



        private void Update()
        {

            Player player = Player.instance;
            bool rightHandValid = player.rightHand.currentAttachedObject == null ||
                    (player.rightHand.currentAttachedObject != null
                    && player.rightHand.currentAttachedTeleportManager != null
                    && player.rightHand.currentAttachedTeleportManager.teleportAllowed);

            bool leftHandValid = player.leftHand.currentAttachedObject == null ||
                (player.leftHand.currentAttachedObject != null
                && player.leftHand.currentAttachedTeleportManager != null
                && player.leftHand.currentAttachedTeleportManager.teleportAllowed);



            bool leftHandForward = snapForwardAction.GetState(SteamVR_Input_Sources.LeftHand) && leftHandValid;
            bool rightHandForward = snapForwardAction.GetState(SteamVR_Input_Sources.RightHand) && rightHandValid;
            
            bool leftHandBackward = snapBackwardAction.GetState(SteamVR_Input_Sources.LeftHand) && leftHandValid;
            bool rightHandBackward = snapBackwardAction.GetState(SteamVR_Input_Sources.RightHand) && rightHandValid;


            
            if (leftHandForward || rightHandForward)
            {
                moveForward(speed);
            }
            else if (leftHandBackward || rightHandBackward)
            {
                moveBackward(-speed);
            }

        }

        private void moveForward(float speed)
        {
            CharacterController cc = GetComponent<CharacterController>();
            Player player = Player.instance;
            //Vector3 playerFeetOffset = player.trackingOriginTransform.position - player.feetPositionGuess;
            // player.trackingOriginTransform.position -= playerFeetOffset;
            float yPos = player.transform.position.y;
           // player.transform.position += player.hmdTransform.forward * Time.deltaTime * speed;
            
           // player.transform.position = new Vector3(player.transform.position.x, yPos , player.transform.position.z);


            Vector3 Forward = new Vector3(player.hmdTransform.forward.x * Time.deltaTime * speed, 0 , player.hmdTransform.forward.z*Time.deltaTime * speed);

            //Forward = new Vector3(player.transform.position.x, yPos, player.transform.position.z);
            //cc.Move(Forward);
            cc.SimpleMove(Forward);
        }
        private void moveBackward(float speed)
        {
            CharacterController cc = GetComponent<CharacterController>();
            Player player = Player.instance;
            //Vector3 playerFeetOffset = player.trackingOriginTransform.position - player.feetPositionGuess;
            // player.trackingOriginTransform.position -= playerFeetOffset;
            float yPos = player.transform.position.y;
            // player.transform.position += player.hmdTransform.forward * Time.deltaTime * speed;

            // player.transform.position = new Vector3(player.transform.position.x, yPos , player.transform.position.z);


            Vector3 Forward = new Vector3(player.hmdTransform.forward.x * Time.deltaTime * speed, 0, player.hmdTransform.forward.z * Time.deltaTime * speed);

            //Forward = new Vector3(player.transform.position.x, yPos, player.transform.position.z);
            //cc.Move(Forward);
            cc.SimpleMove(Forward);
        }

    }
}