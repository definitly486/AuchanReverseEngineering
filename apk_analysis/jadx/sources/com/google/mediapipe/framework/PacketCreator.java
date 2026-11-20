package com.google.mediapipe.framework;

import com.google.protobuf.MessageLite;
import java.nio.ByteBuffer;
import java.nio.FloatBuffer;

/* JADX INFO: loaded from: classes3.dex */
public class PacketCreator {
    private static final int GL_RGBA = 6408;
    protected Graph mediapipeGraph;

    private native long nativeCreateAudioPacket(long j, byte[] bArr, int i, int i2, int i3);

    private native long nativeCreateAudioPacketDirect(long j, ByteBuffer byteBuffer, int i, int i2);

    private native long nativeCreateBool(long j, boolean z);

    private native long nativeCreateCalculatorOptions(long j, byte[] bArr);

    private native long nativeCreateCameraIntrinsics(long j, float f, float f2, float f3, float f4, float f5, float f6);

    private native long nativeCreateCpuImage(long j, ByteBuffer byteBuffer, int i, int i2, int i3, int i4);

    private native long nativeCreateFloat32(long j, float f);

    private native long nativeCreateFloat32Array(long j, float[] fArr);

    private native long nativeCreateFloat32Vector(long j, float[] fArr);

    private native long nativeCreateFloat64(long j, double d);

    private native long nativeCreateFloatImageFrame(long j, FloatBuffer floatBuffer, int i, int i2);

    private native long nativeCreateGpuBuffer(long j, int i, int i2, int i3, int i4, TextureReleaseCallback textureReleaseCallback, int i5);

    private native long nativeCreateGpuImage(long j, int i, int i2, int i3, int i4, TextureReleaseCallback textureReleaseCallback);

    private native long nativeCreateGrayscaleImage(long j, ByteBuffer byteBuffer, int i, int i2);

    private native long nativeCreateInt16(long j, short s);

    private native long nativeCreateInt32(long j, int i);

    private native long nativeCreateInt32Array(long j, int[] iArr);

    private native long nativeCreateInt32Pair(long j, int i, int i2);

    private native long nativeCreateInt64(long j, long j2);

    private native long nativeCreateMatrix(long j, int i, int i2, float[] fArr);

    private native long nativeCreateProto(long j, ProtoUtil.SerializedMessage serializedMessage);

    private native long nativeCreateReferencePacket(long j, long j2);

    private native long nativeCreateRgbImage(long j, ByteBuffer byteBuffer, int i, int i2);

    private native long nativeCreateRgbImageFromRgba(long j, ByteBuffer byteBuffer, int i, int i2);

    private native long nativeCreateRgbaImageFrame(long j, ByteBuffer byteBuffer, int i, int i2);

    private native long nativeCreateString(long j, String str);

    private native long nativeCreateStringFromByteArray(long j, byte[] bArr);

    private native long nativeCreateTimeSeriesHeader(long j, int i, double d);

    private native long nativeCreateVideoHeader(long j, int i, int i2);

    public enum SyncMode {
        NO_SYNC(0),
        SYNC(1),
        MAYBE_SYNC_OR_FINISH(2);

        private final int value;

        SyncMode(int i) {
            this.value = i;
        }
    }

    public PacketCreator(Graph graph) {
        this.mediapipeGraph = graph;
    }

    public Packet createReferencePacket(Packet packet) {
        return Packet.create(nativeCreateReferencePacket(this.mediapipeGraph.getNativeHandle(), packet.getNativeHandle()));
    }

    public Packet createRgbImage(ByteBuffer byteBuffer, int i, int i2) {
        int i3 = (((i * 3) + 3) / 4) * 4 * i2;
        if (i3 != byteBuffer.capacity()) {
            throw new IllegalArgumentException("The size of the buffer should be: " + i3 + " but is " + byteBuffer.capacity());
        }
        return Packet.create(nativeCreateRgbImage(this.mediapipeGraph.getNativeHandle(), byteBuffer, i, i2));
    }

    public Packet createAudioPacket(byte[] bArr, int i, int i2) {
        checkAudioDataSize(bArr.length, i, i2);
        return Packet.create(nativeCreateAudioPacket(this.mediapipeGraph.getNativeHandle(), bArr, 0, i, i2));
    }

    public Packet createAudioPacket(ByteBuffer byteBuffer, int i, int i2) {
        checkAudioDataSize(byteBuffer.remaining(), i, i2);
        if (byteBuffer.isDirect()) {
            return Packet.create(nativeCreateAudioPacketDirect(this.mediapipeGraph.getNativeHandle(), byteBuffer.slice(), i, i2));
        }
        if (byteBuffer.hasArray()) {
            return Packet.create(nativeCreateAudioPacket(this.mediapipeGraph.getNativeHandle(), byteBuffer.array(), byteBuffer.arrayOffset() + byteBuffer.position(), i, i2));
        }
        throw new IllegalArgumentException("Data must be either a direct byte buffer or be backed by a byte array.");
    }

    private static void checkAudioDataSize(int i, int i2, int i3) {
        int i4 = i2 * i3 * 2;
        if (i4 == i) {
            return;
        }
        throw new IllegalArgumentException("Please check the audio data size, has to be num_channels * num_samples * 2 = " + i4 + " but was " + i);
    }

    public Packet createRgbImageFromRgba(ByteBuffer byteBuffer, int i, int i2) {
        int i3 = i * i2 * 4;
        if (i3 != byteBuffer.capacity()) {
            throw new IllegalArgumentException("The size of the buffer should be: " + i3 + " but is " + byteBuffer.capacity());
        }
        return Packet.create(nativeCreateRgbImageFromRgba(this.mediapipeGraph.getNativeHandle(), byteBuffer, i, i2));
    }

    public Packet createGrayscaleImage(ByteBuffer byteBuffer, int i, int i2) {
        int i3 = i * i2;
        if (i3 != byteBuffer.capacity()) {
            throw new IllegalArgumentException("The size of the buffer should be: " + i3 + " but is " + byteBuffer.capacity());
        }
        return Packet.create(nativeCreateGrayscaleImage(this.mediapipeGraph.getNativeHandle(), byteBuffer, i, i2));
    }

    public Packet createRgbaImageFrame(ByteBuffer byteBuffer, int i, int i2) {
        int i3 = i * i2 * 4;
        if (byteBuffer.capacity() != i3) {
            throw new IllegalArgumentException("The size of the buffer should be: " + i3 + " but is " + byteBuffer.capacity());
        }
        return Packet.create(nativeCreateRgbaImageFrame(this.mediapipeGraph.getNativeHandle(), byteBuffer, i, i2));
    }

    public Packet createFloatImageFrame(FloatBuffer floatBuffer, int i, int i2) {
        int i3 = i * i2 * 4;
        if (floatBuffer.capacity() != i3) {
            throw new IllegalArgumentException("The size of the buffer should be: " + i3 + " but is " + floatBuffer.capacity());
        }
        return Packet.create(nativeCreateFloatImageFrame(this.mediapipeGraph.getNativeHandle(), floatBuffer, i, i2));
    }

    public Packet createInt16(short s) {
        return Packet.create(nativeCreateInt16(this.mediapipeGraph.getNativeHandle(), s));
    }

    public Packet createInt32(int i) {
        return Packet.create(nativeCreateInt32(this.mediapipeGraph.getNativeHandle(), i));
    }

    public Packet createInt64(long j) {
        return Packet.create(nativeCreateInt64(this.mediapipeGraph.getNativeHandle(), j));
    }

    public Packet createFloat32(float f) {
        return Packet.create(nativeCreateFloat32(this.mediapipeGraph.getNativeHandle(), f));
    }

    public Packet createFloat64(double d) {
        return Packet.create(nativeCreateFloat64(this.mediapipeGraph.getNativeHandle(), d));
    }

    public Packet createBool(boolean z) {
        return Packet.create(nativeCreateBool(this.mediapipeGraph.getNativeHandle(), z));
    }

    public Packet createString(String str) {
        return Packet.create(nativeCreateString(this.mediapipeGraph.getNativeHandle(), str));
    }

    public Packet createInt16Vector(short[] sArr) {
        throw new UnsupportedOperationException("Not implemented yet");
    }

    public Packet createInt32Vector(int[] iArr) {
        throw new UnsupportedOperationException("Not implemented yet");
    }

    public Packet createInt64Vector(long[] jArr) {
        throw new UnsupportedOperationException("Not implemented yet");
    }

    public Packet createFloat32Vector(float[] fArr) {
        return Packet.create(nativeCreateFloat32Vector(this.mediapipeGraph.getNativeHandle(), fArr));
    }

    public Packet createFloat64Vector(double[] dArr) {
        throw new UnsupportedOperationException("Not implemented yet");
    }

    public Packet createInt32Array(int[] iArr) {
        return Packet.create(nativeCreateInt32Array(this.mediapipeGraph.getNativeHandle(), iArr));
    }

    public Packet createInt32Pair(int i, int i2) {
        return Packet.create(nativeCreateInt32Pair(this.mediapipeGraph.getNativeHandle(), i, i2));
    }

    public Packet createFloat32Array(float[] fArr) {
        return Packet.create(nativeCreateFloat32Array(this.mediapipeGraph.getNativeHandle(), fArr));
    }

    public Packet createByteArray(byte[] bArr) {
        return Packet.create(nativeCreateStringFromByteArray(this.mediapipeGraph.getNativeHandle(), bArr));
    }

    public Packet createVideoHeader(int i, int i2) {
        return Packet.create(nativeCreateVideoHeader(this.mediapipeGraph.getNativeHandle(), i, i2));
    }

    public Packet createTimeSeriesHeader(int i, double d) {
        return Packet.create(nativeCreateTimeSeriesHeader(this.mediapipeGraph.getNativeHandle(), i, d));
    }

    public Packet createMatrix(int i, int i2, float[] fArr) {
        return Packet.create(nativeCreateMatrix(this.mediapipeGraph.getNativeHandle(), i, i2, fArr));
    }

    public Packet createSerializedProto(MessageLite messageLite) {
        return Packet.create(nativeCreateStringFromByteArray(this.mediapipeGraph.getNativeHandle(), messageLite.toByteArray()));
    }

    public Packet createCalculatorOptions(MessageLite messageLite) {
        return Packet.create(nativeCreateCalculatorOptions(this.mediapipeGraph.getNativeHandle(), messageLite.toByteArray()));
    }

    public Packet createProto(MessageLite messageLite) {
        return Packet.create(nativeCreateProto(this.mediapipeGraph.getNativeHandle(), ProtoUtil.pack(messageLite)));
    }

    public Packet createCameraIntrinsics(float f, float f2, float f3, float f4, float f5, float f6) {
        return Packet.create(nativeCreateCameraIntrinsics(this.mediapipeGraph.getNativeHandle(), f, f2, f3, f4, f5, f6));
    }

    public Packet createGpuBuffer(int i, int i2, int i3, int i4, TextureReleaseCallback textureReleaseCallback, SyncMode syncMode) {
        return Packet.create(nativeCreateGpuBuffer(this.mediapipeGraph.getNativeHandle(), i, i2, i3, i4, textureReleaseCallback, syncMode.value));
    }

    public Packet createGpuBuffer(int i, int i2, int i3, int i4, TextureReleaseCallback textureReleaseCallback) {
        return createGpuBuffer(i, i2, i3, i4, textureReleaseCallback, SyncMode.NO_SYNC);
    }

    public Packet createGpuBuffer(int i, int i2, int i3, TextureReleaseCallback textureReleaseCallback, SyncMode syncMode) {
        return createGpuBuffer(i, i2, i3, GL_RGBA, textureReleaseCallback, syncMode);
    }

    public Packet createGpuBuffer(int i, int i2, int i3, TextureReleaseCallback textureReleaseCallback) {
        return createGpuBuffer(i, i2, i3, textureReleaseCallback, SyncMode.NO_SYNC);
    }

    @Deprecated
    public Packet createGpuBuffer(int i, int i2, int i3) {
        return createGpuBuffer(i, i2, i3, GL_RGBA, (TextureReleaseCallback) null);
    }

    public Packet createGpuBuffer(TextureFrame textureFrame, SyncMode syncMode) {
        return Packet.create(nativeCreateGpuBuffer(this.mediapipeGraph.getNativeHandle(), textureFrame.getTextureName(), textureFrame.getWidth(), textureFrame.getHeight(), textureFrame.getFormat(), textureFrame, syncMode.value));
    }

    public Packet createGpuBuffer(TextureFrame textureFrame) {
        return createGpuBuffer(textureFrame, SyncMode.NO_SYNC);
    }

    public Packet createImage(TextureFrame textureFrame) {
        return Packet.create(nativeCreateGpuImage(this.mediapipeGraph.getNativeHandle(), textureFrame.getTextureName(), textureFrame.getWidth(), textureFrame.getHeight(), textureFrame.getFormat(), textureFrame));
    }

    /* JADX WARN: Code duplicated, block: B:14:0x001c  */
    /* JADX WARN: Code duplicated, block: B:16:0x0030  */
    /* JADX WARN: Instruction removed from duplicated block: B:16:0x0030, please report this as an issue */
    public Packet createImage(ByteBuffer byteBuffer, int i, int i2, int i3) {
        int i4;
        int i5;
        int i6;
        if (i3 != 4) {
            if (i3 == 3) {
                i5 = 4 * (((i * 3) + 3) / 4);
            } else {
                if (i3 != 1) {
                    throw new IllegalArgumentException("Channels should be: 1, 3, or 4, but is " + i3);
                }
                i4 = i;
            }
            i6 = i4 * i2;
            if (byteBuffer.capacity() == i6) {
                throw new IllegalArgumentException("The size of the buffer should be: " + i6 + " but is " + byteBuffer.capacity());
            }
            return Packet.create(nativeCreateCpuImage(this.mediapipeGraph.getNativeHandle(), byteBuffer, i, i2, i4, i3));
        }
        i5 = i * 4;
        i4 = i5;
        i6 = i4 * i2;
        if (byteBuffer.capacity() == i6) {
            throw new IllegalArgumentException("The size of the buffer should be: " + i6 + " but is " + byteBuffer.capacity());
        }
        return Packet.create(nativeCreateCpuImage(this.mediapipeGraph.getNativeHandle(), byteBuffer, i, i2, i4, i3));
    }

    private void releaseWithSyncToken(long j, TextureReleaseCallback textureReleaseCallback) {
        textureReleaseCallback.release(new GraphGlSyncToken(j));
    }
}
