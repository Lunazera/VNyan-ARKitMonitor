using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.EventSystems;

namespace LZUI
{
    class LZ_CloseButton : MonoBehaviour
    {
        public GameObject windowPrefab;
        private Button closeButton;

        public void Start()
        {
            closeButton = GetComponent(typeof(Button)) as Button;
            closeButton.onClick.AddListener(delegate { CloseButtonClicked(); });
        }

        public void CloseButtonClicked()
        {
            this.windowPrefab.SetActive(false);
        }
    }
}
