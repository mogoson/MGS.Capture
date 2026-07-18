/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICameraDisplay.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/18/2026
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Capture
{
    public interface ICameraDisplay
    {
        bool IsCapturing { get; }

        void StartCapture();

        void StopCapture();
    }
}