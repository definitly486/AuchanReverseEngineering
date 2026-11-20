package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I8;

/* JADX INFO: loaded from: classes.dex */
public class GaliosFieldTableOps_U8 extends GaliosFieldTableOps {
    public GaliosFieldTableOps_U8(int i, int i2) {
        super(i, i2);
    }

    public void polyAddScaleB(DogArray_I8 dogArray_I8, DogArray_I8 dogArray_I9, int i, DogArray_I8 dogArray_I10) {
        dogArray_I10.resize(Math.max(dogArray_I8.size, dogArray_I9.size));
        int iMax = Math.max(0, dogArray_I9.size - dogArray_I8.size);
        int iMax2 = Math.max(0, dogArray_I8.size - dogArray_I9.size);
        int i2 = dogArray_I10.size;
        for (int i3 = 0; i3 < iMax2; i3++) {
            dogArray_I10.data[i3] = dogArray_I8.data[i3];
        }
        for (int i4 = 0; i4 < iMax; i4++) {
            dogArray_I10.data[i4] = (byte) multiply(dogArray_I9.data[i4] & UnsignedBytes.MAX_VALUE, i);
        }
        for (int iMax3 = Math.max(iMax, iMax2); iMax3 < i2; iMax3++) {
            dogArray_I10.data[iMax3] = (byte) ((dogArray_I8.data[iMax3 - iMax] & UnsignedBytes.MAX_VALUE) ^ multiply(dogArray_I9.data[iMax3 - iMax2] & UnsignedBytes.MAX_VALUE, i));
        }
    }

    public void polyMult(DogArray_I8 dogArray_I8, DogArray_I8 dogArray_I9, DogArray_I8 dogArray_I10) {
        dogArray_I10.resize((dogArray_I8.size + dogArray_I9.size) - 1);
        dogArray_I10.zero();
        for (int i = 0; i < dogArray_I9.size; i++) {
            int i2 = dogArray_I9.data[i] & UnsignedBytes.MAX_VALUE;
            for (int i3 = 0; i3 < dogArray_I8.size; i3++) {
                int i4 = dogArray_I8.data[i3] & UnsignedBytes.MAX_VALUE;
                byte[] bArr = dogArray_I10.data;
                int i5 = i3 + i;
                bArr[i5] = (byte) (((byte) multiply(i4, i2)) ^ bArr[i5]);
            }
        }
    }

    public void polyMult_flipA(DogArray_I8 dogArray_I8, DogArray_I8 dogArray_I9, DogArray_I8 dogArray_I10) {
        dogArray_I10.resize((dogArray_I8.size + dogArray_I9.size) - 1);
        dogArray_I10.zero();
        for (int i = 0; i < dogArray_I9.size; i++) {
            int i2 = dogArray_I9.data[i] & UnsignedBytes.MAX_VALUE;
            int i3 = 0;
            while (true) {
                int i4 = dogArray_I8.size;
                if (i3 < i4) {
                    int i5 = dogArray_I8.data[(i4 - i3) - 1] & UnsignedBytes.MAX_VALUE;
                    byte[] bArr = dogArray_I10.data;
                    int i6 = i3 + i;
                    bArr[i6] = (byte) (((byte) multiply(i5, i2)) ^ bArr[i6]);
                    i3++;
                }
            }
        }
    }

    public int polyEval(DogArray_I8 dogArray_I8, int i) {
        int iMultiply = dogArray_I8.data[0] & UnsignedBytes.MAX_VALUE;
        for (int i2 = 1; i2 < dogArray_I8.size; i2++) {
            iMultiply = multiply(iMultiply, i) ^ (dogArray_I8.data[i2] & UnsignedBytes.MAX_VALUE);
        }
        return iMultiply;
    }

    public int polyEval_S(DogArray_I8 dogArray_I8, int i) {
        byte[] bArr = dogArray_I8.data;
        int i2 = dogArray_I8.size;
        int iMultiply = bArr[i2 - 1] & UnsignedBytes.MAX_VALUE;
        for (int i3 = i2 - 2; i3 >= 0; i3--) {
            iMultiply = multiply(iMultiply, i) ^ (dogArray_I8.data[i3] & UnsignedBytes.MAX_VALUE);
        }
        return iMultiply;
    }

    public int polyEvalContinue(int i, DogArray_I8 dogArray_I8, int i2) {
        for (int i3 = 0; i3 < dogArray_I8.size; i3++) {
            i = multiply(i, i2) ^ (dogArray_I8.data[i3] & UnsignedBytes.MAX_VALUE);
        }
        return i;
    }
}
