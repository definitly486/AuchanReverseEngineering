package org.opencv.photo;

/* JADX INFO: loaded from: classes3.dex */
public class TonemapDrago extends Tonemap {
    private static native void delete(long j);

    private static native float getBias_0(long j);

    private static native float getSaturation_0(long j);

    private static native void setBias_0(long j, float f);

    private static native void setSaturation_0(long j, float f);

    @Override // org.opencv.photo.Tonemap, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
