package com.scanflow.datacapture.barinternal.org.ejml.data;

/* JADX INFO: loaded from: classes3.dex */
public interface FMatrix extends Matrix {
    float get(int i, int i2);

    float unsafe_get(int i, int i2);

    void unsafe_set(int i, int i2, float f);

    default int getNumElements() {
        return getNumRows() * getNumCols();
    }
}
