using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource PissedOfDuck;
    private SphereCollider PissedOfDuckCollider;
    private void Start()
    {
        PissedOfDuckCollider = PissedOfDuck.GetComponent<SphereCollider>();
    }
    private void Update()
    {
        if (PissedOfDuckCollider.isTrigger == true)
        {
            Debug.Log("yes");
            SoundLoop();
        }
        else
        {
            
            PissedOfDuck.Stop();
        }
        
    } 
    private void SoundLoop()
    {
        PissedOfDuck.Play();
       
       
    }
}
