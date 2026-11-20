package org.opencv.dnn;

/* JADX INFO: loaded from: classes3.dex */
public class TextDetectionModel extends Model {
    private static native void delete(long j);

    private static native void detectTextRectangles_0(long j, long j2, long j3, long j4);

    private static native void detectTextRectangles_1(long j, long j2, long j3);

    private static native void detect_0(long j, long j2, long j3, long j4);

    private static native void detect_1(long j, long j2, long j3);

    @Override // org.opencv.dnn.Model
    protected void finalize() {
        delete(this.nativeObj);
    }
}
