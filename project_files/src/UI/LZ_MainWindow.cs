using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VNyanInterface;

// modified from Sjatar's UI code example for VNyan Plugin UI's: https://github.com/Sjatar/Screen-Light

namespace LZUI
{
    class LZ_MainWindow : MonoBehaviour, IDragHandler, IPointerDownHandler
    {
        public GameObject BackgroundObject;
        public GameObject Title;
        public GameObject version;
        private RectTransform mainRect;

        void Start()
        {
            // Set Text
            Title.GetComponent<Text>().text = LZ_UI.pluginTitle();
            version.GetComponent<Text>().text = LZ_UI.pluginVersion() + " - " + LZ_UI.pluginAuthor();
            
            mainRect = GetComponent(typeof(RectTransform)) as RectTransform;

            changeThemeSettings();
            VNyanInterface.VNyanInterface.VNyanUI.colorThemeChanged += changeThemeSettings;
        }
        public void changeThemeSettings()
        {
            // Set UI Colors from VNyan
            BackgroundObject.GetComponent<Image>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Panel));
            BackgroundObject.GetComponent<Outline>().effectColor = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Borders));
            Title.GetComponent<Text>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Text));
            version.GetComponent<Text>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Text));
        }

        public void OnDrag(PointerEventData eventData)
        {
            // When user clicks and drags. The mouse delta position is added to the transform component.
            // This makes the window follow the mouse exactly!
            mainRect.anchoredPosition += eventData.delta;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            // When the user clicks the window we want it to appear in front of all other windows.
            // We therefor want it to render last. The last sibling renders last! 
            mainRect.SetAsLastSibling();
        }
    }
}
