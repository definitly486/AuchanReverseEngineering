package com.scanflow.datacapture.barinternal.georegression.struct;

import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix3x3;

/* JADX INFO: loaded from: classes3.dex */
public abstract class Matrix3x3_F32 extends FMatrix3x3 {
    public void setTo(Matrix3x3_F32 matrix3x3_F32) {
        this.a11 = matrix3x3_F32.a11;
        this.a12 = matrix3x3_F32.a12;
        this.a13 = matrix3x3_F32.a13;
        this.a21 = matrix3x3_F32.a21;
        this.a22 = matrix3x3_F32.a22;
        this.a23 = matrix3x3_F32.a23;
        this.a31 = matrix3x3_F32.a31;
        this.a32 = matrix3x3_F32.a32;
        this.a33 = matrix3x3_F32.a33;
    }
}
