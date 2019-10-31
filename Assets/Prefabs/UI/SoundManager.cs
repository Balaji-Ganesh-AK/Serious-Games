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
        if (PissedOfDuckCollider.isTrigger == true && PissedOfDuck.isPlaying == false)
        {
            //Debug.Log("yes");
            StartCoroutine(SoundLoop());
        }
        else
        {

            StopCoroutine(SoundLoop());
        }
        
    } 
    IEnumerator SoundLoop()
    {
        yield return new WaitForSecondsRealtime(2);
        PissedOfDuck.Play();
       
       
    }
}
