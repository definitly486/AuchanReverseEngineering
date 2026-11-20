package org.opencv.imgcodecs;

/* JADX INFO: loaded from: classes3.dex */
public class Imgcodecs {
    private static native boolean haveImageReader_0(String str);

    private static native boolean haveImageWriter_0(String str);

    private static native long imcount_0(String str, int i);

    private static native long imcount_1(String str);

    private static native long imdecodeWithMetadata_0(long j, long j2, long j3, int i);

    private static native long imdecodeWithMetadata_1(long j, long j2, long j3);

    private static native long imdecode_0(long j, int i);

    private static native boolean imdecodeanimation_0(long j, long j2, int i, int i2);

    private static native boolean imdecodeanimation_1(long j, long j2, int i);

    private static native boolean imdecodeanimation_2(long j, long j2);

    private static native boolean imdecodemulti_0(long j, int i, long j2, int i2, int i3);

    private static native boolean imdecodemulti_1(long j, int i, long j2);

    private static native boolean imencodeWithMetadata_0(String str, long j, long j2, long j3, long j4, long j5);

    private static native boolean imencodeWithMetadata_1(String str, long j, long j2, long j3, long j4);

    private static native boolean imencode_0(String str, long j, long j2, long j3);

    private static native boolean imencode_1(String str, long j, long j2);

    private static native boolean imencodeanimation_0(String str, long j, long j2, long j3);

    private static native boolean imencodeanimation_1(String str, long j, long j2);

    private static native boolean imencodemulti_0(String str, long j, long j2, long j3);

    private static native boolean imencodemulti_1(String str, long j, long j2);

    private static native long imreadWithMetadata_0(String str, long j, long j2, int i);

    private static native long imreadWithMetadata_1(String str, long j, long j2);

    private static native long imread_0(String str, int i);

    private static native long imread_1(String str);

    private static native void imread_2(String str, long j, int i);

    private static native void imread_3(String str, long j);

    private static native boolean imreadanimation_0(String str, long j, int i, int i2);

    private static native boolean imreadanimation_1(String str, long j, int i);

    private static native boolean imreadanimation_2(String str, long j);

    private static native boolean imreadmulti_0(String str, long j, int i);

    private static native boolean imreadmulti_1(String str, long j);

    private static native boolean imreadmulti_2(String str, long j, int i, int i2, int i3);

    private static native boolean imreadmulti_3(String str, long j, int i, int i2);

    private static native boolean imwriteWithMetadata_0(String str, long j, long j2, long j3, long j4);

    private static native boolean imwriteWithMetadata_1(String str, long j, long j2, long j3);

    private static native boolean imwrite_0(String str, long j, long j2);

    private static native boolean imwrite_1(String str, long j);

    private static native boolean imwriteanimation_0(String str, long j, long j2);

    private static native boolean imwriteanimation_1(String str, long j);

    private static native boolean imwritemulti_0(String str, long j, long j2);

    private static native boolean imwritemulti_1(String str, long j);
}
