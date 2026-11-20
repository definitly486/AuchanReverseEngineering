package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.scanflow.datacapture.barinternal.boofcv.alg.descriptor.DescriptorDistance;

/* JADX INFO: loaded from: classes.dex */
public abstract class QrCodePolynomialMath {
    public static boolean checkVersionBits(int i) {
        return bitPolyModulus(i, 7973, 18, 6) == 0;
    }

    public static int correctVersionBits(int i) {
        return correctDCH(64, i, 7973, 18, 6);
    }

    public static boolean checkFormatBits(int i) {
        return bitPolyModulus(i, 1335, 15, 5) == 0;
    }

    public static void decodeFormatMessage(int i, QrCode qrCode) {
        qrCode.error = QrCode.ErrorLevel.lookup(i >> 3);
        qrCode.mask = QrCodeMaskPattern.lookupMask(i & 7);
    }

    public static int correctFormatBits(int i) {
        return correctDCH(32, i, 1335, 15, 5);
    }

    public static int correctDCH(int i, int i2, int i3, int i4, int i5) {
        int i6 = i4 - i5;
        int i7 = 255;
        int i8 = -1;
        for (int i9 = 0; i9 < i; i9++) {
            int i10 = i9 << i6;
            int iHamming = DescriptorDistance.hamming((i10 ^ bitPolyModulus(i10, i3, i4, i5)) ^ i2);
            if (iHamming < i7) {
                i8 = i9;
                i7 = iHamming;
            } else if (iHamming == i7) {
                i8 = -1;
            }
        }
        return i8;
    }

    public static int bitPolyModulus(int i, int i2, int i3, int i4) {
        int i5 = i3 - i4;
        for (int i6 = i4 - 1; i6 >= 0; i6--) {
            if (((1 << (i6 + i5)) & i) != 0) {
                i ^= i2 << i6;
            }
        }
        return i;
    }
}
