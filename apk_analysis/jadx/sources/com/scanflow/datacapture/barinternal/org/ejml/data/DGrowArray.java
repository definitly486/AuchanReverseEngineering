package com.scanflow.datacapture.barinternal.org.ejml.data;

/* JADX INFO: loaded from: classes3.dex */
public class DGrowArray {
    public double[] data;
    public int length;

    public DGrowArray(int i) {
        this.data = new double[i];
        this.length = i;
    }

    public DGrowArray() {
        this(0);
    }

    public DGrowArray reshape(int i) {
        if (this.data.length < i) {
            this.data = new double[i];
        }
        this.length = i;
        return this;
    }
}
