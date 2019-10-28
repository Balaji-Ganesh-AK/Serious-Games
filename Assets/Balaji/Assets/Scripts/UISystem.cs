using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem
{
    public class UISystem : MonoBehaviour
    {

        public GameObject MainMenu;
        public GameObject LevelColorMenu;
        public SteamVR_LaserPointer laserPointer;
        [SerializeField]
        public SteamVR_Action_Boolean buttonB = SteamVR_Input.GetBooleanAction("ButtonB");

        public Button[] buttons;

        private int[] counterArray = new int[3];
        //0 is green
        //1 is red
        //2 is blue

        private int lastBallUnlocked = 0;

        // Start is called before the first frame update
        void Start()
        {
            //disable the buttons initially
            //this is for red button
            buttons[1].interactable = false;
            //this is for blue button
            buttons[2].interactable = false;
        }

        // Update is called once per frame
        void Update()
        {
            
            bool isButtonBPressed = buttonB.GetState(SteamVR_Input_Sources.LeftHand);
            if (isButtonBPressed == true)
            {
                MainMenu.SetActive(true);
            }
            RewardingSystem();

        }

        private void RewardingSystem()
        {
            int n = 0;
           while(n <= lastBallUnlocked && n < 3)
            { 
                if (counterArray[lastBallUnlocked] >= 2)
                {
                    Debug.Log("Unlock the next color!");
                    lastBallUnlocked++;
                    buttons[lastBallUnlocked].interactable = true;
                    
                }
                n++;    
            }
        }
        public void OpenColorMenu()
        {
            MainMenu.SetActive(false);
            LevelColorMenu.SetActive(true);

        }
        public void GreenColor()
        {
            ColorSelected( 0 , 255 , 0);
            MainMenu.SetActive(false);
            LevelColorMenu.SetActive(false);

        }
        public void RedColor()
        {
            ColorSelected(255, 0, 0);
            MainMenu.SetActive(false);
            LevelColorMenu.SetActive(false);
        }

        public void BlueColor()
        {
            
            ColorSelected(0, 0, 255);
            MainMenu.SetActive(false);
            LevelColorMenu.SetActive(false);
        }
        public void Exit()
        {
            MainMenu.SetActive(true);
            LevelColorMenu.SetActive(false);
        }
        public void ExitMainMenu()
        {
            MainMenu.SetActive(false);
        }
        private void ColorSelected(float r, float g , float b)
        {
            
            laserPointer.color = new Color(r, g, b);
        }

        public void GreenCounter()
        {

            counterArray[0]++;
        }
        public void redCounter()
        {
            //0 is red
            
            counterArray[1]++;
        }
        public void BlueCounter()
        {
            counterArray[2]++;
        }
       


    }
}