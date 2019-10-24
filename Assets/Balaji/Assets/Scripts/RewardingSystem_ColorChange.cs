using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;
public class RewardingSystem_ColorChange : MonoBehaviour
{
    [SerializeField]
    public GameObject[] colorChangingPrefabList;
    
    
    
    private GameObject cloneInitialColor;
    private GameObject[] cloneColorChangingPrefabs;
 
    private int index = 0;
    private int[] counter;
    //Reward counter.


    void Start()
    {
        int temp = colorChangingPrefabList.Length;
        counter = new int[temp]; 

        // The location is a place holder for now, Once we get the color pallet, we can use its location.
        cloneInitialColor = Instantiate(colorChangingPrefabList[0], new Vector3(1.0f, 1.05f, -0.383f), Quaternion.identity);
       
    }


    void Update()
    {
       
        //Count the number of times 
        if (cloneInitialColor == null)
        {
            counter[0] += 1;
            cloneInitialColor = Instantiate(colorChangingPrefabList[0], new Vector3(1.0f, 1.05f, -0.383f), Quaternion.identity);
        }
        

        //go through the counter and 

        
        

    }
    
    public void RespawnObject(GameObject rb)
    {
        string nameOfCurrentObeject = rb.name;
        int n = 0;


        //Respawn the initial object;
        while (n < colorChangingPrefabList.Length)
        {
            if (string.Format("{0}(Clone)", colorChangingPrefabList[n].name) == nameOfCurrentObeject)
            {
                Debug.Log("HI in the rewarding system");
                cloneInitialColor = Instantiate(colorChangingPrefabList[n], new Vector3(1.0f, 1.05f, -0.383f), Quaternion.identity);
            }
            n++;
        }
    
    }

}
