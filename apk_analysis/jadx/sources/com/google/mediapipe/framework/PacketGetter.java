package com.google.mediapipe.framework;

import com.google.common.base.Preconditions;
import com.google.common.flogger.FluentLogger;
import com.google.protobuf.Internal;
import com.google.protobuf.InvalidProtocolBufferException;
import com.google.protobuf.MessageLite;
import com.google.protobuf.Parser;
import java.nio.ByteBuffer;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class PacketGetter {
    private static final FluentLogger logger = FluentLogger.forEnclosingClass();

    private static native byte[] nativeGetAudioData(long j);

    private static native boolean nativeGetBool(long j);

    private static native byte[] nativeGetBytes(long j);

    private static native float nativeGetFloat32(long j);

    private static native float[] nativeGetFloat32Vector(long j);

    private static native double nativeGetFloat64(long j);

    private static native double[] nativeGetFloat64Vector(long j);

    private static native long nativeGetGpuBuffer(long j, boolean z);

    private static native int nativeGetGpuBufferName(long j);

    private static native boolean nativeGetImageData(long j, ByteBuffer byteBuffer);

    private static native ByteBuffer nativeGetImageDataDirect(long j);

    private static native int nativeGetImageHeight(long j);

    private static native int nativeGetImageHeightFromImageList(long j);

    private static native boolean nativeGetImageList(long j, ByteBuffer[] byteBufferArr, boolean z);

    private static native int nativeGetImageListSize(long j);

    private static native int nativeGetImageNumChannels(long j);

    private static native int nativeGetImageWidth(long j);

    private static native int nativeGetImageWidthFromImageList(long j);

    private static native short nativeGetInt16(long j);

    private static native short[] nativeGetInt16Vector(long j);

    private static native int nativeGetInt32(long j);

    private static native int[] nativeGetInt32Vector(long j);

    private static native long nativeGetInt64(long j);

    private static native long[] nativeGetInt64Vector(long j);

    private static native int nativeGetMatrixCols(long j);

    private static native float[] nativeGetMatrixData(long j);

    private static native int nativeGetMatrixRows(long j);

    private static native long nativeGetPacketFromReference(long j);

    private static native long[] nativeGetPairPackets(long j);

    private static native void nativeGetProto(long j, ProtoUtil.SerializedMessage serializedMessage);

    private static native byte[] nativeGetProtoBytes(long j);

    private static native byte[][] nativeGetProtoVector(long j);

    private static native boolean nativeGetRgbaFromRgb(long j, ByteBuffer byteBuffer);

    private static native String nativeGetString(long j);

    private static native int nativeGetTimeSeriesHeaderNumChannels(long j);

    private static native double nativeGetTimeSeriesHeaderSampleRate(long j);

    private static native long[] nativeGetVectorPackets(long j);

    private static native int nativeGetVideoHeaderHeight(long j);

    private static native int nativeGetVideoHeaderWidth(long j);

    public static class PacketPair {
        public final Packet first;
        public final Packet second;

        public PacketPair(Packet packet, Packet packet2) {
            this.first = packet;
            this.second = packet2;
        }
    }

    public static Packet getPacketFromReference(Packet packet) {
        return Packet.create(nativeGetPacketFromReference(packet.getNativeHandle()));
    }

    public static PacketPair getPairOfPackets(Packet packet) {
        long[] jArrNativeGetPairPackets = nativeGetPairPackets(packet.getNativeHandle());
        return new PacketPair(Packet.create(jArrNativeGetPairPackets[0]), Packet.create(jArrNativeGetPairPackets[1]));
    }

    public static List<Packet> getVectorOfPackets(Packet packet) {
        long[] jArrNativeGetVectorPackets = nativeGetVectorPackets(packet.getNativeHandle());
        ArrayList arrayList = new ArrayList(jArrNativeGetVectorPackets.length);
        for (long j : jArrNativeGetVectorPackets) {
            arrayList.add(Packet.create(j));
        }
        return arrayList;
    }

    public static short getInt16(Packet packet) {
        return nativeGetInt16(packet.getNativeHandle());
    }

    public static int getInt32(Packet packet) {
        return nativeGetInt32(packet.getNativeHandle());
    }

    public static long getInt64(Packet packet) {
        return nativeGetInt64(packet.getNativeHandle());
    }

    public static float getFloat32(Packet packet) {
        return nativeGetFloat32(packet.getNativeHandle());
    }

    public static double getFloat64(Packet packet) {
        return nativeGetFloat64(packet.getNativeHandle());
    }

    public static boolean getBool(Packet packet) {
        return nativeGetBool(packet.getNativeHandle());
    }

    public static String getString(Packet packet) {
        return nativeGetString(packet.getNativeHandle());
    }

    public static byte[] getBytes(Packet packet) {
        return nativeGetBytes(packet.getNativeHandle());
    }

    public static byte[] getProtoBytes(Packet packet) {
        return nativeGetProtoBytes(packet.getNativeHandle());
    }

    public static <T extends MessageLite> T getProto(Packet packet, T t) {
        ProtoUtil.SerializedMessage serializedMessage = new ProtoUtil.SerializedMessage();
        nativeGetProto(packet.getNativeHandle(), serializedMessage);
        return (T) ProtoUtil.unpack(serializedMessage, t);
    }

    public static <T extends MessageLite> T getProto(Packet packet, Parser<T> parser) {
        ProtoUtil.SerializedMessage serializedMessage = new ProtoUtil.SerializedMessage();
        nativeGetProto(packet.getNativeHandle(), serializedMessage);
        try {
            return parser.parseFrom(serializedMessage.value);
        } catch (InvalidProtocolBufferException e) {
            throw new IllegalArgumentException(e);
        }
    }

    @Deprecated
    public static <T extends MessageLite> T getProto(Packet packet, Class<T> cls) {
        return (T) getProto(packet, Internal.getDefaultInstance(cls));
    }

    public static short[] getInt16Vector(Packet packet) {
        return nativeGetInt16Vector(packet.getNativeHandle());
    }

    public static int[] getInt32Vector(Packet packet) {
        return nativeGetInt32Vector(packet.getNativeHandle());
    }

    public static long[] getInt64Vector(Packet packet) {
        return nativeGetInt64Vector(packet.getNativeHandle());
    }

    public static float[] getFloat32Vector(Packet packet) {
        return nativeGetFloat32Vector(packet.getNativeHandle());
    }

    public static double[] getFloat64Vector(Packet packet) {
        return nativeGetFloat64Vector(packet.getNativeHandle());
    }

    public static <T> List<T> getProtoVector(Packet packet, Parser<T> parser) {
        byte[][] bArrNativeGetProtoVector = nativeGetProtoVector(packet.getNativeHandle());
        Preconditions.checkNotNull(bArrNativeGetProtoVector, "Vector of protocol buffer objects should not be null!");
        try {
            ArrayList arrayList = new ArrayList();
            for (byte[] bArr : bArrNativeGetProtoVector) {
                arrayList.add(parser.parseFrom(bArr));
            }
            return arrayList;
        } catch (InvalidProtocolBufferException e) {
            throw new IllegalArgumentException(e);
        }
    }

    public static <T extends MessageLite> List<T> getProtoVector(Packet packet, T t) {
        return getProtoVector(packet, t.getParserForType());
    }

    public static int getImageWidth(Packet packet) {
        return nativeGetImageWidth(packet.getNativeHandle());
    }

    public static int getImageHeight(Packet packet) {
        return nativeGetImageHeight(packet.getNativeHandle());
    }

    public static int getImageNumChannels(Packet packet) {
        return nativeGetImageNumChannels(packet.getNativeHandle());
    }

    public static boolean getImageData(Packet packet, ByteBuffer byteBuffer) {
        return nativeGetImageData(packet.getNativeHandle(), byteBuffer);
    }

    public static ByteBuffer getImageDataDirectly(Packet packet) {
        return nativeGetImageDataDirect(packet.getNativeHandle()).asReadOnlyBuffer();
    }

    public static int getImageListSize(Packet packet) {
        return nativeGetImageListSize(packet.getNativeHandle());
    }

    public static int getImageWidthFromImageList(Packet packet) {
        return nativeGetImageWidthFromImageList(packet.getNativeHandle());
    }

    public static int getImageHeightFromImageList(Packet packet) {
        return nativeGetImageHeightFromImageList(packet.getNativeHandle());
    }

    public static boolean getImageList(Packet packet, ByteBuffer[] byteBufferArr, boolean z) {
        return nativeGetImageList(packet.getNativeHandle(), byteBufferArr, z);
    }

    public static boolean getRgbaFromRgb(Packet packet, ByteBuffer byteBuffer) {
        return nativeGetRgbaFromRgb(packet.getNativeHandle(), byteBuffer);
    }

    public static byte[] getAudioByteData(Packet packet) {
        return nativeGetAudioData(packet.getNativeHandle());
    }

    public static int getAudioDataNumChannels(Packet packet) {
        return nativeGetMatrixRows(packet.getNativeHandle());
    }

    public static int getAudioDataNumSamples(Packet packet) {
        return nativeGetMatrixCols(packet.getNativeHandle());
    }

    public static int getTimeSeriesHeaderNumChannels(Packet packet) {
        return nativeGetTimeSeriesHeaderNumChannels(packet.getNativeHandle());
    }

    public static double getTimeSeriesHeaderSampleRate(Packet packet) {
        return nativeGetTimeSeriesHeaderSampleRate(packet.getNativeHandle());
    }

    public static int getVideoHeaderWidth(Packet packet) {
        return nativeGetVideoHeaderWidth(packet.getNativeHandle());
    }

    public static int getVideoHeaderHeight(Packet packet) {
        return nativeGetVideoHeaderHeight(packet.getNativeHandle());
    }

    public static float[] getMatrixData(Packet packet) {
        return nativeGetMatrixData(packet.getNativeHandle());
    }

    public static int getMatrixRows(Packet packet) {
        return nativeGetMatrixRows(packet.getNativeHandle());
    }

    public static int getMatrixCols(Packet packet) {
        return nativeGetMatrixCols(packet.getNativeHandle());
    }

    @Deprecated
    public static int getGpuBufferName(Packet packet) {
        return nativeGetGpuBufferName(packet.getNativeHandle());
    }

    public static GraphTextureFrame getTextureFrame(Packet packet) {
        return new GraphTextureFrame(nativeGetGpuBuffer(packet.getNativeHandle(), true), packet.getTimestamp());
    }

    public static GraphTextureFrame getTextureFrameDeferredSync(Packet packet) {
        return new GraphTextureFrame(nativeGetGpuBuffer(packet.getNativeHandle(), false), packet.getTimestamp(), true);
    }

    private PacketGetter() {
    }
}
