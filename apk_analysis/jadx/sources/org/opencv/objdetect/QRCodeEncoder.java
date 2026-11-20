package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class QRCodeEncoder {
    protected final long nativeObj;

    private static native long create_0(long j);

    private static native long create_1();

    private static native void delete(long j);

    private static native void encodeStructuredAppend_0(long j, String str, long j2);

    private static native void encode_0(long j, String str, long j2);

    private static native void encode_1(long j, byte[] bArr, long j2);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
