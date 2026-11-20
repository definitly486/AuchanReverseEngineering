package com.scanflow.datacapture.barinternal.boofcv.struct.convolve;

/* JADX INFO: loaded from: classes.dex */
public class Kernel1D_S32 extends Kernel1D {
    public int[] data;

    public Kernel1D_S32(int i, int i2) {
        super(i, i2);
        this.data = new int[i];
    }

    public int get(int i) {
        return this.data[i];
    }

    public int computeSum() {
        int i = 0;
        int i2 = 0;
        while (true) {
            int[] iArr = this.data;
            if (i >= iArr.length) {
                return i2;
            }
            i2 += iArr[i];
            i++;
        }
    }
}
