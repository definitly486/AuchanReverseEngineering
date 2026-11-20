package org.opencv.objdetect;

import org.opencv.core.Algorithm;

/* JADX INFO: loaded from: classes3.dex */
public class ArucoDetector extends Algorithm {
    private static native long ArucoDetector_0(long j, long j2, long j3);

    private static native long ArucoDetector_1(long j, long j2);

    private static native long ArucoDetector_2(long j);

    private static native long ArucoDetector_3();

    private static native void delete(long j);

    private static native void detectMarkersMultiDict_0(long j, long j2, long j3, long j4, long j5, long j6);

    private static native void detectMarkersMultiDict_1(long j, long j2, long j3, long j4, long j5);

    private static native void detectMarkersMultiDict_2(long j, long j2, long j3, long j4);

    private static native void detectMarkers_0(long j, long j2, long j3, long j4, long j5);

    private static native void detectMarkers_1(long j, long j2, long j3, long j4);

    private static native long getDetectorParameters_0(long j);

    private static native long getDictionary_0(long j);

    private static native long getRefineParameters_0(long j);

    private static native void refineDetectedMarkers_0(long j, long j2, long j3, long j4, long j5, long j6, long j7, long j8, long j9);

    private static native void refineDetectedMarkers_1(long j, long j2, long j3, long j4, long j5, long j6, long j7, long j8);

    private static native void refineDetectedMarkers_2(long j, long j2, long j3, long j4, long j5, long j6, long j7);

    private static native void refineDetectedMarkers_3(long j, long j2, long j3, long j4, long j5, long j6);

    private static native void setDetectorParameters_0(long j, long j2);

    private static native void setDictionary_0(long j, long j2);

    private static native void setRefineParameters_0(long j, long j2);

    @Override // org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
