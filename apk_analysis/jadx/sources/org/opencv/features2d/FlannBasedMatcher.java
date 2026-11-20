package org.opencv.features2d;

/* JADX INFO: loaded from: classes3.dex */
public class FlannBasedMatcher extends DescriptorMatcher {
    private static native long FlannBasedMatcher_0();

    private static native long create_0();

    private static native void delete(long j);

    @Override // org.opencv.features2d.DescriptorMatcher, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
