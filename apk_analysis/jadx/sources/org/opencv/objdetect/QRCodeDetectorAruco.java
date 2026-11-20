package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class QRCodeDetectorAruco extends GraphicalCodeDetector {
    private static native long QRCodeDetectorAruco_0();

    private static native long QRCodeDetectorAruco_1(long j);

    private static native void delete(long j);

    private static native long getDetectorParameters_0(long j);

    private static native long setDetectorParameters_0(long j, long j2);

    @Override // org.opencv.objdetect.GraphicalCodeDetector
    protected void finalize() {
        delete(this.nativeObj);
    }
}
