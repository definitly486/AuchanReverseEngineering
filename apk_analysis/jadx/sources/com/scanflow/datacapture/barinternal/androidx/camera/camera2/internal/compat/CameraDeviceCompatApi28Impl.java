package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat;

import android.hardware.camera2.CameraAccessException;
import android.hardware.camera2.CameraDevice;
import android.hardware.camera2.params.SessionConfiguration;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.SessionConfigurationCompat;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;

/* JADX INFO: loaded from: classes.dex */
class CameraDeviceCompatApi28Impl extends CameraDeviceCompatApi24Impl {
    CameraDeviceCompatApi28Impl(CameraDevice cameraDevice) {
        super((CameraDevice) Preconditions.checkNotNull(cameraDevice), null);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraDeviceCompatApi24Impl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraDeviceCompat.CameraDeviceCompatImpl
    public void createCaptureSession(SessionConfigurationCompat sessionConfigurationCompat) throws CameraAccessExceptionCompat {
        SessionConfiguration sessionConfiguration = (SessionConfiguration) sessionConfigurationCompat.unwrap();
        Preconditions.checkNotNull(sessionConfiguration);
        try {
            this.mCameraDevice.createCaptureSession(sessionConfiguration);
        } catch (CameraAccessException e) {
            throw CameraAccessExceptionCompat.toCameraAccessExceptionCompat(e);
        }
    }
}
