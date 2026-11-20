package org.opencv.photo;

/* JADX INFO: loaded from: classes3.dex */
public class CalibrateDebevec extends CalibrateCRF {
    private static native void delete(long j);

    private static native float getLambda_0(long j);

    private static native boolean getRandom_0(long j);

    private static native int getSamples_0(long j);

    private static native void setLambda_0(long j, float f);

    private static native void setRandom_0(long j, boolean z);

    private static native void setSamples_0(long j, int i);

    @Override // org.opencv.photo.CalibrateCRF, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
