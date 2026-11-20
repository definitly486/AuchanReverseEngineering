package org.opencv.photo;

/* JADX INFO: loaded from: classes3.dex */
public class CalibrateRobertson extends CalibrateCRF {
    private static native void delete(long j);

    private static native int getMaxIter_0(long j);

    private static native long getRadiance_0(long j);

    private static native float getThreshold_0(long j);

    private static native void setMaxIter_0(long j, int i);

    private static native void setThreshold_0(long j, float f);

    @Override // org.opencv.photo.CalibrateCRF, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
