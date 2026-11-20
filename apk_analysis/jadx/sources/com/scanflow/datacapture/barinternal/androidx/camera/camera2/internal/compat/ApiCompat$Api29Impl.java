package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat;

import android.hardware.camera2.CameraManager;

/* JADX INFO: loaded from: classes.dex */
public abstract class ApiCompat$Api29Impl {
    public static void onCameraAccessPrioritiesChanged(CameraManager.AvailabilityCallback availabilityCallback) {
        availabilityCallback.onCameraAccessPrioritiesChanged();
    }
}
