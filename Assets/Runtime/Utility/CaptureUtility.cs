/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CaptureUtility.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/10/15
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using MGS.IOUtility;
using UnityEngine;

namespace MGS.Capture
{
    public static class CaptureUtility
    {
        public static Texture2D Screenshot()
        {
            /*
            var screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            screenshot.Apply();
            return screenshot;
            */
            return ScreenCapture.CaptureScreenshotAsTexture();
        }

        public static Texture2D Camerashot(Camera camera)
        {
            var renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
            camera.targetTexture = renderTexture;
            camera.Render();

            RenderTexture.active = renderTexture;
            var camerashot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            camerashot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            camerashot.Apply();

            RenderTexture.active = null;
            camera.targetTexture = null;
            UnityEngine.Object.Destroy(renderTexture);

            return camerashot;
        }

        public static Exception Screenshot(string path)
        {
            return SaveAsPNG(Screenshot(), path);
        }

        public static Exception Camerashot(Camera camera, string path)
        {
            return SaveAsPNG(Camerashot(camera), path);
        }

        public static Exception SaveAsPNG(Texture2D texture, string path)
        {
            return FileUtility.WriteAllBytes(path, texture.EncodeToPNG());
        }
    }
}