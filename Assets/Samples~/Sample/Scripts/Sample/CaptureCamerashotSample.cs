/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CaptureCamerashotSample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/10/15
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using System.IO;
using UnityEngine;

namespace MGS.Capture.Sample
{
    public class CaptureCamerashotSample : MonoBehaviour
    {
        public Camera cam;

        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();

            var tex = CaptureUtility.CaptureCamerashot(cam);
            var bytes = tex.EncodeToPNG();

            var file = $"{Application.dataPath}/Camerashot.png";
            File.WriteAllBytes(file, bytes);
            Debug.Log($"Capture is saved to {file}");
        }
    }
}