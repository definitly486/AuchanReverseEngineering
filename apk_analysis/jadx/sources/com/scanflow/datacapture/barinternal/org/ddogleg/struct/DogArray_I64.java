package com.scanflow.datacapture.barinternal.org.ddogleg.struct;

/* JADX INFO: loaded from: classes3.dex */
public class DogArray_I64 {
    public long[] data;
    public int size;

    public DogArray_I64(int i) {
        this.data = new long[i];
        this.size = 0;
    }

    public DogArray_I64() {
        this(10);
    }
}
