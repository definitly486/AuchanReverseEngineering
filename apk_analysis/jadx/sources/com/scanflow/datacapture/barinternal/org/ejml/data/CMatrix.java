package com.scanflow.datacapture.barinternal.org.ejml.data;

/* JADX INFO: loaded from: classes3.dex */
public interface CMatrix extends Matrix {
    void get(int i, int i2, Complex_F32 complex_F32);

    float getImag(int i, int i2);

    float getReal(int i, int i2);

    void set(int i, int i2, float f, float f2);
}
