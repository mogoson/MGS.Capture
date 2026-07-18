/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CameraCapture.cs
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
    public abstract class CameraCapture : MonoBehaviour, ICameraCapture
    {
        public abstract event Action<Texture> OnCaptureEvent;

        public abstract bool IsCapturing { get; }

        public abstract void StartCapture();

        public abstract Color32[] GetPixels32();

        public abstract void StopCapture();
    }
}