package com.scanflow.datacapture.barinternal.boofcv.struct.convolve;

/* JADX INFO: loaded from: classes.dex */
public class Kernel2D_F64 extends Kernel2D {
    public double[] data;

    public Kernel2D_F64(int i) {
        super(i);
        this.data = new double[i * i];
    }
}
