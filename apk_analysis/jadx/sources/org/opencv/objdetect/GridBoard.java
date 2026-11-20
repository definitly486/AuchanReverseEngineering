package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class GridBoard extends Board {
    private static native long GridBoard_0(double d, double d2, float f, float f2, long j, long j2);

    private static native long GridBoard_1(double d, double d2, float f, float f2, long j);

    private static native void delete(long j);

    private static native double[] getGridSize_0(long j);

    private static native float getMarkerLength_0(long j);

    private static native float getMarkerSeparation_0(long j);

    @Override // org.opencv.objdetect.Board
    protected void finalize() {
        delete(this.nativeObj);
    }
}
