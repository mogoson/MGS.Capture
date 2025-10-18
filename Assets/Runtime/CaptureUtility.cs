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

using UnityEngine;

namespace MGS.Capture
{
    public sealed class CaptureUtility
    {
        public static Texture2D CaptureScreenshot()
        {
            /*
            var screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            screenshot.Apply();
            return screenshot;
            */
            return ScreenCapture.CaptureScreenshotAsTexture();
        }

        public static Texture2D CaptureScreenshot(int superSize)
        {
            return ScreenCapture.CaptureScreenshotAsTexture(superSize);
        }

        public static Texture2D CaptureCamerashot(Camera camera)
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
            Object.Destroy(renderTexture);

            return camerashot;
        }
    }
}