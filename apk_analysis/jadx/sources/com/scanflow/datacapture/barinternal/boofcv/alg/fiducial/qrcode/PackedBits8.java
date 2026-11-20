package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import java.util.Arrays;

/* JADX INFO: loaded from: classes.dex */
public class PackedBits8 {
    public byte[] data = new byte[1];
    public int size;

    public int get(int i) {
        int i2 = i / 8;
        int i3 = i % 8;
        return (this.data[i2] & (1 << i3)) >> i3;
    }

    public void set(int i, int i2) {
        int i3 = i / 8;
        byte[] bArr = this.data;
        byte b = bArr[i3];
        bArr[i3] = (byte) (((byte) ((1 << (i % 8)) & ((-i2) ^ b))) ^ b);
    }

    public int read(int i, int i2, boolean z) {
        if (i2 < 0 || i2 > 32) {
            throw new IllegalArgumentException("Length can't exceed 32");
        }
        if (i + i2 > this.size) {
            throw new IllegalArgumentException("Attempting to read past the end. length=" + i2 + " remaining=" + (this.size - i));
        }
        int i3 = 0;
        if (z) {
            int i4 = 0;
            while (i3 < i2) {
                i4 |= get(i + i3) << ((i2 - i3) - 1);
                i3++;
            }
            return i4;
        }
        int i5 = 0;
        while (i3 < i2) {
            i5 |= get(i + i3) << i3;
            i3++;
        }
        return i5;
    }

    public void resize(int i) {
        this.size = i;
        int iArrayLength = arrayLength();
        if (this.data.length < iArrayLength) {
            this.data = new byte[iArrayLength];
        }
    }

    public void zero() {
        Arrays.fill(this.data, 0, arrayLength(), (byte) 0);
    }

    public int arrayLength() {
        int i = this.size;
        if (i % 8 == 0) {
            return i / 8;
        }
        return (i / 8) + 1;
    }
}
