/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ScreenshotSample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/10/15
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using MGS.IO;
using UnityEngine;

namespace MGS.Capture.Sample
{
    [AddComponentMenu("MGS/Capture/Sample/Screenshot Sample")]
    public class ScreenshotSample : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();

            var tex = CaptureUtility.Screenshot();
            var bytes = tex.EncodeToPNG();

            var file = $"{Application.dataPath}/Screenshot.png";
            FileUtility.WriteAllBytes(file, bytes);
            Debug.Log($"Capture is saved to {file}");
        }
    }
}