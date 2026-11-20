package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

/* JADX INFO: loaded from: classes.dex */
public abstract class GaliosFieldOps {
    public static int subtract(int i, int i2) {
        return i ^ i2;
    }

    public static int multiply(int i, int i2, int i3, int i4) {
        int i5 = 0;
        while (i2 > 0) {
            if ((i2 & 1) != 0) {
                i5 ^= i;
            }
            i2 >>= 1;
            i <<= 1;
            if (i >= i4) {
                i ^= i3;
            }
        }
        return i5;
    }
}
