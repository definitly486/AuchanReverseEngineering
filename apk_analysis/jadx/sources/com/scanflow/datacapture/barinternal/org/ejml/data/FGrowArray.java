package com.scanflow.datacapture.barinternal.org.ejml.data;

/* JADX INFO: loaded from: classes3.dex */
public class FGrowArray {
    public float[] data;
    public int length;

    public FGrowArray(int i) {
        this.data = new float[i];
        this.length = i;
    }

    public FGrowArray() {
        this(0);
    }

    public FGrowArray reshape(int i) {
        if (this.data.length < i) {
            this.data = new float[i];
        }
        this.length = i;
        return this;
    }
}
