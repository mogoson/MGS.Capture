/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICameraCapture.cs
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
    public interface ICameraCapture
    {
        event Action<Texture> OnCaptureEvent;

        bool IsCapturing { get; }

        void StartCapture();

        Color32[] GetPixels32();

        void StopCapture();
    }
}