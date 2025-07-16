using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LZUI
{
    class LZ_Button : MonoBehaviour
    {
        private Button mainButton;
        private float buttonState;
        public string buttonName;

        public void Start()
        {
            mainButton = GetComponent(typeof(Button)) as Button;
            mainButton.onClick.AddListener(delegate { ButtonPressCheck(); });

            // Start button off
            buttonState = 0f;
            VNyanInterface.VNyanInterface.VNyanParameter.setVNyanParameterFloat(buttonName, buttonState);
            ChangeButtonColor(false);
        }

        public void ChangeButtonColor(bool boolbuttonState)
        {
            // If the input is true make it green
            if (boolbuttonState)
            {
                ColorBlock cb = mainButton.colors;
                cb.normalColor = new Color(0.5f, 1f, 0.5f);
                cb.highlightedColor = new Color(0.5f, 0.9f, 0.5f);
                cb.pressedColor = new Color(0.4f, 0.8f, 0.4f);
                cb.selectedColor = new Color(0.5f, 1f, 0.5f);
                mainButton.colors = cb;
            }
            // Else make it red! 
            else
            {
                ColorBlock cb = mainButton.colors;
                cb.normalColor = new Color(1f, 0.5f, 0.5f);
                cb.highlightedColor = new Color(0.9f, 0.5f, 0.5f);
                cb.pressedColor = new Color(0.8f, 0.4f, 0.4f);
                cb.selectedColor = new Color(1f, 0.5f, 0.5f);
                mainButton.colors = cb;
            }
        }

        public void ButtonPressCheck()
        {
            {
                // If button state was off, run on part of script
                if (buttonState == 0f)
                {
                    buttonState = 1f;
                    VNyanInterface.VNyanInterface.VNyanParameter.setVNyanParameterFloat(buttonName, buttonState);
                    ChangeButtonColor(true);
                }
                // If the button was not off, run off part of the script!
                else
                {
                    buttonState = 0f;
                    VNyanInterface.VNyanInterface.VNyanParameter.setVNyanParameterFloat(buttonName, buttonState);
                    ChangeButtonColor(false);
                }
            }
            
        }
    }
}
