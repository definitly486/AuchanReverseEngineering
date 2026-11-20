package com.scanflow.datacapture.barinternal.boofcv.struct.convolve;

/* JADX INFO: loaded from: classes.dex */
public class Kernel1D_F64 extends Kernel1D {
    public double[] data;

    public Kernel1D_F64(int i) {
        this(i, i / 2);
    }

    public Kernel1D_F64(int i, int i2) {
        super(i, i2);
        this.data = new double[i];
    }
}
