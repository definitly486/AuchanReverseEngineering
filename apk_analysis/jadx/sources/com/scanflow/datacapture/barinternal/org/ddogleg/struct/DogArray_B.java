package com.scanflow.datacapture.barinternal.org.ddogleg.struct;

/* JADX INFO: loaded from: classes3.dex */
public class DogArray_B {
    public boolean[] data;
    public int size;

    public DogArray_B(int i) {
        this.data = new boolean[i];
        this.size = 0;
    }

    public DogArray_B() {
        this(10);
    }

    public DogArray_B reset() {
        this.size = 0;
        return this;
    }

    public void add(boolean z) {
        push(z);
    }

    public void push(boolean z) {
        boolean[] zArr;
        int i = this.size;
        if (i == this.data.length) {
            try {
                zArr = new boolean[(i * 2) + 5];
            } catch (OutOfMemoryError unused) {
                System.gc();
                zArr = new boolean[(this.size * 3) / 2];
            }
            System.arraycopy(this.data, 0, zArr, 0, this.size);
            this.data = zArr;
        }
        boolean[] zArr2 = this.data;
        int i2 = this.size;
        this.size = i2 + 1;
        zArr2[i2] = z;
    }

    public DogArray_B setTo(DogArray_B dogArray_B) {
        resize(dogArray_B.size);
        System.arraycopy(dogArray_B.data, 0, this.data, 0, size());
        return this;
    }

    public DogArray_B resize(int i) {
        reserve(i);
        this.size = i;
        return this;
    }

    public void reserve(int i) {
        boolean[] zArr = this.data;
        if (zArr.length >= i) {
            return;
        }
        int i2 = this.size;
        if (i2 == 0) {
            this.data = null;
            this.data = new boolean[i];
        } else {
            boolean[] zArr2 = new boolean[i];
            System.arraycopy(zArr, 0, zArr2, 0, i2);
            this.data = zArr2;
        }
    }

    public int size() {
        return this.size;
    }
}
