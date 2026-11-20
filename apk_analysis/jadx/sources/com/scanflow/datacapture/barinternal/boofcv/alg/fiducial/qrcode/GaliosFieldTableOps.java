package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

/* JADX INFO: loaded from: classes.dex */
public abstract class GaliosFieldTableOps {
    protected int[] exp;
    protected int[] log;
    protected int max_value;
    protected int numBits;
    protected int num_values;
    protected int primitive;

    public GaliosFieldTableOps(int i, int i2) {
        int iMultiply = 1;
        if (i < 1 || i > 16) {
            throw new IllegalArgumentException("Degree must be more than 1 and less than or equal to 16");
        }
        this.numBits = i;
        this.primitive = i2;
        this.max_value = 0;
        for (int i3 = 0; i3 < i; i3++) {
            this.max_value |= 1 << i3;
        }
        int i4 = this.max_value + 1;
        this.num_values = i4;
        this.log = new int[i4];
        this.exp = new int[i4 * 2];
        for (int i5 = 0; i5 < this.max_value; i5++) {
            this.exp[i5] = iMultiply;
            this.log[iMultiply] = i5;
            iMultiply = GaliosFieldOps.multiply(iMultiply, 2, i2, this.num_values);
        }
        for (int i6 = 0; i6 < this.num_values; i6++) {
            int[] iArr = this.exp;
            iArr[this.max_value + i6] = iArr[i6];
        }
    }

    public int multiply(int i, int i2) {
        if (i == 0 || i2 == 0) {
            return 0;
        }
        int[] iArr = this.exp;
        int[] iArr2 = this.log;
        return iArr[iArr2[i] + iArr2[i2]];
    }

    public int divide(int i, int i2) {
        if (i2 == 0) {
            throw new ArithmeticException("Divide by zero");
        }
        if (i == 0) {
            return 0;
        }
        int[] iArr = this.exp;
        int[] iArr2 = this.log;
        return iArr[(iArr2[i] + this.max_value) - iArr2[i2]];
    }

    public int power(int i, int i2) {
        return this.exp[(this.log[i] * i2) % this.max_value];
    }

    public int inverse(int i) {
        return this.exp[this.max_value - this.log[i]];
    }
}
