package com.google.mediapipe.framework;

/* JADX INFO: loaded from: classes3.dex */
public class Packet {
    private long nativePacketHandle;

    private native long nativeCopyPacket(long j);

    private native long nativeGetTimestamp(long j);

    private native boolean nativeIsEmpty(long j);

    private native void nativeReleasePacket(long j);

    public static Packet create(long j) {
        return new Packet(j);
    }

    public long getNativeHandle() {
        return this.nativePacketHandle;
    }

    public long getTimestamp() {
        return nativeGetTimestamp(this.nativePacketHandle);
    }

    public boolean isEmpty() {
        return nativeIsEmpty(this.nativePacketHandle);
    }

    public Packet copy() {
        return new Packet(nativeCopyPacket(this.nativePacketHandle));
    }

    public void release() {
        long j = this.nativePacketHandle;
        if (j != 0) {
            nativeReleasePacket(j);
            this.nativePacketHandle = 0L;
        }
    }

    private Packet(long j) {
        this.nativePacketHandle = j;
    }
}
