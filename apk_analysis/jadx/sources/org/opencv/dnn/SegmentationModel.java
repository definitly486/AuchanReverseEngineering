package org.opencv.dnn;

/* JADX INFO: loaded from: classes3.dex */
public class SegmentationModel extends Model {
    private static native long SegmentationModel_0(String str, String str2);

    private static native long SegmentationModel_1(String str);

    private static native long SegmentationModel_2(long j);

    private static native void delete(long j);

    private static native void segment_0(long j, long j2, long j3);

    @Override // org.opencv.dnn.Model
    protected void finalize() {
        delete(this.nativeObj);
    }
}
