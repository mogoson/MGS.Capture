/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  WebCameraCapture.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/18/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.Capture
{
    [AddComponentMenu("MGS/Capture/Web Camera Capture")]
    public class WebCameraCapture : CameraCapture
    {
        public string deviceName;
        public int requestedWidth = 1024;
        public int requestedHeight = 1024;
        protected WebCamTexture camTexture;

        public override event Action<Texture> OnCaptureEvent;

        public override bool IsCapturing
        {
            get { return camTexture != null && camTexture.isPlaying; }
        }

        protected virtual void OnDestroy()
        {
            StopCapture();
        }

        public override void StartCapture()
        {
            if (IsCapturing)
            {
                return;
            }
            camTexture = new WebCamTexture(deviceName, requestedWidth, requestedHeight);
            camTexture.Play();
            OnCaptureEvent?.Invoke(camTexture);
        }

        public override Color32[] GetPixels32()
        {
            if (!IsCapturing)
            {
                return null;
            }
            return camTexture.GetPixels32();
        }

        public override void StopCapture()
        {
            if (!IsCapturing)
            {
                return;
            }
            camTexture.Stop();
            camTexture = null;
        }
    }
}