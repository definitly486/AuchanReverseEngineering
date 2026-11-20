package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat;

import android.hardware.camera2.CameraCaptureSession;
import android.hardware.camera2.CaptureRequest;
import java.util.List;
import java.util.concurrent.Executor;

/* JADX INFO: loaded from: classes.dex */
class CameraCaptureSessionCompatApi28Impl extends CameraCaptureSessionCompatBaseImpl {
    CameraCaptureSessionCompatApi28Impl(CameraCaptureSession cameraCaptureSession) {
        super(cameraCaptureSession, null);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraCaptureSessionCompatBaseImpl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraCaptureSessionCompat.CameraCaptureSessionCompatImpl
    public int captureBurstRequests(List list, Executor executor, CameraCaptureSession.CaptureCallback captureCallback) {
        return this.mCameraCaptureSession.captureBurstRequests(list, executor, captureCallback);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraCaptureSessionCompatBaseImpl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraCaptureSessionCompat.CameraCaptureSessionCompatImpl
    public int setSingleRepeatingRequest(CaptureRequest captureRequest, Executor executor, CameraCaptureSession.CaptureCallback captureCallback) {
        return this.mCameraCaptureSession.setSingleRepeatingRequest(captureRequest, executor, captureCallback);
    }
}
