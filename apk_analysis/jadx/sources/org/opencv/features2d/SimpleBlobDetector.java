package org.opencv.features2d;

/* JADX INFO: loaded from: classes3.dex */
public class SimpleBlobDetector extends Feature2D {
    private static native long create_0(long j);

    private static native long create_1();

    private static native void delete(long j);

    private static native long getBlobContours_0(long j);

    private static native String getDefaultName_0(long j);

    private static native long getParams_0(long j);

    private static native void setParams_0(long j, long j2);

    @Override // org.opencv.features2d.Feature2D, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
