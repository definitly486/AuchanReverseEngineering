package com.scanflow.datacapture.barinternal.boofcv.struct.border;

/* JADX INFO: loaded from: classes.dex */
public abstract class BorderIndex1D {
    protected int length;

    public abstract int getIndex(int i);

    public void setLength(int i) {
        this.length = i;
    }
}
