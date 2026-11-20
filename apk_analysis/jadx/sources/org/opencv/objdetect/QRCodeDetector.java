package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class QRCodeDetector extends GraphicalCodeDetector {
    private static native long QRCodeDetector_0();

    private static native String decodeCurved_0(long j, long j2, long j3, long j4);

    private static native String decodeCurved_1(long j, long j2, long j3);

    private static native void delete(long j);

    private static native String detectAndDecodeCurved_0(long j, long j2, long j3, long j4);

    private static native String detectAndDecodeCurved_1(long j, long j2, long j3);

    private static native String detectAndDecodeCurved_2(long j, long j2);

    private static native int getEncoding_0(long j, int i);

    private static native int getEncoding_1(long j);

    private static native long setEpsX_0(long j, double d);

    private static native long setEpsY_0(long j, double d);

    private static native long setUseAlignmentMarkers_0(long j, boolean z);

    public QRCodeDetector() {
        super(QRCodeDetector_0());
    }

    @Override // org.opencv.objdetect.GraphicalCodeDetector
    protected void finalize() {
        delete(this.nativeObj);
    }
}
