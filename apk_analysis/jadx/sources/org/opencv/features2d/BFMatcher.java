package org.opencv.features2d;

/* JADX INFO: loaded from: classes3.dex */
public class BFMatcher extends DescriptorMatcher {
    private static native long BFMatcher_0(int i, boolean z);

    private static native long BFMatcher_1(int i);

    private static native long BFMatcher_2();

    private static native long create_0(int i, boolean z);

    private static native long create_1(int i);

    private static native long create_2();

    private static native void delete(long j);

    @Override // org.opencv.features2d.DescriptorMatcher, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
