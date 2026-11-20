package org.opencv.photo;

/* JADX INFO: loaded from: classes3.dex */
public class TonemapReinhard extends Tonemap {
    private static native void delete(long j);

    private static native float getColorAdaptation_0(long j);

    private static native float getIntensity_0(long j);

    private static native float getLightAdaptation_0(long j);

    private static native void setColorAdaptation_0(long j, float f);

    private static native void setIntensity_0(long j, float f);

    private static native void setLightAdaptation_0(long j, float f);

    @Override // org.opencv.photo.Tonemap, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
