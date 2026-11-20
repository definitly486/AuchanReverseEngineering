package org.opencv.objdetect;

import org.opencv.core.Algorithm;

/* JADX INFO: loaded from: classes3.dex */
public class BaseCascadeClassifier extends Algorithm {
    private static native void delete(long j);

    @Override // org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
