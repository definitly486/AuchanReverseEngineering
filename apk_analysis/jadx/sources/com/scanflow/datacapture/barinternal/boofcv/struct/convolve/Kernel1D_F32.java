package com.scanflow.datacapture.barinternal.boofcv.struct.convolve;

/* JADX INFO: loaded from: classes.dex */
public class Kernel1D_F32 extends Kernel1D {
    public float[] data;

    public Kernel1D_F32(int i) {
        this(i, i / 2);
    }

    public Kernel1D_F32(int i, int i2) {
        super(i, i2);
        this.data = new float[i];
    }

    public Kernel1D_F32 copy() {
        Kernel1D_F32 kernel1D_F32 = new Kernel1D_F32(this.width, this.offset);
        System.arraycopy(this.data, 0, kernel1D_F32.data, 0, kernel1D_F32.width);
        return kernel1D_F32;
    }

    public float get(int i) {
        return this.data[i];
    }

    public float computeSum() {
        float f = 0.0f;
        int i = 0;
        while (true) {
            float[] fArr = this.data;
            if (i >= fArr.length) {
                return f;
            }
            f += fArr[i];
            i++;
        }
    }
}
