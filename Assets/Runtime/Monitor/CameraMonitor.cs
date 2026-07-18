/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CameraMonitor.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/18/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.Capture
{
    [AddComponentMenu("MGS/Capture/Camera Monitor")]
    [RequireComponent(typeof(RawImage))]
    public class CameraMonitor : MonoBehaviour, ICameraMonitor
    {
        public RawImage image;
        public CameraCapture capture;

        public bool IsCapturing { get { return capture.IsCapturing; } }

        protected virtual void Reset()
        {
            image = GetComponent<RawImage>();
        }

        protected virtual void Start()
        {
            StartCapture();
        }

        protected virtual void OnDestroy()
        {
            StopCapture();
        }

        public void StartCapture()
        {
            capture.OnCaptureEvent -= OnCapture;
            capture.OnCaptureEvent += OnCapture;
            capture.StartCapture();
        }

        public void StopCapture()
        {
            capture.OnCaptureEvent -= OnCapture;
            capture.StopCapture();
        }

        protected virtual void OnCapture(Texture texture)
        {
            image.texture = texture;
        }
    }
}