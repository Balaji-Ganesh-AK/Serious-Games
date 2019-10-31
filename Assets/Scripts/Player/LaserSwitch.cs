using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR.Extras;
using Valve.VR;

public class LaserSwitch : MonoBehaviour
{
    public SteamVR_LaserPointer laserComponet;
    private Hand hand;
    public float laserThickness;
    private bool isLazerOn;
    public SteamVR_Action_Boolean grabPinchAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");


    private void Awake()
    {
        hand = GetComponent<Hand>();
        
        //laserComponet = transform.Find("RightHand").GetComponent<SteamVR_LaserPointer>();
        Debug.Log(laserComponet.gameObject);
        //laserComponet.thickness = 0f;
        //laserComponet.enabled = false;
    }

    public void SwitchLaserOn()
    {
        //laserComponet.thickness = laserThickness;
        isLazerOn = true;
    }

    public void SwitchLaserOff()
    {
        //laserComponet.thickness = 0f;
        isLazerOn = false;
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
    }

    protected virtual void OnAttachedToHand(Hand hand)
    {
        Debug.Log("??!");
    }
    protected virtual void OnDetachedFromHand(Hand hand)
    {
        Debug.Log("Nooo!");
    }

}


