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
        public GameObject HoverMenu;
        public SteamVR_LaserPointer laserPointer;
        
        public GameObject MusicExitMenu;
        [SerializeField]
        public SteamVR_Action_Boolean buttonB = SteamVR_Input.GetBooleanAction("ButtonB");
        public SteamVR_Action_Boolean HoverBUttonB = SteamVR_Input.GetBooleanAction("HoverB");
        public Button[] Colorbuttons;
        public Button[] AudioButtons;
        public AudioSource BackGroundMusic;
        public AudioSource song1;
        public AudioSource song2;
        public AudioSource song3;
        private bool isSecondLevel = false;
        private int[] counterArray = new int[5];
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





            //disable the buttons initially
            //this is for red button
            for (int i =1; i<=5 ; i++)
            {
                Colorbuttons[i].interactable = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            
            bool isButtonBPressed = buttonB.GetState(SteamVR_Input_Sources.LeftHand);
            bool isHoverBButton = HoverBUttonB.GetState(SteamVR_Input_Sources.LeftHand);
            if (isHoverBButton == true)
            {
                HoverMenu.SetActive(true);
            }
            else
            {
                HoverMenu.SetActive(false);
            }
            if (isButtonBPressed == true && isSecondLevel == false)
            {
           
                MainMenu.SetActive(true);
                
            }
            RewardingSystem();

        }

        public void OpenMusicMenu()
        {
           // MusicManager.SetActive(true);
            MainMenu.SetActive(false);
            isSecondLevel = true;
            MusicMenu.SetActive(true);
           
        }
      
        private void RewardingSystem()
        {
            int n = 0;
           while(n <= lastBallUnlocked && n < 5)
            { 
                if (counterArray[lastBallUnlocked] >= 2)
                {

                    lastBallUnlocked++;
                    Colorbuttons[lastBallUnlocked].interactable = true;
                    Debug.Log("Current Menu Unlocked"+ Colorbuttons[lastBallUnlocked]);
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
            ColorSelected( 0 , 1 , 0);
            MainMenu.SetActive(false);
            LevelColorMenu.SetActive(false);

        }
        public void RedColor()
        {
            ColorSelected(1, 0, 0);
            MainMenu.SetActive(false);
            LevelColorMenu.SetActive(false);
        }

        public void BlueColor()
        {
            
            ColorSelected(0, 0, 1);
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
        public void ExitMusicMenu()
        {
            // MusicManager.SetActive(false);
            MainMenu.SetActive(true);
            isSecondLevel = false;
            MusicMenu.SetActive(false);

        }
        public void defaultMusicMenu()
        {
            
            song2.Stop();
            song3.Stop();
            song1.Stop();
            BackGroundMusic.loop = true;
        }
        public void yellowOrange()
        {
            //r=1
            //g=.67
            //b=.2
            ColorSelected(1, .67f, .2f);
            MainMenu.SetActive(false);
            LevelColorMenu.SetActive(false);

        }
        public void Pink()
        {
            //r=1
            //g=.67
            //b=.2
            ColorSelected(0.57f, .38f, 1f);
            MainMenu.SetActive(false);
            LevelColorMenu.SetActive(false);

        }
        private void ColorSelected(float r, float g , float b)
        {
            isSecondLevel = false;
            laserPointer.color = new Color(r, g, b);

        }

        public void GreenCounter()
        {

            counterArray[0]++;
        }
        public void redCounter()
        {
            //0 is red
            //Debug.Log("Yes");
            counterArray[1]++;
        }
        public void BlueCounter()
        {
            counterArray[2]++;
        }

        public void YellowOrangeCounter()
        {
            counterArray[3]++;
        }
        public void PinkCounter()
        {
            counterArray[4]++;
        }
        public void PlaySong1()
        {
            StopSongAndExit();
            song2.Stop();
            song3.Stop();
            song1.Play();
            song1.loop= true;
            
        }
        public void PlaySong2()
        {
            StopSongAndExit();
            song1.Stop();
            song3.Stop();
            song2.Play();
            song2.loop = true;
        }
        public void PlaySong3()
        {
            StopSongAndExit();
            song2.Stop();
            song1.Stop();
            song3.Play();
            song3.loop = true;
           
        }
        private void StopSongAndExit()
        {
           // BackGroundMusic.Stop();
            MusicMenu.SetActive(false);
            MainMenu.SetActive(false);
            isSecondLevel = false;
        }

    }
}