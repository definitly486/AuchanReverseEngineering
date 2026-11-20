package com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.eig;

import com.scanflow.datacapture.barinternal.org.ejml.data.Complex_F64;

/* JADX INFO: loaded from: classes3.dex */
public class EigenvalueSmall_F64 {
    public Complex_F64 value0 = new Complex_F64();
    public Complex_F64 value1 = new Complex_F64();

    public void symm2x2_fast(double d, double d2, double d3) {
        double d4 = (d + d3) * 0.5d;
        double d5 = (d - d3) * 0.5d;
        double dSqrt = Math.sqrt((d5 * d5) + (d2 * d2));
        this.value0.real = d4 + dSqrt;
        this.value1.real = d4 - dSqrt;
    }
}
