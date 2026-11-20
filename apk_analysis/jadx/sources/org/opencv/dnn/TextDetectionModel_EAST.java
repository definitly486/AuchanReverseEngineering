package org.opencv.dnn;

/* JADX INFO: loaded from: classes3.dex */
public class TextDetectionModel_EAST extends TextDetectionModel {
    private static native long TextDetectionModel_EAST_0(long j);

    private static native long TextDetectionModel_EAST_1(String str, String str2);

    private static native long TextDetectionModel_EAST_2(String str);

    private static native void delete(long j);

    private static native float getConfidenceThreshold_0(long j);

    private static native float getNMSThreshold_0(long j);

    private static native long setConfidenceThreshold_0(long j, float f);

    private static native long setNMSThreshold_0(long j, float f);

    @Override // org.opencv.dnn.TextDetectionModel, org.opencv.dnn.Model
    protected void finalize() {
        delete(this.nativeObj);
    }
}
