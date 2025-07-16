using System;
using UnityEngine;
using UnityEngine.UI;
using VNyanInterface;

namespace LZUI
{
    class LZ_InputField : MonoBehaviour
    {
        // Adapted from Sjatar's UI code
        // This input field is tied to a particular bone in our dictionary
        // We will allow to set the bone number its linked to and the default value.
        public string fieldName;
        private float fieldValue = 0;
        private InputField mainField;
        private Button mainButton;
        private Text mainText;
        private Text mainButtonText;

        public void Awake()
        {
            // We add the inputfield as the mainfield
            mainField = GetComponent(typeof(InputField)) as InputField;
            // We add a button as confirmation to change the inputted value
            mainButton = GetComponentInChildren(typeof(Button)) as Button;
            mainText = GetComponentInChildren<Text>();
            mainButtonText = mainButton.GetComponentInChildren<Text>();

            changeThemeSettings();

            // We add a listener that will run ButtonPressCheck if the button is pressed.
            mainButton.onClick.AddListener(delegate { ButtonPressCheck(); });
            fieldValue = VNyanInterface.VNyanInterface.VNyanParameter.getVNyanParameterFloat(fieldName);
            mainField.text = Convert.ToString(fieldValue);
        }

        public void changeThemeSettings()
        {
            // Set UI Colors
            mainText.GetComponentInChildren<Text>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Text));
            mainButton.GetComponent<Image>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Button));
            mainButtonText.GetComponent<Text>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.ButtonText));
        }

        public void ButtonPressCheck()
        {
            // We need to sanitate the input a bit. Unless the input can be converted to a float we can't use it.
            if (float.TryParse(mainField.text, out float fieldValue))
            {
                VNyanInterface.VNyanInterface.VNyanParameter.setVNyanParameterFloat(fieldName, fieldValue);
            }
            else
            {
                mainField.text = VNyanInterface.VNyanInterface.VNyanParameter.getVNyanParameterString(fieldName);
            }
        }
    }
}
