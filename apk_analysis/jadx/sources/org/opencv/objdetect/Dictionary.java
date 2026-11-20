package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class Dictionary {
    protected final long nativeObj;

    private static native long Dictionary_0();

    private static native long Dictionary_1(long j, int i, int i2);

    private static native long Dictionary_2(long j, int i);

    private static native void delete(long j);

    private static native void generateImageMarker_0(long j, int i, int i2, long j2, int i3);

    private static native void generateImageMarker_1(long j, int i, int i2, long j2);

    private static native long getBitsFromByteList_0(long j, int i);

    private static native long getByteListFromBits_0(long j);

    private static native int getDistanceToId_0(long j, long j2, int i, boolean z);

    private static native int getDistanceToId_1(long j, long j2, int i);

    private static native long get_bytesList_0(long j);

    private static native int get_markerSize_0(long j);

    private static native int get_maxCorrectionBits_0(long j);

    private static native boolean identify_0(long j, long j2, double[] dArr, double[] dArr2, double d);

    private static native void set_bytesList_0(long j, long j2);

    private static native void set_markerSize_0(long j, int i);

    private static native void set_maxCorrectionBits_0(long j, int i);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
