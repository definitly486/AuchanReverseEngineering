package org.opencv.objdetect;

import org.opencv.core.Algorithm;

/* JADX INFO: loaded from: classes3.dex */
public class CharucoDetector extends Algorithm {
    private static native long CharucoDetector_0(long j, long j2, long j3, long j4);

    private static native long CharucoDetector_1(long j, long j2, long j3);

    private static native long CharucoDetector_2(long j, long j2);

    private static native long CharucoDetector_3(long j);

    private static native void delete(long j);

    private static native void detectBoard_0(long j, long j2, long j3, long j4, long j5, long j6);

    private static native void detectBoard_1(long j, long j2, long j3, long j4, long j5);

    private static native void detectBoard_2(long j, long j2, long j3, long j4);

    private static native void detectDiamonds_0(long j, long j2, long j3, long j4, long j5, long j6);

    private static native void detectDiamonds_1(long j, long j2, long j3, long j4, long j5);

    private static native void detectDiamonds_2(long j, long j2, long j3, long j4);

    private static native long getBoard_0(long j);

    private static native long getCharucoParameters_0(long j);

    private static native long getDetectorParameters_0(long j);

    private static native long getRefineParameters_0(long j);

    private static native void setBoard_0(long j, long j2);

    private static native void setCharucoParameters_0(long j, long j2);

    private static native void setDetectorParameters_0(long j, long j2);

    private static native void setRefineParameters_0(long j, long j2);

    @Override // org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
