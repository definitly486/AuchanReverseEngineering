package com.scanflow.datacapture.barinternal.org.opencv.core;

import org.opencv.core.Mat;

/* JADX INFO: loaded from: classes3.dex */
public class MatOfPoint extends Mat {
    public MatOfPoint(Mat mat) {
        super(mat, Range.all());
        if (!empty() && checkVector(2, 4) < 0) {
            throw new IllegalArgumentException("Incompatible Mat");
        }
    }
}
