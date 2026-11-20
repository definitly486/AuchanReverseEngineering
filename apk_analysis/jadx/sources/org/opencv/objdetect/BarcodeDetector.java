package org.opencv.objdetect;

import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class BarcodeDetector extends GraphicalCodeDetector {
    private static native long BarcodeDetector_0();

    private static native long BarcodeDetector_1(String str, String str2);

    private static native boolean decodeWithType_0(long j, long j2, long j3, List<String> list, List<String> list2);

    private static native void delete(long j);

    private static native boolean detectAndDecodeWithType_0(long j, long j2, List<String> list, List<String> list2, long j3);

    private static native boolean detectAndDecodeWithType_1(long j, long j2, List<String> list, List<String> list2);

    private static native void getDetectorScales_0(long j, long j2);

    private static native double getDownsamplingThreshold_0(long j);

    private static native double getGradientThreshold_0(long j);

    private static native long setDetectorScales_0(long j, long j2);

    private static native long setDownsamplingThreshold_0(long j, double d);

    private static native long setGradientThreshold_0(long j, double d);

    @Override // org.opencv.objdetect.GraphicalCodeDetector
    protected void finalize() {
        delete(this.nativeObj);
    }
}
