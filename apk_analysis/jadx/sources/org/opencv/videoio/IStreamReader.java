package org.opencv.videoio;

/* JADX INFO: loaded from: classes3.dex */
public class IStreamReader {
    protected final long nativeObj;

    private static native void delete(long j);

    private static native long read_0(long j, byte[] bArr, long j2);

    private static native long seek_0(long j, long j2, int i);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
