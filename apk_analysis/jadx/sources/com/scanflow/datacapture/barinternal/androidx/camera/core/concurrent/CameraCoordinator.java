package com.scanflow.datacapture.barinternal.androidx.camera.core.concurrent;

/* JADX INFO: loaded from: classes.dex */
public interface CameraCoordinator {

    public interface ConcurrentCameraModeListener {
        void onCameraOperatingModeUpdated(int i, int i2);
    }

    void addListener(ConcurrentCameraModeListener concurrentCameraModeListener);

    int getCameraOperatingMode();

    String getPairedConcurrentCameraId(String str);

    void setCameraOperatingMode(int i);
}
