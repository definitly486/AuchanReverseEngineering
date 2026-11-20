package com.google.mediapipe.framework;

import com.google.common.base.Preconditions;
import com.google.mediapipe.proto.CalculatorProfileProto;
import com.google.protobuf.InvalidProtocolBufferException;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class GraphProfiler {
    private final Graph mediapipeGraph;
    private final long nativeProfilerHandle;

    private native byte[][] nativeGetCalculatorProfiles(long j);

    private native void nativePause(long j);

    private native void nativeReset(long j);

    private native void nativeResume(long j);

    GraphProfiler(long j, Graph graph) {
        Preconditions.checkState(j != 0, "Invalid profiler, tearDown() might have been called already.");
        this.nativeProfilerHandle = j;
        this.mediapipeGraph = graph;
    }

    public void reset() {
        synchronized (this.mediapipeGraph) {
            checkContext();
            nativeReset(this.nativeProfilerHandle);
        }
    }

    public void resume() {
        synchronized (this.mediapipeGraph) {
            checkContext();
            nativeResume(this.nativeProfilerHandle);
        }
    }

    public void pause() {
        synchronized (this.mediapipeGraph) {
            checkContext();
            nativePause(this.nativeProfilerHandle);
        }
    }

    public List<CalculatorProfileProto.CalculatorProfile> getCalculatorProfiles() {
        synchronized (this.mediapipeGraph) {
            try {
                checkContext();
                byte[][] bArrNativeGetCalculatorProfiles = nativeGetCalculatorProfiles(this.nativeProfilerHandle);
                ArrayList arrayList = new ArrayList();
                if (bArrNativeGetCalculatorProfiles == null) {
                    return arrayList;
                }
                for (byte[] bArr : bArrNativeGetCalculatorProfiles) {
                    try {
                        arrayList.add(CalculatorProfileProto.CalculatorProfile.parseFrom(bArr));
                    } catch (InvalidProtocolBufferException e) {
                        throw new RuntimeException(e);
                    }
                }
                return arrayList;
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    private void checkContext() {
        Preconditions.checkState(this.mediapipeGraph.getNativeHandle() != 0, "Invalid context, tearDown() might have been called already.");
    }
}
