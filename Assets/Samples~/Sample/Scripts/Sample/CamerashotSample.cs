/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CamerashotSample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/10/15
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using MGS.IOUtility;
using UnityEngine;

namespace MGS.Capture.Sample
{
    [AddComponentMenu("MGS/Capture/Sample/Camerashot Sample")]
    public class CamerashotSample : MonoBehaviour
    {
        public Camera cam;

        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();

            var tex = CaptureUtility.Camerashot(cam);
            var bytes = tex.EncodeToPNG();

            var file = $"{Application.dataPath}/Camerashot.png";
            FileUtility.WriteAllBytes(file, bytes);
            Debug.Log($"Capture is saved to {file}");
        }
    }
}