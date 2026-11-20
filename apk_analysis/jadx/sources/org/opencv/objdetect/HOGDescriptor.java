package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class HOGDescriptor {
    protected final long nativeObj;

    private static native long HOGDescriptor_0();

    private static native long HOGDescriptor_1(double d, double d2, double d3, double d4, double d5, double d6, double d7, double d8, int i, int i2, double d9, int i3, double d10, boolean z, int i4, boolean z2);

    private static native long HOGDescriptor_2(double d, double d2, double d3, double d4, double d5, double d6, double d7, double d8, int i, int i2, double d9, int i3, double d10, boolean z, int i4);

    private static native long HOGDescriptor_3(double d, double d2, double d3, double d4, double d5, double d6, double d7, double d8, int i, int i2, double d9, int i3, double d10, boolean z);

    private static native long HOGDescriptor_4(double d, double d2, double d3, double d4, double d5, double d6, double d7, double d8, int i, int i2, double d9, int i3, double d10);

    private static native long HOGDescriptor_5(double d, double d2, double d3, double d4, double d5, double d6, double d7, double d8, int i, int i2, double d9, int i3);

    private static native long HOGDescriptor_6(double d, double d2, double d3, double d4, double d5, double d6, double d7, double d8, int i, int i2, double d9);

    private static native long HOGDescriptor_7(double d, double d2, double d3, double d4, double d5, double d6, double d7, double d8, int i, int i2);

    private static native long HOGDescriptor_8(double d, double d2, double d3, double d4, double d5, double d6, double d7, double d8, int i);

    private static native long HOGDescriptor_9(String str);

    private static native boolean checkDetectorSize_0(long j);

    private static native void computeGradient_0(long j, long j2, long j3, long j4, double d, double d2, double d3, double d4);

    private static native void computeGradient_1(long j, long j2, long j3, long j4, double d, double d2);

    private static native void computeGradient_2(long j, long j2, long j3, long j4);

    private static native void compute_0(long j, long j2, long j3, double d, double d2, double d3, double d4, long j4);

    private static native void compute_1(long j, long j2, long j3, double d, double d2, double d3, double d4);

    private static native void compute_2(long j, long j2, long j3, double d, double d2);

    private static native void compute_3(long j, long j2, long j3);

    private static native void delete(long j);

    private static native void detectMultiScale_0(long j, long j2, long j3, long j4, double d, double d2, double d3, double d4, double d5, double d6, double d7, boolean z);

    private static native void detectMultiScale_1(long j, long j2, long j3, long j4, double d, double d2, double d3, double d4, double d5, double d6, double d7);

    private static native void detectMultiScale_2(long j, long j2, long j3, long j4, double d, double d2, double d3, double d4, double d5, double d6);

    private static native void detectMultiScale_3(long j, long j2, long j3, long j4, double d, double d2, double d3, double d4, double d5);

    private static native void detectMultiScale_4(long j, long j2, long j3, long j4, double d, double d2, double d3);

    private static native void detectMultiScale_5(long j, long j2, long j3, long j4, double d);

    private static native void detectMultiScale_6(long j, long j2, long j3, long j4);

    private static native void detect_0(long j, long j2, long j3, long j4, double d, double d2, double d3, double d4, double d5, long j5);

    private static native void detect_1(long j, long j2, long j3, long j4, double d, double d2, double d3, double d4, double d5);

    private static native void detect_2(long j, long j2, long j3, long j4, double d, double d2, double d3);

    private static native void detect_3(long j, long j2, long j3, long j4, double d);

    private static native void detect_4(long j, long j2, long j3, long j4);

    private static native long getDaimlerPeopleDetector_0();

    private static native long getDefaultPeopleDetector_0();

    private static native long getDescriptorSize_0(long j);

    private static native double getWinSigma_0(long j);

    private static native double get_L2HysThreshold_0(long j);

    private static native double[] get_blockSize_0(long j);

    private static native double[] get_blockStride_0(long j);

    private static native double[] get_cellSize_0(long j);

    private static native int get_derivAperture_0(long j);

    private static native boolean get_gammaCorrection_0(long j);

    private static native int get_histogramNormType_0(long j);

    private static native int get_nbins_0(long j);

    private static native int get_nlevels_0(long j);

    private static native boolean get_signedGradient_0(long j);

    private static native long get_svmDetector_0(long j);

    private static native double get_winSigma_0(long j);

    private static native double[] get_winSize_0(long j);

    private static native boolean load_0(long j, String str, String str2);

    private static native boolean load_1(long j, String str);

    private static native void save_0(long j, String str, String str2);

    private static native void save_1(long j, String str);

    private static native void setSVMDetector_0(long j, long j2);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
