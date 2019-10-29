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
        public GameObject MusicMenu;
       // public GameObject MusicManager;
        public SteamVR_LaserPointer laserPointer;
        public GameObject PopMenu;
        public GameObject MusicExitMenu;
        [SerializeField]
        public SteamVR_Action_Boolean buttonB = SteamVR_Input.GetBooleanAction("ButtonB");
        public MusicPlayer MusicPlayerScript; 
        public Button[] buttons;
        private bool isSecondLevel = false;
        private int[] counterArray = new int[3];
        //0 is green
        //1 is red
        //2 is blue

        private int lastBallUnlocked = 0;

        // Start is called before the first frame update
        void Start()
        {
            MainMenu.SetActive (false);
            LevelColorMenu.SetActive(false);
            MusicMenu.SetActive(false);
            //MusicManager.SetActive(false);
            MusicExitMenu.SetActive(false);
            MusicPlayerScript.ToggleMusicMenu();

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
            if (isButtonBPressed == true && isSecondLevel == false)
            {
           
                MainMenu.SetActive(true);
                MusicMenu.SetActive(true);
            }
            RewardingSystem();

        }

        public void OpenMusicMenu()
        {
           // MusicManager.SetActive(true);
            MainMenu.SetActive(false);
            isSecondLevel = true;
            MusicExitMenu.SetActive(true);
            MusicPlayerScript.ToggleMusicMenu();
        }
        public void ExitMusicMenu()
        {
           // MusicManager.SetActive(false);
            MainMenu.SetActive(true);
            isSecondLevel = false;
            MusicExitMenu.SetActive(false);
            MusicPlayerScript.ToggleMusicMenu();
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
                    isSecondLevel = false;
                    
                }
                n++;    
            }
        }
        public void OpenColorMenu()
        {
            MainMenu.SetActive(false);
            LevelColorMenu.SetActive(true);
            isSecondLevel = true;

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
            isSecondLevel = false;
        }
        public void ExitMainMenu()
        {
           
            MainMenu.SetActive(false);
            isSecondLevel = false;
        }
        private void ColorSelected(float r, float g , float b)
        {
            isSecondLevel = false;
            laserPointer.color = new Color(r/255f, g/255f, b/255f);

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