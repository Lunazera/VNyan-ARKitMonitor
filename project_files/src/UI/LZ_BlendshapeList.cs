using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VNyanInterface;

namespace LZUI
{
    class LZ_BlendshapeList : MonoBehaviour
    {
        // Text for Unity
        public Text Blendshapes_Col1;
        public Text Blendshapes_Col2;
        public Text Blendshapes_Col3;
        public Text Blendshapes_Col4;

        public InputField Blendshapes_Selectable;

        private List<StringBuilder> listBlendshapes = new List<StringBuilder>();
        private StringBuilder stringlargeBlendshapes = new StringBuilder();

        void Awake()
        {
            changeThemeSettings();
        }

        void Update()
        {
            listBlendshapes = ARKitMonitor.ARKitMonitorPlugin.listBlendshapes();

            Blendshapes_Col1.text = listBlendshapes[0].ToString();
            Blendshapes_Col2.text = listBlendshapes[1].ToString();
            Blendshapes_Col3.text = listBlendshapes[2].ToString();
            Blendshapes_Col4.text = listBlendshapes[3].ToString();

            Blendshapes_Selectable.text = listBlendshapes[4].ToString();
        }

        public void changeThemeSettings()
        {
            Blendshapes_Col1.GetComponent<Text>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Text));
            Blendshapes_Col2.GetComponent<Text>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Text));
            Blendshapes_Col3.GetComponent<Text>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Text));
            Blendshapes_Col4.GetComponent<Text>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Text));
        }
    }
}
