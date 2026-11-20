package org.opencv.dnn;

/* JADX INFO: loaded from: classes3.dex */
public class DictValue {
    protected final long nativeObj;

    private static native long DictValue_0(int i);

    private static native long DictValue_1(double d);

    private static native long DictValue_2(String str);

    private static native void delete(long j);

    private static native int getIntValue_0(long j, int i);

    private static native int getIntValue_1(long j);

    private static native double getRealValue_0(long j, int i);

    private static native double getRealValue_1(long j);

    private static native String getStringValue_0(long j, int i);

    private static native String getStringValue_1(long j);

    private static native boolean isInt_0(long j);

    private static native boolean isReal_0(long j);

    private static native boolean isString_0(long j);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
