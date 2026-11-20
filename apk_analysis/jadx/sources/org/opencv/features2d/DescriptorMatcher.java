package org.opencv.features2d;

import org.opencv.core.Algorithm;

/* JADX INFO: loaded from: classes3.dex */
public class DescriptorMatcher extends Algorithm {
    private static native void add_0(long j, long j2);

    private static native void clear_0(long j);

    private static native long clone_0(long j, boolean z);

    private static native long clone_1(long j);

    private static native long create_0(String str);

    private static native long create_1(int i);

    private static native void delete(long j);

    private static native boolean empty_0(long j);

    private static native long getTrainDescriptors_0(long j);

    private static native boolean isMaskSupported_0(long j);

    private static native void knnMatch_0(long j, long j2, long j3, long j4, int i, long j5, boolean z);

    private static native void knnMatch_1(long j, long j2, long j3, long j4, int i, long j5);

    private static native void knnMatch_2(long j, long j2, long j3, long j4, int i);

    private static native void knnMatch_3(long j, long j2, long j3, int i, long j4, boolean z);

    private static native void knnMatch_4(long j, long j2, long j3, int i, long j4);

    private static native void knnMatch_5(long j, long j2, long j3, int i);

    private static native void match_0(long j, long j2, long j3, long j4, long j5);

    private static native void match_1(long j, long j2, long j3, long j4);

    private static native void match_2(long j, long j2, long j3, long j4);

    private static native void match_3(long j, long j2, long j3);

    private static native void radiusMatch_0(long j, long j2, long j3, long j4, float f, long j5, boolean z);

    private static native void radiusMatch_1(long j, long j2, long j3, long j4, float f, long j5);

    private static native void radiusMatch_2(long j, long j2, long j3, long j4, float f);

    private static native void radiusMatch_3(long j, long j2, long j3, float f, long j4, boolean z);

    private static native void radiusMatch_4(long j, long j2, long j3, float f, long j4);

    private static native void radiusMatch_5(long j, long j2, long j3, float f);

    private static native void read_0(long j, String str);

    private static native void train_0(long j);

    private static native void write_0(long j, String str);

    protected DescriptorMatcher(long j) {
        super(j);
    }

    public static DescriptorMatcher __fromPtr__(long j) {
        return new DescriptorMatcher(j);
    }

    public DescriptorMatcher clone() {
        return __fromPtr__(clone_1(this.nativeObj));
    }

    @Override // org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
