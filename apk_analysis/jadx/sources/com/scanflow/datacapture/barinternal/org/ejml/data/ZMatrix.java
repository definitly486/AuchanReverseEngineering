package com.scanflow.datacapture.barinternal.org.ejml.data;

/* JADX INFO: loaded from: classes3.dex */
public interface ZMatrix extends Matrix {
    void get(int i, int i2, Complex_F64 complex_F64);

    int getDataLength();

    double getImag(int i, int i2);

    double getReal(int i, int i2);

    void set(int i, int i2, double d, double d2);
}
