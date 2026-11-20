package org.opencv.features2d;

/* JADX INFO: loaded from: classes3.dex */
public class BOWImgDescriptorExtractor {
    protected final long nativeObj;

    private static native long BOWImgDescriptorExtractor_0(long j, long j2);

    private static native void compute_0(long j, long j2, long j3, long j4);

    private static native void delete(long j);

    private static native int descriptorSize_0(long j);

    private static native int descriptorType_0(long j);

    private static native long getVocabulary_0(long j);

    private static native void setVocabulary_0(long j, long j2);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
