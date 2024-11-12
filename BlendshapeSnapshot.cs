using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using VNyanInterface;
using Unity.Profiling;
using System.Collections.Generic;
using System.Text;

// TODO:
// - Add functionality for a pause tracking button
// - Add threshold menu button

namespace BlendshapeSnapshot
{
    public class BlendshapeSnapshot : MonoBehaviour
    {

        // Text for Unity
        public Text Blendshapes_Col1;
        public Text Blendshapes_Col2;
        public Text Blendshapes_Col3;
        public Text Blendshapes_Col4;
        public InputField Blendshapes_Selectable;

        Dictionary<string, float> CurrentBlendshapes;

        public static float threshold = 30;
        public static string parameterNameThreshold = "LZ_blendshape_threshold";

        public static float pauseFlag = 0;
        public static string parameterNamepauseFlag = "LZ_blendshape_pauseFlag";

        public void printBlendshapes(Dictionary<string, float> blendshapeList)
        {
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();
            var sb3 = new StringBuilder();
            var sb4 = new StringBuilder();

            var blend_index = 0;
            string[] ARKit_Blendshapes = new string[] { "BrowDownLeft", "BrowDownRight", "BrowInnerUp", "BrowOuterUpLeft", "BrowOuterUpRight", "CheekPuff", "CheekSquintLeft", "CheekSquintRight", "EyeBlinkLeft", "EyeBlinkRight", "EyeLookDownLeft", "EyeLookDownRight", "EyeLookInLeft", "EyeLookInRight", "EyeLookOutLeft", "EyeLookOutRight", "EyeLookUpLeft", "EyeLookUpRight", "EyeSquintLeft", "EyeSquintRight", "EyeWideLeft", "EyeWideRight", "JawForward", "JawLeft", "JawOpen", "JawRight", "MouthClose", "MouthDimpleLeft", "MouthDimpleRight", "MouthFrownLeft", "MouthFrownRight", "MouthFunnel", "MouthLeft", "MouthLowerDownLeft", "MouthLowerDownRight", "MouthPressLeft", "MouthPressRight", "MouthPucker", "MouthRight", "MouthRollLower", "MouthRollUpper", "MouthShrugLower", "MouthShrugUpper", "MouthSmileLeft", "MouthSmileRight", "MouthStretchLeft", "MouthStretchRight", "MouthUpperUpLeft", "MouthUpperUpRight", "NoseSneerLeft", "NoseSneerRight", "TongueOut" };
            foreach (string blendshape in ARKit_Blendshapes)
            {
                blend_index++;
                if (blend_index <= 26)
                {
                    sb1.AppendLine(blendshape + ": ");
                    sb2.AppendLine((blendshapeList[blendshape] * 100).ToString("0.0"));
                }
                else
                {
                    sb3.AppendLine(blendshape + ": ");
                    sb4.AppendLine((blendshapeList[blendshape] * 100).ToString("0.0"));
                }
            }
            Blendshapes_Col1.text = sb1.ToString();
            Blendshapes_Col2.text = sb2.ToString();
            Blendshapes_Col3.text = sb3.ToString();
            Blendshapes_Col4.text = sb4.ToString();
        }

        public void getLargeBlendshapes(Dictionary<string, float> blendshapeList, float threshold)
        {
            string[] ARKit_Blendshapes = new string[] { "BrowDownLeft", "BrowDownRight", "BrowInnerUp", "BrowOuterUpLeft", "BrowOuterUpRight", "CheekPuff", "CheekSquintLeft", "CheekSquintRight", "EyeBlinkLeft", "EyeBlinkRight", "EyeLookDownLeft", "EyeLookDownRight", "EyeLookInLeft", "EyeLookInRight", "EyeLookOutLeft", "EyeLookOutRight", "EyeLookUpLeft", "EyeLookUpRight", "EyeSquintLeft", "EyeSquintRight", "EyeWideLeft", "EyeWideRight", "JawForward", "JawLeft", "JawOpen", "JawRight", "MouthClose", "MouthDimpleLeft", "MouthDimpleRight", "MouthFrownLeft", "MouthFrownRight", "MouthFunnel", "MouthLeft", "MouthLowerDownLeft", "MouthLowerDownRight", "MouthPressLeft", "MouthPressRight", "MouthPucker", "MouthRight", "MouthRollLower", "MouthRollUpper", "MouthShrugLower", "MouthShrugUpper", "MouthSmileLeft", "MouthSmileRight", "MouthStretchLeft", "MouthStretchRight", "MouthUpperUpLeft", "MouthUpperUpRight", "NoseSneerLeft", "NoseSneerRight", "TongueOut" };
            var sb1 = new StringBuilder();
            foreach (string blendshape in ARKit_Blendshapes)
            {
                float shapeValue = blendshapeList[blendshape] * 100;
                if (shapeValue >= threshold)
                {
                    sb1.Append(blendshape + ";");
                }
            }
            Blendshapes_Selectable.text = sb1.ToString();
        }

        void Update()
        {
            if (pauseFlag == 1)
            {
                CurrentBlendshapes = VNyanInterface.VNyanInterface.VNyanAvatar.getBlendshapesInstant();
            }
            printBlendshapes(CurrentBlendshapes);
            getLargeBlendshapes(CurrentBlendshapes, threshold);
        }
    }
}
