package com.scanflow.datacapture.barinternal.org.ddogleg.struct;

import java.util.Arrays;

/* JADX INFO: loaded from: classes3.dex */
public class DogArray_I32 {
    public int[] data;
    public int size;

    public DogArray_I32(int i) {
        this.data = new int[i];
        this.size = 0;
    }

    public DogArray_I32() {
        this(10);
    }

    public DogArray_I32 reset() {
        this.size = 0;
        return this;
    }

    public void addAll(DogArray_I32 dogArray_I32) {
        int i = this.size;
        int i2 = dogArray_I32.size;
        int i3 = i + i2;
        int[] iArr = this.data;
        if (i3 > iArr.length) {
            int[] iArr2 = new int[(i2 + i) * 2];
            System.arraycopy(iArr, 0, iArr2, 0, i);
            this.data = iArr2;
        }
        System.arraycopy(dogArray_I32.data, 0, this.data, this.size, dogArray_I32.size);
        this.size += dogArray_I32.size;
    }

    public void add(int i) {
        push(i);
    }

    public void push(int i) {
        int[] iArr;
        int i2 = this.size;
        if (i2 == this.data.length) {
            try {
                iArr = new int[(i2 * 2) + 5];
            } catch (OutOfMemoryError unused) {
                System.gc();
                iArr = new int[(this.size * 3) / 2];
            }
            System.arraycopy(this.data, 0, iArr, 0, this.size);
            this.data = iArr;
        }
        int[] iArr2 = this.data;
        int i3 = this.size;
        this.size = i3 + 1;
        iArr2[i3] = i;
    }

    public void remove(int i) {
        while (true) {
            i++;
            int i2 = this.size;
            if (i < i2) {
                int[] iArr = this.data;
                iArr[i - 1] = iArr[i];
            } else {
                this.size = i2 - 1;
                return;
            }
        }
    }

    public int get(int i) {
        if (i < 0 || i >= this.size) {
            throw new IndexOutOfBoundsException("index = " + i + "  size = " + this.size);
        }
        return this.data[i];
    }

    public void set(int i, int i2) {
        this.data[i] = i2;
    }

    public DogArray_I32 setTo(DogArray_I32 dogArray_I32) {
        resize(dogArray_I32.size);
        System.arraycopy(dogArray_I32.data, 0, this.data, 0, size());
        return this;
    }

    public DogArray_I32 resize(int i) {
        reserve(i);
        this.size = i;
        return this;
    }

    public void fill(int i) {
        Arrays.fill(this.data, 0, this.size, i);
    }

    public void reserve(int i) {
        int[] iArr = this.data;
        if (iArr.length >= i) {
            return;
        }
        int i2 = this.size;
        if (i2 == 0) {
            this.data = null;
            this.data = new int[i];
        } else {
            int[] iArr2 = new int[i];
            System.arraycopy(iArr, 0, iArr2, 0, i2);
            this.data = iArr2;
        }
    }

    public int size() {
        return this.size;
    }
}
