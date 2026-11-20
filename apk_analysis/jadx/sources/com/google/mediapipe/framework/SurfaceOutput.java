package com.google.mediapipe.framework;

/* JADX INFO: loaded from: classes3.dex */
public class SurfaceOutput {
    private Graph mediapipeGraph;
    private Packet surfaceHolderPacket;

    private native void nativeSetEglSurface(long j, long j2, long j3);

    private native void nativeSetFlipY(long j, boolean z);

    private native void nativeSetSurface(long j, long j2, Object obj);

    private native void nativeSetUpdatePresentationTime(long j, boolean z);

    SurfaceOutput(Graph graph, Packet packet) {
        this.mediapipeGraph = graph;
        this.surfaceHolderPacket = packet;
    }

    public void setFlipY(boolean z) {
        nativeSetFlipY(this.surfaceHolderPacket.getNativeHandle(), z);
    }

    public void setUpdatePresentationTime(boolean z) {
        nativeSetUpdatePresentationTime(this.surfaceHolderPacket.getNativeHandle(), z);
    }

    public void setSurface(Object obj) {
        nativeSetSurface(this.mediapipeGraph.getNativeHandle(), this.surfaceHolderPacket.getNativeHandle(), obj);
    }

    public void setEglSurface(long j) {
        nativeSetEglSurface(this.mediapipeGraph.getNativeHandle(), this.surfaceHolderPacket.getNativeHandle(), j);
    }
}
