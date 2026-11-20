package org.opencv.videoio;

import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class Videoio {
    private static native String getBackendName_0(int i);

    private static native List<Integer> getBackends_0();

    private static native String getCameraBackendPluginVersion_0(int i, double[] dArr, double[] dArr2);

    private static native List<Integer> getCameraBackends_0();

    private static native String getStreamBackendPluginVersion_0(int i, double[] dArr, double[] dArr2);

    private static native List<Integer> getStreamBackends_0();

    private static native String getStreamBufferedBackendPluginVersion_0(int i, double[] dArr, double[] dArr2);

    private static native List<Integer> getStreamBufferedBackends_0();

    private static native String getWriterBackendPluginVersion_0(int i, double[] dArr, double[] dArr2);

    private static native List<Integer> getWriterBackends_0();

    private static native boolean hasBackend_0(int i);

    private static native boolean isBackendBuiltIn_0(int i);
}
