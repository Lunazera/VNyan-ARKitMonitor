using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using VNyanInterface;
using System;

// UI Core
// modified from Sjatar's UI code example for VNyan Plugin UI's: https://github.com/Sjatar/Screen-Light
// This plugin makes use of Sja_MainWindow, Sja_InputField, and Sja_SaveButton from Sjatar's code
// Added code is in LZ_CloseButton and LZ_TextField

namespace BlendshapeSnapshot
{
    // VNyanInterface.IButtonClickHandler gives access to pluginButtonClicked
    public class Sja_UICore : MonoBehaviour, VNyanInterface.IButtonClickedHandler
    {
        // We create a window object to add the window prefab (with the UI) to when plugin button in VNyan is pressed
        // note: not sure if this *actually* creates a new parent gameobject window or not?
        public GameObject windowPrefab;
        private GameObject window;

        public string setting_name;
        public string plugin_name;

        private float KeyValue;

        // We want to keep track of our VNyanParameters somewhere. This Dictionary makes it easier.
        // Each button, slider and input field will automatically add to this depending on it's name!
        // This dictionary is also used to save and load.
        // At Awake, we look to see if the setting file exists. If it does we load it into the dictionary.
        // Before a button etc adds a new parameter it will look to see if it already exists.
        // If it does exist it will set it's value to the dictionary value and not add anything.
        public static Dictionary<string, string> VNyanParameters = new Dictionary<string, string>();

        // This happens when VNyan starts.
        public void Awake()
        {
            // If the setting file exists. Load it into the dictionary! If the user clicks the save button,
            // this settings file will update with new values.

            if (null != VNyanInterface.VNyanInterface.VNyanSettings.loadSettings(setting_name))
            {
                // This loads a dictionary from a file named settings_name.
                // Each slider/button/field will load their own parameter into VNyans parameters on load!
                // So there is no need to also add each value in the dictionary to VNyan here.
                VNyanParameters = VNyanInterface.VNyanInterface.VNyanSettings.loadSettings(setting_name);
            }

            // VNyan magic to add a plugin button to it's interface!
            VNyanInterface.VNyanInterface.VNyanUI.registerPluginButton(plugin_name, (IButtonClickedHandler)this);
            this.window = (GameObject)VNyanInterface.VNyanInterface.VNyanUI.instantiateUIPrefab((object)this.windowPrefab);
            if ((UnityEngine.Object)this.window != (UnityEngine.Object)null)
            {
                this.window.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
                this.window.SetActive(false);
            }
        }

        public void pluginButtonClicked()
        {
            if ((UnityEngine.Object)this.window == (UnityEngine.Object)null)
                return;
            this.window.SetActive(!this.window.activeSelf);
            if (!this.window.activeSelf)
                return;
            this.window.transform.SetAsLastSibling();
        }
    }
}
