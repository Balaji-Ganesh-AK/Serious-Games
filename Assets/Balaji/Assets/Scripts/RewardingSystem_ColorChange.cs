//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Valve.VR.Extras;
//using Valve.VR.InteractionSystem;
//public class RewardingSystem_ColorChange : MonoBehaviour
//{
//    [SerializeField]
//    public GameObject[] colorChangingPrefabList;
    
    
    
//    private GameObject cloneInitialColor;
//    private GameObject[] cloneColorChangingPrefabs;
 
//    private int index = 0, lastUnlockedBall =0;
//    private int[] counter;
//    bool isDestoryed;
//    //Reward counter.


//    void Start()
//    {
//        int temp = colorChangingPrefabList.Length;
//        counter = new int[temp];
//        cloneColorChangingPrefabs = new GameObject[temp];

//        // The location is a place holder for now, Once we get the color pallet, we can use its location.
//        cloneInitialColor = Instantiate(colorChangingPrefabList[0], new Vector3(1.0f, 1.05f, -0.383f), Quaternion.identity);
//        cloneColorChangingPrefabs[0] = cloneInitialColor;
//    }


//    void Update()
//    {
//        int n = 0;
//        Debug.Log("Counter"+counter[0]);
//        //Count the number of times 
        
            
            
        
//        //go through the counter and and check if its more than the limit
//        // if a counter value of the last unlocked ball is higher than the limit, unlock a new ball.
//        if (counter[lastUnlockedBall] >= 2)
//        {
//            //unlock the next ball
//            // lastUnlockedBall++;
//            Debug.Log("time to unlock a new ball");
//           // cloneColorChangingPrefabs[1] = Instantiate(colorChangingPrefabList[1], new Vector3(1.0f, 1.05f, 0.383f), Quaternion.identity);
//        }
        
        

//    }
    
//    public void RespawnObject(GameObject rb)
//    {
//        int n = 0;
//        string nameOfCurrentObeject = rb.name;
//        Debug.Log("Testing coroutine");
//        //Respawn;

//        //StartCoroutine(Respawn(rb));

//        while (n <= lastUnlockedBall)
//        {


//            if (string.Format("{0}(Clone)", colorChangingPrefabList[n].name) == nameOfCurrentObeject || colorChangingPrefabList[n] != null)
//            {
//                //this is code for repawning the ball right after launching it ! 

//                cloneInitialColor = Instantiate(colorChangingPrefabList[n], new Vector3(1.0f, 1.05f, -0.383f), Quaternion.identity);

//            }
//            else
//            {         // this is called when the ball hits a target.
//                      //Increase the counter value everytime the ball hits a target.
//                counter[0] += 1;
//                cloneColorChangingPrefabs[0] = Instantiate(colorChangingPrefabList[0], new Vector3(1.0f, 1.05f, -0.383f), Quaternion.identity);


//            }
//            n++;
//        }
//    }

//    IEnumerator Respawn(GameObject rb)
//    {
//        yield return new WaitForSecondsRealtime(2);
        
        
        

//    }
//}
