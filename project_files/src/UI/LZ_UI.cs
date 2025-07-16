using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using VNyanInterface;
using System;
using System.Security;

// UI Core
// modified from Sjatar's UI code example for VNyan Plugin UI's: https://github.com/Sjatar/Screen-Light

namespace LZUI
{
    // VNyanInterface.IButtonClickHandler gives access to pluginButtonClicked
    public class LZ_UI : MonoBehaviour, IButtonClickedHandler
    {
        public GameObject windowPrefab;
        private GameObject window;

        static IVNyanPluginManifest manifest = new ARKitMonitor.ARKitMonitorManifest();


        public void Awake()
        {
            VNyanInterface.VNyanInterface.VNyanUI.registerPluginButton(pluginName(), (IButtonClickedHandler)this);
            this.window = (GameObject)VNyanInterface.VNyanInterface.VNyanUI.instantiateUIPrefab((object)this.windowPrefab);
            if ((UnityEngine.Object)this.window != (UnityEngine.Object)null)
            {
                this.window.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
                this.window.SetActive(false);
            }
        }

        public static string pluginName()
        {
            return manifest.PluginName;
        }

        public static string pluginTitle()
        {
            return manifest.Title;
        }

        public static string pluginVersion()
        {
            return manifest.Version;
        }

        public static string pluginAuthor()
        {
            return manifest.Author;
        }

        public void pluginButtonClicked()
        {
            if ((UnityEngine.Object)this.window == (UnityEngine.Object)null)
                return;
            this.window.SetActive(!this.window.activeSelf);
            if ( !this.window.activeSelf )
                return;
            this.window.transform.SetAsLastSibling();
        }

        public static Color hexToColor(string hex)
        {
            hex = hex.Replace("0x", ""); //in case the string is formatted 0xFFFFFF
            hex = hex.Replace("#", ""); //in case the string is formatted #FFFFFF

            byte a = 255; //assume fully visible unless specified in hex
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

            //Only use alpha if the string has enough characters
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            }
            return new Color32(r, g, b, a);
        }
    }
}
