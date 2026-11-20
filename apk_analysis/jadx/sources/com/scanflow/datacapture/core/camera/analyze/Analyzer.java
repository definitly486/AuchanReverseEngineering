package com.scanflow.datacapture.core.camera.analyze;

import androidx.camera.core.Camera;
import androidx.camera.core.ImageProxy;
import com.scanflow.datacapture.core.camera.ScanflowReader;

/* JADX INFO: loaded from: classes3.dex */
public interface Analyzer<T> {

    public interface OnAnalyzeListener {
        void OnOneTouchCallbackCompleted();

        void OnOneTouchCallbackDisable();

        void OnOneTouchCallbackStarted();

        void onFailure();

        void onLicenseFailed(String str);

        void onPerformCaptureScan();

        void onSuccess(String str);
    }

    void analyze(ImageProxy imageProxy, Camera camera, ScanflowReader.CameraUserConfig cameraUserConfig, OnAnalyzeListener onAnalyzeListener, Object obj);
}
