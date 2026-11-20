package com.scanflow.datacapture.barinternal.org.ddogleg.struct;

import java.util.Arrays;

/* JADX INFO: loaded from: classes3.dex */
public class DogArray_F32 {
    public float[] data;
    public int size;

    public DogArray_F32(int i) {
        this.data = new float[i];
        this.size = 0;
    }

    public DogArray_F32() {
        this(10);
    }

    public DogArray_F32 reset() {
        this.size = 0;
        return this;
    }

    public void add(float f) {
        push(f);
    }

    public void push(float f) {
        float[] fArr;
        int i = this.size;
        if (i == this.data.length) {
            try {
                fArr = new float[(i * 2) + 5];
            } catch (OutOfMemoryError unused) {
                System.gc();
                fArr = new float[(this.size * 3) / 2];
            }
            System.arraycopy(this.data, 0, fArr, 0, this.size);
            this.data = fArr;
        }
        float[] fArr2 = this.data;
        int i2 = this.size;
        this.size = i2 + 1;
        fArr2[i2] = f;
    }

    public DogArray_F32 resize(int i) {
        reserve(i);
        this.size = i;
        return this;
    }

    public void fill(float f) {
        Arrays.fill(this.data, 0, this.size, f);
    }

    public void reserve(int i) {
        float[] fArr = this.data;
        if (fArr.length >= i) {
            return;
        }
        int i2 = this.size;
        if (i2 == 0) {
            this.data = null;
            this.data = new float[i];
        } else {
            float[] fArr2 = new float[i];
            System.arraycopy(fArr, 0, fArr2, 0, i2);
            this.data = fArr2;
        }
    }
}
