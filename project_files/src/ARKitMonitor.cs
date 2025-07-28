using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using VNyanInterface;
using Unity.Profiling;
using System.Collections.Generic;
using System.Text;

namespace ARKitMonitor
{
    class ARKitMonitorManifest : IVNyanPluginManifest
    {
        public string PluginName { get; } = "ARKit Monitor";
        public string Version { get; } = "1.2";
        public string Title { get; } = "ARKit Blendshape Monitor";
        public string Author { get; } = "lunazera";
        public string Website { get; } = "https://github.com/Lunazera/VNyan-Blendshape-Snapshot";
        public void InitializePlugin()
        {
        }
    }

    public class ARKitMonitorPlugin : MonoBehaviour
    {
        private static Dictionary<string, float> CurrentBlendshapes;

        public float threshold = 30;
        public static string parameterNameThreshold = "LZMonitor_Threshold";

        public float pauseFlag = 0;
        public static string parameterNamepauseFlag = "LZMonitor_pause";

        public float continuousFlag = 0;
        public static string parameterNamecontinuousFlag = "LZMonitor_runcontinuous";

        private string parameterNameOutputText = "LZMonitor_Blendshapes";

        public static List<StringBuilder> listBlendshapes()
        {
            List<StringBuilder> blendshapeStrings = new List<StringBuilder>();
            blendshapeStrings.Add(new StringBuilder());
            blendshapeStrings.Add(new StringBuilder());
            blendshapeStrings.Add(new StringBuilder());
            blendshapeStrings.Add(new StringBuilder());
            blendshapeStrings.Add(new StringBuilder());

            float currentThreshold = VNyanInterface.VNyanInterface.VNyanParameter.getVNyanParameterFloat(parameterNameThreshold);
            int blendIndex = 0;
            int blendIndexOffset = 0;
            
            string[] ARKit_Blendshapes = new string[] { "BrowDownLeft", "BrowDownRight", "BrowInnerUp", "BrowOuterUpLeft", "BrowOuterUpRight", "CheekPuff", "CheekSquintLeft", "CheekSquintRight", "EyeBlinkLeft", "EyeBlinkRight", "EyeLookDownLeft", "EyeLookDownRight", "EyeLookInLeft", "EyeLookInRight", "EyeLookOutLeft", "EyeLookOutRight", "EyeLookUpLeft", "EyeLookUpRight", "EyeSquintLeft", "EyeSquintRight", "EyeWideLeft", "EyeWideRight", "JawForward", "JawLeft", "JawOpen", "JawRight", "MouthClose", "MouthDimpleLeft", "MouthDimpleRight", "MouthFrownLeft", "MouthFrownRight", "MouthFunnel", "MouthLeft", "MouthLowerDownLeft", "MouthLowerDownRight", "MouthPressLeft", "MouthPressRight", "MouthPucker", "MouthRight", "MouthRollLower", "MouthRollUpper", "MouthShrugLower", "MouthShrugUpper", "MouthSmileLeft", "MouthSmileRight", "MouthStretchLeft", "MouthStretchRight", "MouthUpperUpLeft", "MouthUpperUpRight", "NoseSneerLeft", "NoseSneerRight", "TongueOut" };
            
            foreach (string blendshape in ARKit_Blendshapes)
            {
                if (CurrentBlendshapes.ContainsKey(blendshape))
                {
                    blendIndex++;
                    if (blendIndex <= 26)
                    {
                        blendIndexOffset = 0;
                    }
                    else
                    {
                        blendIndexOffset = 2;
                    }

                    float shapeValue = CurrentBlendshapes[blendshape] * 100;
                    if (shapeValue >= currentThreshold)
                    {
                        blendshapeStrings[0 + blendIndexOffset].AppendLine(">" + blendshape + ": ");
                        blendshapeStrings[4].Append(blendshape + ";");
                    }
                    else
                    {
                        blendshapeStrings[0 + blendIndexOffset].AppendLine(blendshape + ": ");
                    }
                    blendshapeStrings[1 + blendIndexOffset].AppendLine(shapeValue.ToString("0.0"));
                }
            }

            return blendshapeStrings;
        }

        void Awake()
        {
            CurrentBlendshapes = VNyanInterface.VNyanInterface.VNyanAvatar.getBlendshapesInstant();
            VNyanInterface.VNyanInterface.VNyanParameter.setVNyanParameterFloat(parameterNameThreshold, threshold);
            VNyanInterface.VNyanInterface.VNyanParameter.setVNyanParameterFloat(parameterNamepauseFlag, 0);
            VNyanInterface.VNyanInterface.VNyanParameter.setVNyanParameterFloat(parameterNamecontinuousFlag, 0);
        }

        void Update()
        {
            threshold = VNyanInterface.VNyanInterface.VNyanParameter.getVNyanParameterFloat(parameterNameThreshold);
            pauseFlag = VNyanInterface.VNyanInterface.VNyanParameter.getVNyanParameterFloat(parameterNamepauseFlag);
            continuousFlag = VNyanInterface.VNyanInterface.VNyanParameter.getVNyanParameterFloat(parameterNamecontinuousFlag);

            if (pauseFlag == 0)
            {
                CurrentBlendshapes = VNyanInterface.VNyanInterface.VNyanAvatar.getBlendshapesInstant();
            }

            if (continuousFlag == 1 )
            {
                VNyanInterface.VNyanInterface.VNyanParameter.setVNyanParameterString(parameterNameOutputText, listBlendshapes()[4].ToString());
            }
        }
    }
}
