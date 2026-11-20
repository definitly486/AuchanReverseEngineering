package com.google.mediapipe.framework;

import com.google.common.base.Preconditions;
import com.google.common.flogger.FluentLogger;
import com.google.mediapipe.proto.CalculatorProto;
import com.google.mediapipe.proto.GraphTemplateProto;
import com.google.protobuf.ExtensionRegistryLite;
import com.google.protobuf.InvalidProtocolBufferException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public class Graph {
    private static final int MAX_BUFFER_SIZE = 20;
    private static final FluentLogger logger = FluentLogger.forEnclosingClass();
    private final List<Object> callbacks = new ArrayList();
    private Map<String, Packet> sidePackets = new HashMap();
    private Map<String, Packet> streamHeaders = new HashMap();
    private boolean stepMode = false;
    private boolean startRunningGraphCalled = false;
    private boolean graphRunning = false;
    private Map<String, ArrayList<PacketBufferItem>> packetBuffers = new HashMap();
    private final Object terminationLock = new Object();
    private long nativeGraphHandle = nativeCreateGraph();

    private native void nativeAddMultiStreamCallback(long j, List<String> list, PacketListCallback packetListCallback, boolean z);

    private native void nativeAddPacketCallback(long j, String str, PacketCallback packetCallback);

    private native void nativeAddPacketToInputStream(long j, String str, long j2, long j3);

    private native long nativeAddSurfaceOutput(long j, String str);

    private native void nativeCancelGraph(long j);

    private native void nativeCloseAllInputStreams(long j);

    private native void nativeCloseAllPacketSources(long j);

    private native void nativeCloseInputStream(long j, String str);

    private native long nativeCreateGraph();

    private native byte[] nativeGetCalculatorGraphConfig(long j);

    private native long nativeGetProfiler(long j);

    private native void nativeLoadBinaryGraph(long j, String str);

    private native void nativeLoadBinaryGraphBytes(long j, byte[] bArr);

    private native void nativeLoadBinaryGraphTemplate(long j, byte[] bArr);

    private native void nativeMovePacketToInputStream(long j, String str, long j2, long j3);

    private native void nativeReleaseGraph(long j);

    private native void nativeRunGraphUntilClose(long j, String[] strArr, long[] jArr);

    private native void nativeSetGraphInputStreamBlockingMode(long j, boolean z);

    private native void nativeSetGraphOptions(long j, byte[] bArr);

    private native void nativeSetGraphType(long j, String str);

    private native void nativeSetParentGlContext(long j, long j2);

    private native void nativeStartRunningGraph(long j, String[] strArr, long[] jArr, String[] strArr2, long[] jArr2);

    private native void nativeUpdatePacketReference(long j, long j2);

    private native void nativeWaitUntilGraphDone(long j);

    private native void nativeWaitUntilGraphIdle(long j);

    private static class PacketBufferItem {
        final Packet packet;
        final Long timestamp;

        private PacketBufferItem(Packet packet, Long l) {
            this.packet = packet;
            this.timestamp = l;
        }
    }

    public synchronized long getNativeHandle() {
        return this.nativeGraphHandle;
    }

    public synchronized void setStepMode(boolean z) {
        this.stepMode = z;
    }

    public synchronized boolean getStepMode() {
        return this.stepMode;
    }

    public synchronized void loadBinaryGraph(String str) {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called already.");
        nativeLoadBinaryGraph(this.nativeGraphHandle, str);
    }

    public synchronized void loadBinaryGraph(byte[] bArr) {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called already.");
        nativeLoadBinaryGraphBytes(this.nativeGraphHandle, bArr);
    }

    public synchronized void loadBinaryGraph(CalculatorProto.CalculatorGraphConfig calculatorGraphConfig) {
        loadBinaryGraph(calculatorGraphConfig.toByteArray());
    }

    public synchronized void loadBinaryGraphTemplate(GraphTemplateProto.CalculatorGraphTemplate calculatorGraphTemplate) {
        nativeLoadBinaryGraphTemplate(this.nativeGraphHandle, calculatorGraphTemplate.toByteArray());
    }

    public synchronized void loadBinaryGraphTemplate(byte[] bArr) {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called already.");
        nativeLoadBinaryGraphTemplate(this.nativeGraphHandle, bArr);
    }

    public synchronized void setGraphType(String str) {
        nativeSetGraphType(this.nativeGraphHandle, str);
    }

    public synchronized void setGraphOptions(CalculatorProto.CalculatorGraphConfig.Node node) {
        nativeSetGraphOptions(this.nativeGraphHandle, node.toByteArray());
    }

    public synchronized CalculatorProto.CalculatorGraphConfig getCalculatorGraphConfig(ExtensionRegistryLite extensionRegistryLite) {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called already.");
        byte[] bArrNativeGetCalculatorGraphConfig = nativeGetCalculatorGraphConfig(this.nativeGraphHandle);
        if (bArrNativeGetCalculatorGraphConfig == null) {
            return null;
        }
        try {
            return CalculatorProto.CalculatorGraphConfig.parseFrom(bArrNativeGetCalculatorGraphConfig, extensionRegistryLite);
        } catch (InvalidProtocolBufferException e) {
            throw new RuntimeException(e);
        }
    }

    public synchronized CalculatorProto.CalculatorGraphConfig getCalculatorGraphConfig() {
        return getCalculatorGraphConfig(ProtoUtil.getExtensionRegistry());
    }

    public synchronized void addPacketCallback(String str, PacketCallback packetCallback) {
        try {
            boolean z = false;
            Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called already.");
            Preconditions.checkNotNull(str);
            Preconditions.checkNotNull(packetCallback);
            if (!this.graphRunning && !this.startRunningGraphCalled) {
                z = true;
            }
            Preconditions.checkState(z);
            this.callbacks.add(packetCallback);
            nativeAddPacketCallback(this.nativeGraphHandle, str, packetCallback);
        } catch (Throwable th) {
            throw th;
        }
    }

    public synchronized void addMultiStreamCallback(List<String> list, PacketListCallback packetListCallback) {
        addMultiStreamCallback(list, packetListCallback, false);
    }

    public synchronized void addMultiStreamCallback(List<String> list, PacketListCallback packetListCallback, boolean z) throws Throwable {
        Throwable th;
        try {
            try {
                boolean z2 = false;
                Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called already.");
                Preconditions.checkNotNull(list);
                Preconditions.checkNotNull(packetListCallback);
                if (!this.graphRunning) {
                    try {
                        if (!this.startRunningGraphCalled) {
                            z2 = true;
                        }
                    } catch (Throwable th2) {
                        th = th2;
                        throw th;
                    }
                }
                Preconditions.checkState(z2);
                this.callbacks.add(packetListCallback);
                nativeAddMultiStreamCallback(this.nativeGraphHandle, list, packetListCallback, z);
            } catch (Throwable th3) {
                th = th3;
                th = th;
                throw th;
            }
        } catch (Throwable th4) {
            th = th4;
            th = th;
            throw th;
        }
    }

    public synchronized SurfaceOutput addSurfaceOutput(String str) {
        try {
            boolean z = false;
            Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called.");
            Preconditions.checkNotNull(str);
            if (!this.graphRunning && !this.startRunningGraphCalled) {
                z = true;
            }
            Preconditions.checkState(z);
        } catch (Throwable th) {
            throw th;
        }
        return new SurfaceOutput(this, Packet.create(nativeAddSurfaceOutput(this.nativeGraphHandle, str)));
    }

    public synchronized void setInputSidePackets(Map<String, Packet> map) {
        try {
            boolean z = false;
            Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called.");
            if (!this.graphRunning && !this.startRunningGraphCalled) {
                z = true;
            }
            Preconditions.checkState(z);
            for (Map.Entry<String, Packet> entry : map.entrySet()) {
                this.sidePackets.put(entry.getKey(), entry.getValue().copy());
            }
        } catch (Throwable th) {
            throw th;
        }
    }

    public synchronized <T> void setServiceObject(GraphService<T> graphService, T t) {
        graphService.installServiceObject(this.nativeGraphHandle, t);
    }

    public synchronized void addStreamNameExpectingHeader(String str) {
        try {
            Preconditions.checkState((this.graphRunning || this.startRunningGraphCalled) ? false : true);
            this.streamHeaders.put(str, null);
        } catch (Throwable th) {
            throw th;
        }
    }

    public synchronized void setStreamHeader(String str, Packet packet) {
        setStreamHeader(str, packet, false);
    }

    public synchronized void setStreamHeader(String str, Packet packet, boolean z) {
        try {
            Packet packet2 = this.streamHeaders.get(str);
            if (packet2 != null) {
                if (!z) {
                    return;
                }
                if (this.graphRunning) {
                    throw new IllegalArgumentException("Can't override an existing stream header, after graph started running.");
                }
                packet2.release();
            }
            this.streamHeaders.put(str, packet.copy());
            if (!this.graphRunning && this.startRunningGraphCalled && hasAllStreamHeaders()) {
                startRunningGraph();
            }
        } catch (Throwable th) {
            throw th;
        }
    }

    public synchronized void runGraphUntilClose() {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called.");
        Preconditions.checkNotNull(this.sidePackets);
        String[] strArr = new String[this.sidePackets.size()];
        long[] jArr = new long[this.sidePackets.size()];
        splitStreamNamePacketMap(this.sidePackets, strArr, jArr);
        nativeRunGraphUntilClose(this.nativeGraphHandle, strArr, jArr);
    }

    public synchronized void startRunningGraph() throws Throwable {
        try {
            try {
                Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called.");
                this.startRunningGraphCalled = true;
                if (!hasAllStreamHeaders()) {
                    logger.atInfo().log("MediaPipe graph won't start until all stream headers are available.");
                    return;
                }
                String[] strArr = new String[this.sidePackets.size()];
                long[] jArr = new long[this.sidePackets.size()];
                splitStreamNamePacketMap(this.sidePackets, strArr, jArr);
                String[] strArr2 = new String[this.streamHeaders.size()];
                long[] jArr2 = new long[this.streamHeaders.size()];
                splitStreamNamePacketMap(this.streamHeaders, strArr2, jArr2);
                nativeStartRunningGraph(this.nativeGraphHandle, strArr, jArr, strArr2, jArr2);
                this.graphRunning = true;
                moveBufferedPacketsToInputStream();
            } catch (Throwable th) {
                th = th;
                throw th;
            }
        } catch (Throwable th2) {
            th = th2;
            throw th;
        }
    }

    public synchronized void setGraphInputStreamBlockingMode(boolean z) {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called.");
        Preconditions.checkState(!this.graphRunning);
        nativeSetGraphInputStreamBlockingMode(this.nativeGraphHandle, z);
    }

    public synchronized void addPacketToInputStream(String str, Packet packet, long j) throws Throwable {
        Throwable th;
        try {
            try {
                Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called.");
                if (!this.graphRunning) {
                    try {
                        addPacketToBuffer(str, packet.copy(), j);
                    } catch (Throwable th2) {
                        th = th2;
                        throw th;
                    }
                } else {
                    nativeAddPacketToInputStream(this.nativeGraphHandle, str, packet.getNativeHandle(), j);
                }
            } catch (Throwable th3) {
                th = th3;
                th = th;
                throw th;
            }
        } catch (Throwable th4) {
            th = th4;
            th = th;
            throw th;
        }
    }

    public synchronized void addConsumablePacketToInputStream(String str, Packet packet, long j) throws Throwable {
        Throwable th;
        try {
            try {
                Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called.");
                if (!this.graphRunning) {
                    try {
                        addPacketToBuffer(str, packet.copy(), j);
                        packet.release();
                    } catch (Throwable th2) {
                        th = th2;
                        throw th;
                    }
                } else {
                    nativeMovePacketToInputStream(this.nativeGraphHandle, str, packet.getNativeHandle(), j);
                    packet.release();
                }
            } catch (Throwable th3) {
                th = th3;
                th = th;
                throw th;
            }
        } catch (Throwable th4) {
            th = th4;
            th = th;
            throw th;
        }
    }

    public synchronized void closeInputStream(String str) {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called.");
        nativeCloseInputStream(this.nativeGraphHandle, str);
    }

    public synchronized void closeAllInputStreams() {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called.");
        nativeCloseAllInputStreams(this.nativeGraphHandle);
    }

    public synchronized void closeAllPacketSources() {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called.");
        nativeCloseAllPacketSources(this.nativeGraphHandle);
    }

    public synchronized void waitUntilGraphDone() {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called.");
        nativeWaitUntilGraphDone(this.nativeGraphHandle);
    }

    public synchronized void waitUntilGraphIdle() {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called.");
        nativeWaitUntilGraphIdle(this.nativeGraphHandle);
    }

    public synchronized void tearDown() {
        try {
            Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called already.");
            Iterator<Map.Entry<String, Packet>> it = this.sidePackets.entrySet().iterator();
            while (it.hasNext()) {
                it.next().getValue().release();
            }
            this.sidePackets.clear();
            for (Map.Entry<String, Packet> entry : this.streamHeaders.entrySet()) {
                if (entry.getValue() != null) {
                    entry.getValue().release();
                }
            }
            this.streamHeaders.clear();
            Iterator<Map.Entry<String, ArrayList<PacketBufferItem>>> it2 = this.packetBuffers.entrySet().iterator();
            while (it2.hasNext()) {
                ArrayList<PacketBufferItem> value = it2.next().getValue();
                int size = value.size();
                int i = 0;
                while (i < size) {
                    PacketBufferItem packetBufferItem = value.get(i);
                    i++;
                    packetBufferItem.packet.release();
                }
            }
            this.packetBuffers.clear();
            synchronized (this.terminationLock) {
                try {
                    long j = this.nativeGraphHandle;
                    if (j != 0) {
                        nativeReleaseGraph(j);
                        this.nativeGraphHandle = 0L;
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
            this.callbacks.clear();
        } catch (Throwable th2) {
            throw th2;
        }
    }

    public synchronized void updatePacketReference(Packet packet, Packet packet2) {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called already.");
        nativeUpdatePacketReference(packet.getNativeHandle(), packet2.getNativeHandle());
    }

    @Deprecated
    public synchronized void createGlRunner(String str, long j) {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called already.");
        Preconditions.checkArgument(str.equals("gpu_shared"));
        setParentGlContext(j);
    }

    public synchronized void setParentGlContext(long j) {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called already.");
        Preconditions.checkState(!this.graphRunning);
        nativeSetParentGlContext(this.nativeGraphHandle, j);
    }

    public synchronized void cancelGraph() {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called already.");
        nativeCancelGraph(this.nativeGraphHandle);
    }

    public GraphProfiler getProfiler() {
        Preconditions.checkState(this.nativeGraphHandle != 0, "Invalid context, tearDown() might have been called already.");
        return new GraphProfiler(nativeGetProfiler(this.nativeGraphHandle), this);
    }

    private boolean addPacketToBuffer(String str, Packet packet, long j) {
        if (!this.packetBuffers.containsKey(str)) {
            this.packetBuffers.put(str, new ArrayList<>());
        }
        ArrayList<PacketBufferItem> arrayList = this.packetBuffers.get(str);
        if (arrayList.size() > 20) {
            for (Map.Entry<String, Packet> entry : this.streamHeaders.entrySet()) {
                if (entry.getValue() == null) {
                    logger.atSevere().log("Stream: %s might be missing.", entry.getKey());
                }
            }
            throw new RuntimeException("Graph is not started because of missing streams");
        }
        arrayList.add(new PacketBufferItem(packet, Long.valueOf(j)));
        return true;
    }

    private void moveBufferedPacketsToInputStream() {
        if (this.packetBuffers.isEmpty()) {
            return;
        }
        for (Map.Entry<String, ArrayList<PacketBufferItem>> entry : this.packetBuffers.entrySet()) {
            ArrayList<PacketBufferItem> value = entry.getValue();
            int size = value.size();
            int i = 0;
            while (i < size) {
                PacketBufferItem packetBufferItem = value.get(i);
                i++;
                PacketBufferItem packetBufferItem2 = packetBufferItem;
                try {
                    try {
                        nativeMovePacketToInputStream(this.nativeGraphHandle, entry.getKey(), packetBufferItem2.packet.getNativeHandle(), packetBufferItem2.timestamp.longValue());
                        packetBufferItem2.packet.release();
                    } catch (MediaPipeException e) {
                        e = e;
                        logger.atSevere().log("AddPacket for stream: %s failed: %s.", entry.getKey(), e.getMessage());
                        throw e;
                    }
                } catch (MediaPipeException e2) {
                    e = e2;
                }
            }
        }
        this.packetBuffers.clear();
    }

    private static void splitStreamNamePacketMap(Map<String, Packet> map, String[] strArr, long[] jArr) {
        if (map.size() != strArr.length || map.size() != jArr.length) {
            throw new RuntimeException("Input array length doesn't match the map size!");
        }
        int i = 0;
        for (Map.Entry<String, Packet> entry : map.entrySet()) {
            strArr[i] = entry.getKey();
            jArr[i] = entry.getValue().getNativeHandle();
            i++;
        }
    }

    private boolean hasAllStreamHeaders() {
        Iterator<Map.Entry<String, Packet>> it = this.streamHeaders.entrySet().iterator();
        while (it.hasNext()) {
            if (it.next().getValue() == null) {
                return false;
            }
        }
        return true;
    }
}
