package com.scanflow.datacapture.core.camera;

/* JADX INFO: loaded from: classes3.dex */
public interface ICameraControl {
    void enableTorch(boolean z);

    boolean hasFlashUnit();

    boolean isTorchEnabled();

    void lineZoomIn();

    void lineZoomOut();

    void lineZoomTo(float f);

    void zoomIn();

    void zoomOut();

    void zoomTo(float f);
}
