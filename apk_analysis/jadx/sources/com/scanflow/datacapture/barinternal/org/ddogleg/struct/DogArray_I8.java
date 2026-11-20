package com.scanflow.datacapture.barinternal.org.ddogleg.struct;

import java.util.Arrays;

/* JADX INFO: loaded from: classes3.dex */
public class DogArray_I8 {
    public byte[] data;
    public int size;

    public DogArray_I8(int i) {
        this.data = new byte[i];
        this.size = 0;
    }

    public DogArray_I8() {
        this(10);
    }

    public DogArray_I8 reset() {
        this.size = 0;
        return this;
    }

    public DogArray_I8 setTo(DogArray_I8 dogArray_I8) {
        resize(dogArray_I8.size);
        System.arraycopy(dogArray_I8.data, 0, this.data, 0, size());
        return this;
    }

    public DogArray_I8 resize(int i) {
        reserve(i);
        this.size = i;
        return this;
    }

    public DogArray_I8 resize(int i, byte b) {
        int i2 = this.size;
        resize(i);
        if (i2 >= i) {
            return this;
        }
        fill(i2, i, b);
        return this;
    }

    public void fill(int i, int i2, byte b) {
        Arrays.fill(this.data, i, i2, b);
    }

    public void reserve(int i) {
        byte[] bArr = this.data;
        if (bArr.length >= i) {
            return;
        }
        int i2 = this.size;
        if (i2 == 0) {
            this.data = null;
            this.data = new byte[i];
        } else {
            byte[] bArr2 = new byte[i];
            System.arraycopy(bArr, 0, bArr2, 0, i2);
            this.data = bArr2;
        }
    }

    public int size() {
        return this.size;
    }

    public void zero() {
        Arrays.fill(this.data, 0, this.size, (byte) 0);
    }
}
