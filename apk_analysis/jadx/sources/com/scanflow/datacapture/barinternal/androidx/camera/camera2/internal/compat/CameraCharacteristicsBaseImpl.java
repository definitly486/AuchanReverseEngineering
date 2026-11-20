package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat;

import android.hardware.camera2.CameraCharacteristics;
import java.util.Collections;
import java.util.Set;

/* JADX INFO: loaded from: classes.dex */
class CameraCharacteristicsBaseImpl implements CameraCharacteristicsCompat.CameraCharacteristicsCompatImpl {
    protected final CameraCharacteristics mCameraCharacteristics;

    CameraCharacteristicsBaseImpl(CameraCharacteristics cameraCharacteristics) {
        this.mCameraCharacteristics = cameraCharacteristics;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraCharacteristicsCompat.CameraCharacteristicsCompatImpl
    public Object get(CameraCharacteristics.Key key) {
        return this.mCameraCharacteristics.get(key);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraCharacteristicsCompat.CameraCharacteristicsCompatImpl
    public Set getPhysicalCameraIds() {
        return Collections.EMPTY_SET;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraCharacteristicsCompat.CameraCharacteristicsCompatImpl
    public CameraCharacteristics unwrap() {
        return this.mCameraCharacteristics;
    }
}
