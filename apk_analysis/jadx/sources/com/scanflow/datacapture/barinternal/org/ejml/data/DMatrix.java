package com.scanflow.datacapture.barinternal.org.ejml.data;

/* JADX INFO: loaded from: classes3.dex */
public interface DMatrix extends Matrix {
    double get(int i, int i2);

    void set(int i, int i2, double d);

    double unsafe_get(int i, int i2);

    void unsafe_set(int i, int i2, double d);

    default int getNumElements() {
        return getNumRows() * getNumCols();
    }
}
