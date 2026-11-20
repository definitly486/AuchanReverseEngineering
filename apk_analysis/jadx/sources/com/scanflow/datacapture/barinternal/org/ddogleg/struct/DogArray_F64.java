package com.scanflow.datacapture.barinternal.org.ddogleg.struct;

/* JADX INFO: loaded from: classes3.dex */
public class DogArray_F64 {
    public double[] data;
    public int size;

    public DogArray_F64(int i) {
        this.data = new double[i];
        this.size = 0;
    }

    public DogArray_F64() {
        this(10);
    }

    public DogArray_F64 reset() {
        this.size = 0;
        return this;
    }

    public void add(double d) {
        push(d);
    }

    public void push(double d) {
        double[] dArr;
        int i = this.size;
        if (i == this.data.length) {
            try {
                dArr = new double[(i * 2) + 5];
            } catch (OutOfMemoryError unused) {
                System.gc();
                dArr = new double[(this.size * 3) / 2];
            }
            System.arraycopy(this.data, 0, dArr, 0, this.size);
            this.data = dArr;
        }
        double[] dArr2 = this.data;
        int i2 = this.size;
        this.size = i2 + 1;
        dArr2[i2] = d;
    }

    public double get(int i) {
        if (i < 0 || i >= this.size) {
            throw new IndexOutOfBoundsException("index = " + i + "  size = " + this.size);
        }
        return this.data[i];
    }
}
