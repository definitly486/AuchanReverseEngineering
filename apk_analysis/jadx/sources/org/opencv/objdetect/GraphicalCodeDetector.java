package org.opencv.objdetect;

import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class GraphicalCodeDetector {
    protected final long nativeObj;

    private static native boolean decodeBytesMulti_0(long j, long j2, long j3, List<byte[]> list, long j4);

    private static native boolean decodeBytesMulti_1(long j, long j2, long j3, List<byte[]> list);

    private static native byte[] decodeBytes_0(long j, long j2, long j3, long j4);

    private static native byte[] decodeBytes_1(long j, long j2, long j3);

    private static native boolean decodeMulti_0(long j, long j2, long j3, List<String> list, long j4);

    private static native boolean decodeMulti_1(long j, long j2, long j3, List<String> list);

    private static native String decode_0(long j, long j2, long j3, long j4);

    private static native String decode_1(long j, long j2, long j3);

    private static native void delete(long j);

    private static native boolean detectAndDecodeBytesMulti_0(long j, long j2, List<byte[]> list, long j3, long j4);

    private static native boolean detectAndDecodeBytesMulti_1(long j, long j2, List<byte[]> list, long j3);

    private static native boolean detectAndDecodeBytesMulti_2(long j, long j2, List<byte[]> list);

    private static native byte[] detectAndDecodeBytes_0(long j, long j2, long j3, long j4);

    private static native byte[] detectAndDecodeBytes_1(long j, long j2, long j3);

    private static native byte[] detectAndDecodeBytes_2(long j, long j2);

    private static native boolean detectAndDecodeMulti_0(long j, long j2, List<String> list, long j3, long j4);

    private static native boolean detectAndDecodeMulti_1(long j, long j2, List<String> list, long j3);

    private static native boolean detectAndDecodeMulti_2(long j, long j2, List<String> list);

    private static native String detectAndDecode_0(long j, long j2, long j3, long j4);

    private static native String detectAndDecode_1(long j, long j2, long j3);

    private static native String detectAndDecode_2(long j, long j2);

    private static native boolean detectMulti_0(long j, long j2, long j3);

    private static native boolean detect_0(long j, long j2, long j3);

    protected GraphicalCodeDetector(long j) {
        this.nativeObj = j;
    }

    protected void finalize() {
        delete(this.nativeObj);
    }
}
