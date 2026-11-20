package com.scanflow.datacapture.barinternal.org.ejml.data;

/* JADX INFO: loaded from: classes3.dex */
public class IGrowArray {
    public int[] data;
    public int length;

    public IGrowArray(int i) {
        this.data = new int[i];
        this.length = i;
    }

    public IGrowArray() {
        this(0);
    }

    public void reshape(int i) {
        if (this.data.length < i) {
            this.data = new int[i];
        }
        this.length = i;
    }
}
