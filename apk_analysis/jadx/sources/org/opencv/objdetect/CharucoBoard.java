package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class CharucoBoard extends Board {
    private static native long CharucoBoard_0(double d, double d2, float f, float f2, long j, long j2);

    private static native long CharucoBoard_1(double d, double d2, float f, float f2, long j);

    private static native boolean checkCharucoCornersCollinear_0(long j, long j2);

    private static native void delete(long j);

    private static native long getChessboardCorners_0(long j);

    private static native double[] getChessboardSize_0(long j);

    private static native boolean getLegacyPattern_0(long j);

    private static native float getMarkerLength_0(long j);

    private static native float getSquareLength_0(long j);

    private static native void setLegacyPattern_0(long j, boolean z);

    @Override // org.opencv.objdetect.Board
    protected void finalize() {
        delete(this.nativeObj);
    }
}
