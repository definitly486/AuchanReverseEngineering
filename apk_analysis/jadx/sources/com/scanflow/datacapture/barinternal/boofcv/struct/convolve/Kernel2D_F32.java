package com.scanflow.datacapture.barinternal.boofcv.struct.convolve;

/* JADX INFO: loaded from: classes.dex */
public class Kernel2D_F32 extends Kernel2D {
    public float[] data;

    public Kernel2D_F32(int i) {
        super(i);
        this.data = new float[i * i];
    }
}
